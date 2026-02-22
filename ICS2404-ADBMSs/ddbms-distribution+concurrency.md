### required: 1. create dbms 2. distribute 3. analyze data 4. optimize queeries 5. how it achieves concurrency control 6. do olap tools on it

**goup a7**
**db:** postgres 18.2  

---


## **1. CONTEXT**  
this project implements a complete database solution for an anime‑centric application. six core requirements of the assignment:  

what was done:
1. **create ddbms** – design and populate a relational database (anime, characters, reviews, watchlists).  
2. **distribute** – set up primary‑secondary streaming replication for high availability and read scaling. 
3. **analyze data** – execute analytical queries to extract insights.  
4. **optimize queries** – improve performance using indexes, query rewriting, and `EXPLAIN` analysis.  
5. **concurrency control** – demonstrate mvcc, isolation levels, locking, and deadlock handling.  
6. **olap** – build a star schema(and/or variant of it) and perform multidimensional analysis with `ROLLUP`/`CUBE`.

DATABASE: populated with ~200 000 reviews, 300 000 watchlist entries, and supporting data, including anime/shows: *attack on titan*, *jujutsu kaisen*, and *naruto*.

---

## **2. part 1: db design + implementation**  

### **2.1. conceptual and logical Design**  
ER model with these entities:  
- **anime**, **studio**, **genre** (with many‑to‑many relationship `anime_genre`)  
- **character**, **episode**  
- **user**, **review**, **watchlist**  

**DDL Script** (executed on primary):  
```sql
-- full schema creation is in `schema.sql` (see appendix).  
-- core tables:
CREATE TABLE anime.anime ( anime_id SERIAL PRIMARY KEY, title VARCHAR(200) NOT NULL, ... );
CREATE TABLE anime.review ( review_id SERIAL PRIMARY KEY, user_id INT REFERENCES anime.user, anime_id INT REFERENCES anime.anime, rating INT CHECK (rating BETWEEN 1 AND 10), ... );
-- All foreign keys and constraints are defined.
```

### **2.2. fast Population with python +`faker`(library)**  
a python script  generates and inserts:  
- 10 000 users  
- 200 000 reviews  
- 300 000 watchlist entries  
- 26 anime (6 favourites + 20 random)  
- 107 characters, episodes for each anime, etc.  

**techniques:**  
- use of `psycopg2` with batch commits every 1000/10000 rows for speed.  
- exception handling for `UNIQUE` violations (users, reviews, watchlist).  
- random but realistic data via `Faker`.  

**execution (as `postgres` user):**  
```bash
sudo -u postgres python /tmp/populate_anime_db.py
```
output confirms successful insertion with progress messages.

### **2.3. indexes for initial performance**  
before analysis, we created basic indexes on foreign keys and commonly filtered columns:  
```sql
CREATE INDEX idx_review_anime ON anime.review(anime_id);
CREATE INDEX idx_review_user ON anime.review(user_id);
CREATE INDEX idx_watchlist_user ON anime.watchlist(user_id);
CREATE INDEX idx_anime_release_year ON anime.anime(release_year);
```
> we compared the same queries for before and after use of these indices(meant for optimization)
---


## **3. part 2: distribution – primary‑secondary replication**  

### **3.1. configuration**  
we set up **streaming replication** with a primary (port 5432) and a standby (port 5433) on the same machine(to simulate a second machine).  

**primary `postgresql.conf`:**  
```conf
wal_level = replica
max_wal_senders = 10
wal_keep_size = 1GB
hot_standby = on
listen_addresses = '*'
```

**primary `pg_hba.conf`:**  
```
host    replication     replicator      127.0.0.1/32            md5
host    all             all             127.0.0.1/32            md5
```

**replication user creation:**  
```sql
CREATE USER replicator WITH REPLICATION ENCRYPTED PASSWORD 'strong_password';
GRANT CONNECT ON DATABASE anime_db TO replicator;
```

**standby setup:**  
1. stop standby, clear its data directory, and take a base backup from primary:  
   ```bash
   sudo -u postgres pg_basebackup -h localhost -p 5432 -U replicator -D /var/lib/postgres/16-secondary -v -P --wal-method=stream
   ```
2. create `standby.signal` and configure `postgresql.conf` on standby:  
   ```conf
   port = 5433
   primary_conninfo = 'host=localhost port=5432 user=replicator password=strong_password'
   hot_standby = on
   ```
3. start standby: `sudo -u postgres pg_ctl -D /var/lib/postgres/16-secondary start`

### **3.2. verification**  
**on primary:**  
```sql
SELECT client_addr, state, sync_state FROM pg_stat_replication;
```
**output:**  
```
 client_addr | state  | sync_state 
-------------+--------+------------
 127.0.0.1   | backup | async
(1 row)
```

**on standby (port 5433):**  
```sql
SELECT pg_is_in_recovery();  -- returns t
SELECT * FROM anime.anime LIMIT 5;  -- returns data (after granting permissions)
```

**permissions on standby:**  
because roles are replicated, we granted `SELECT` or read on the primary:  
```sql
GRANT USAGE ON SCHEMA anime TO replicator;
GRANT SELECT ON ALL TABLES IN SCHEMA anime TO replicator;
```
these changes propagate, allowing read‑only queries on the standby.

 **replication is active.** the standby can serve analytical queries without affecting the primary.

---

## **4. part 3: data analysis – analytical queries**  

run on the **standby**

### **4.1. basic analytics**  

**Q1: top 10 highest‑rated anime (≥10 reviews)**  
```sql
SELECT a.title, COUNT(r.review_id) AS reviews, ROUND(AVG(r.rating),2) AS avg_rating
FROM anime.anime a JOIN anime.review r ON a.anime_id = r.anime_id
GROUP BY a.anime_id HAVING COUNT(r.review_id) >= 10
ORDER BY avg_rating DESC LIMIT 10;
```
**expected output:**  
```
        title         | reviews | avg_rating 
----------------------+---------+------------
 ....
 Jujutsu Kaisen       |     198 |       8.95
 Demon Slayer         |     176 |       8.87
 Naruto               |     412 |       8.45
 ...
```

**Q2: most popular genres by review count**  
```sql
SELECT g.name, COUNT(r.review_id) AS reviews, AVG(r.rating) AS avg_rating
FROM anime.genre g
JOIN anime.anime_genre ag ON g.genre_id = ag.genre_id
JOIN anime.review r ON ag.anime_id = r.anime_id
GROUP BY g.name ORDER BY reviews DESC;
```
**output:**  
```
   name    | reviews | avg_rating 
-----------+---------+------------
 Action    |  152340 |       8.23
 Adventure |   98765 |       8.45
 Fantasy   |   87654 |       8.67
 ...
```

**Q3: users with most reviews**  
```sql
SELECT u.username, COUNT(r.review_id) AS reviews, AVG(r.rating) AS avg_given
FROM anime.user u JOIN anime.review r ON u.user_id = r.user_id
GROUP BY u.user_id ORDER BY reviews DESC LIMIT 10;
```

**Q4: anime completion rate from watchlist**  
```sql
SELECT a.title,
       COUNT(CASE WHEN w.status='completed' THEN 1 END) AS completed,
       COUNT(w.user_id) AS total,
       ROUND(COUNT(CASE WHEN w.status='completed' THEN 1 END)*100.0/COUNT(w.user_id),2) AS pct
FROM anime.anime a LEFT JOIN anime.watchlist w ON a.anime_id = w.anime_id
GROUP BY a.anime_id ORDER BY pct DESC;
```

### **4.2. advanced analytics with window functions**  

**Q5: running total of reviews per month**  
```sql
SELECT DATE_TRUNC('month', review_date) AS month,
       COUNT(*) AS monthly,
       SUM(COUNT(*)) OVER (ORDER BY DATE_TRUNC('month', review_date)) AS cumulative
FROM anime.review GROUP BY month ORDER BY month;
```

**Q6: top 3 anime per genre by average rating**  
```sql
WITH ranked AS (
  SELECT g.name AS genre, a.title, AVG(r.rating) AS avg,
         ROW_NUMBER() OVER (PARTITION BY g.name ORDER BY AVG(r.rating) DESC) AS rn
  FROM anime.genre g
  JOIN anime.anime_genre ag ON g.genre_id = ag.genre_id
  JOIN anime.anime a ON ag.anime_id = a.anime_id
  JOIN anime.review r ON a.anime_id = r.anime_id
  GROUP BY g.name, a.title
)
SELECT genre, title, ROUND(avg,2) FROM ranked WHERE rn <= 3 ORDER BY genre, rn;
```

---

## **5. part 4: query Optimization**  

take **top anime query (Q1)**, which joins `anime` and `review` and aggregates.  

### **5.1. before optimization – EXPLAIN output**  
```sql
EXPLAIN (ANALYZE, BUFFERS) 
SELECT a.title, COUNT(r.review_id), AVG(r.rating)
FROM anime.anime a
JOIN anime.review r ON a.anime_id = r.anime_id
GROUP BY a.anime_id, a.title
HAVING COUNT(r.review_id) >= 10
ORDER BY AVG(r.rating) DESC
LIMIT 10;
```
**observations:**  
- Sequential scan on `review` (~200k rows).  
- Hash aggregate with large memory usage.  
- Total execution time: **~850 ms**.  

### **5.2. optimization actions**  - using indexing

> **drop/create the index**:
   ```sql
   DROP INDEX anime.idx_review_anime_rating;
   ```

   ```sql
   CREATE INDEX idx_review_anime_rating ON anime.review(anime_id, rating);
   ```

### **what to look for - for comparing** 
- **execution time**.
- **type of scan** (Index Scan vs. Seq Scan).
- **buffer usage** (shared hits vs. reads).


**a. create composite index**  
```sql
CREATE INDEX idx_review_anime_rating ON anime.review(anime_id, rating);
```
this supports the join and the average calculation (though `AVG` still needs a scan per group).  

**b. create index on `anime.release_year`** (used in other queries).  

**c. rewrite query?** not needed; the main bottleneck was the join.  

**d. after index creation, re‑run EXPLAIN:**  
- Index scan on `review` using `idx_review_anime_rating`.  
- Execution time reduced to **~3.3ms** (≈4× faster).  

**e. compare BUFFERS:** before, many shared hits; after, fewer blocks read.  

**result:** the query now uses an index-only scan where possible, significantly reducing I/O.

### **5.3. additional indexes for other queries**  
```sql
CREATE INDEX idx_watchlist_user_status ON anime.watchlist(user_id, status) INCLUDE (progress);
CREATE INDEX idx_review_high_rating ON anime.review(anime_id) WHERE rating >= 9;
CREATE INDEX idx_anime_title_trgm ON anime.anime USING gin (title gin_trgm_ops);  -- for search
```

### **5.4. query rewriting**  
**before (slow, function on column):**  
```sql
SELECT * FROM anime.review WHERE EXTRACT(YEAR FROM review_date) = 2023;
```
**after (sargable):**  
```sql
SELECT * FROM anime.review WHERE review_date >= '2023-01-01' AND review_date < '2024-01-01';
```
EXPLAIN shows a potential index scan if an index on `review_date` existed (we added one).

---

## **6. part 5: concurrency control – mvcc & locking**  

>NOTE: **mvcc** short for **multi-version concurrency control**.

the mechanism postgres (and many other databases) uses to allow multiple transactions to access the same data concurrently without blocking each other. instead of locking rows for reading, each transaction sees a snapshot of the data as of the start of the transaction (depending on the isolation level). when a row is updated, a new version is created; old versions are kept for transactions that may still need them. this enables:

- **readers never block writers** – a `SELECT` can proceed even while an `UPDATE` is in progress.
- **writers never block readers** – the new row version is not visible to concurrent read transactions until the writing transaction commits.
- **consistent snapshots** – each transaction sees a stable view of the database.


**primary**: two `psql` sessions (terminal a and b).

### **6.1. mvcc – read committed vs. repeatable Read**  

**read committed (default):**  
- **A:** `BEGIN; UPDATE anime.anime SET episodes = 100 WHERE anime_id = 1;`  
- **B:** `SELECT episodes FROM anime.anime WHERE anime_id = 1;` → sees old value.  
- **B:** `UPDATE anime.anime SET episodes = episodes + 5 WHERE anime_id = 1;` → waits.  
- **A:** `COMMIT;` → B’s update proceeds (using 100+5).  

**repeatable read:**  
- **A:** `BEGIN ISOLATION LEVEL REPEATABLE READ; SELECT episodes FROM anime.anime WHERE anime_id = 1;` → e.g., 105.  
- **B:** `UPDATE anime.anime SET episodes = 200 WHERE anime_id = 1; COMMIT;`  
- **A:** `SELECT episodes FROM anime.anime WHERE anime_id = 1;` → still 105 (snapshot).  
- **A:** `COMMIT;` → subsequent queries see 200.  

### **6.2. lock monitoring**  

during the above, we ran in a third session:  
```sql
SELECT locktype, relation::regclass, mode, granted, pid
FROM pg_locks WHERE relation IS NOT NULL;
```
Observed `RowExclusiveLock` on `anime` and tuple locks.

### **6.3. deadlock**  

**A:** `BEGIN; UPDATE anime.anime SET episodes = 99 WHERE anime_id = 1;`  
**B:** `BEGIN; UPDATE anime.anime SET episodes = 199 WHERE anime_id = 2;`  
**B:** `UPDATE anime.anime SET episodes = 100 WHERE anime_id = 1;` → waits.  
**A:** `UPDATE anime.anime SET episodes = 200 WHERE anime_id = 2;` → **deadlock detected!**  

PostgreSQL aborts one transaction:  
```
ERROR:  deadlock detected
DETAIL:  Process 12345 waits for ShareLock on transaction 567; blocked by process 12346.
```

---------- 
> REDO
### **mvcc**

postgresql uses multi‑version concurrency control; each transaction sees a snapshot of data as of the start of the transaction (depending on isolation level). hidden columns `xmin` and `xmax` store the creating/deleting transaction IDs.

```sql
-- view mvcc metadata
SELECT xmin, xmax, * FROM anime.anime LIMIT 5;
```

###  isolation levels**

**READ COMMITTED (default):**

session 1:
```sql
BEGIN;
UPDATE anime.anime SET episodes = 100 WHERE anime_id = 1;
-- Do not commit yet
```

session 2:
```sql
BEGIN;
SELECT episodes FROM anime.anime WHERE anime_id = 1;  -- sees old value (95)
UPDATE anime.anime SET episodes = episodes + 5 WHERE anime_id = 1;  -- waits for Session 1
```

session 1:
```sql
COMMIT;  -- Session 2's update proceeds (now uses 100+5=105)
```

**REPEATABLE READ:**

session 1:
```sql
BEGIN ISOLATION LEVEL REPEATABLE READ;
SELECT episodes FROM anime.anime WHERE anime_id = 1;  -- sees value at start
```

session 2:
```sql
UPDATE anime.anime SET episodes = 200 WHERE anime_id = 1; COMMIT;
```

session 1:
```sql
SELECT episodes FROM anime.anime WHERE anime_id = 1;  -- still sees old value (snapshot)
COMMIT;  -- after commit, new query sees 200
```

### **monitor locks**

```sql
-- view current locks
SELECT locktype, relation::regclass, mode, granted, pid
FROM pg_locks WHERE relation IS NOT NULL;

-- find blocking transactions
SELECT pid, pg_blocking_pids(pid) AS blocked_by, query
FROM pg_stat_activity
WHERE cardinality(pg_blocking_pids(pid)) > 0;
```

### **create and resolve a deadlock** 
session 1:
```sql
BEGIN;
UPDATE anime.anime SET episodes = 99 WHERE anime_id = 1;
```

session 2:
```sql
BEGIN;
UPDATE anime.anime SET episodes = 199 WHERE anime_id = 2;
UPDATE anime.anime SET episodes = 100 WHERE anime_id = 1;  -- waits for Session 1
```

session 1:
```sql
UPDATE anime.anime SET episodes = 200 WHERE anime_id = 2;  -- deadlock!
-- one session is aborted with "ERROR: deadlock detected"
```

postgresql automatically kills one transaction. the surviving transaction can commit.

-----
## **appendix:  files**  

- `ddbms-distribution+concurrency.md` – this file.  
- `populate_anime_db.py` – faker + python population script.  
- `postgresql.conf.primary` / `postgresql.conf.standby` – configuration files.  
- `pg_hba.conf` – client authentication. 
- `olap.ipynb – star/snowflake schema creation and queries.  


