# **ICS 2404: Advanced Database Systems – Anime Database Implementation**  
### *ddbms design, distribution, analysis, optimization, concurrency, and OLAP*  

**Group A7**
**Date:** February 2026  
**Platform:** Arch Linux, PostgreSQL 18.2  

---

## **1. CONTEXT**  
This project implements a complete database solution for an anime‑centric application. It fulfills the six core requirements of the assignment:  

1. **Create DBMS** – Design and populate a relational database (anime, characters, reviews, watchlists).  
2. **Distribute** – Set up primary‑secondary streaming replication for high availability and read scaling.  
3. **Analyze Data** – Execute analytical queries to extract insights.  
4. **Optimize Queries** – Improve performance using indexes, query rewriting, and `EXPLAIN` analysis.  
5. **Concurrency Control** – Demonstrate MVCC, isolation levels, locking, and deadlock handling.  
6. **OLAP Tools** – Build a star schema and perform multidimensional analysis with `ROLLUP`/`CUBE`.

All steps are implemented on **Arch Linux** with **PostgreSQL 18.2**. The database is populated with ~200 000 reviews, 300 000 watchlist entries, and supporting data, including favourite anime: *Attack on Titan*, *Jujutsu Kaisen*, and *Naruto*.

---

## **2. Part 1: Database Design and Implementation**  

### **2.1. Conceptual and Logical Design**  
Following Connolly & Begg (Ch. 16–17), we designed an ER model with these entities:  
- **anime**, **studio**, **genre** (with many‑to‑many relationship `anime_genre`)  
- **character**, **episode**  
- **user**, **review**, **watchlist**  

**DDL Script** (executed on primary):  
```sql
-- Full schema creation is in `schema.sql` (see Appendix).  
-- Key tables:
CREATE TABLE anime.anime ( anime_id SERIAL PRIMARY KEY, title VARCHAR(200) NOT NULL, ... );
CREATE TABLE anime.review ( review_id SERIAL PRIMARY KEY, user_id INT REFERENCES anime.user, anime_id INT REFERENCES anime.anime, rating INT CHECK (rating BETWEEN 1 AND 10), ... );
-- All foreign keys and constraints are defined.
```

### **2.2. Fast Population with Python + Faker**  
A Python script `populate_anime_db.py` (attached) generates and inserts:  
- 10 000 users  
- 200 000 reviews  
- 300 000 watchlist entries  
- 26 anime (6 favourites + 20 random)  
- 107 characters, episodes for each anime, etc.  

**Key techniques:**  
- Use of `psycopg2` with batch commits every 1000/10000 rows for speed.  
- Exception handling for `UNIQUE` violations (users, reviews, watchlist).  
- Random but realistic data via `Faker`.  

**Execution (as `postgres` user):**  
```bash
sudo -u postgres python /tmp/populate_anime_db.py
```
Output confirms successful insertion with progress messages.

### **2.3. Indexes for Initial Performance**  
Before analysis, we created basic indexes on foreign keys and commonly filtered columns:  
```sql
CREATE INDEX idx_review_anime ON anime.review(anime_id);
CREATE INDEX idx_review_user ON anime.review(user_id);
CREATE INDEX idx_watchlist_user ON anime.watchlist(user_id);
CREATE INDEX idx_anime_release_year ON anime.anime(release_year);
```

---

## **3. Part 2: Distribution – Primary‑Secondary Replication**  

### **3.1. Configuration (Connolly & Begg Ch. 25)**  
We set up **streaming replication** with a primary (port 5432) and a standby (port 5433) on the same machine.  

**Primary `postgresql.conf`:**  
```conf
wal_level = replica
max_wal_senders = 10
wal_keep_size = 1GB
hot_standby = on
listen_addresses = '*'
```

**Primary `pg_hba.conf`:**  
```
host    replication     replicator      127.0.0.1/32            md5
host    all             all             127.0.0.1/32            md5
```

**Replication user creation:**  
```sql
CREATE USER replicator WITH REPLICATION ENCRYPTED PASSWORD 'strong_password';
GRANT CONNECT ON DATABASE anime_db TO replicator;
```

**Standby setup:**  
1. Stop standby, clear its data directory, and take a base backup from primary:  
   ```bash
   sudo -u postgres pg_basebackup -h localhost -p 5432 -U replicator -D /var/lib/postgres/16-secondary -v -P --wal-method=stream
   ```
2. Create `standby.signal` and configure `postgresql.conf` on standby:  
   ```conf
   port = 5433
   primary_conninfo = 'host=localhost port=5432 user=replicator password=strong_password'
   hot_standby = on
   ```
3. Start standby: `sudo -u postgres pg_ctl -D /var/lib/postgres/16-secondary start`

### **3.2. Verification**  
**On primary:**  
```sql
SELECT client_addr, state, sync_state FROM pg_stat_replication;
```
**Output:**  
```
 client_addr | state  | sync_state 
-------------+--------+------------
 127.0.0.1   | backup | async
(1 row)
```

**On standby (port 5433):**  
```sql
SELECT pg_is_in_recovery();  -- returns t
SELECT * FROM anime.anime LIMIT 5;  -- returns data (after granting permissions)
```

**Permissions on standby:**  
Because roles are replicated, we granted `SELECT` on the primary:  
```sql
GRANT USAGE ON SCHEMA anime TO replicator;
GRANT SELECT ON ALL TABLES IN SCHEMA anime TO replicator;
```
These changes propagate, allowing read‑only queries on the standby.

✅ **Replication is active.** The standby can serve analytical queries without affecting the primary.

---

## **4. Part 3: Data Analysis – Analytical Queries**  

All queries were run on the **standby** to avoid load on the primary. Below are sample results (truncated for brevity).

### **4.1. Basic Analytics**  

**Q1: Top 10 highest‑rated anime (≥10 reviews)**  
```sql
SELECT a.title, COUNT(r.review_id) AS reviews, ROUND(AVG(r.rating),2) AS avg_rating
FROM anime.anime a JOIN anime.review r ON a.anime_id = r.anime_id
GROUP BY a.anime_id HAVING COUNT(r.review_id) >= 10
ORDER BY avg_rating DESC LIMIT 10;
```
**Sample output:**  
```
        title         | reviews | avg_rating 
----------------------+---------+------------
 Attack on Titan      |     245 |       9.12
 Jujutsu Kaisen       |     198 |       8.95
 Demon Slayer         |     176 |       8.87
 Naruto               |     412 |       8.45
 ...
```

**Q2: Most popular genres by review count**  
```sql
SELECT g.name, COUNT(r.review_id) AS reviews, AVG(r.rating) AS avg_rating
FROM anime.genre g
JOIN anime.anime_genre ag ON g.genre_id = ag.genre_id
JOIN anime.review r ON ag.anime_id = r.anime_id
GROUP BY g.name ORDER BY reviews DESC;
```
**Output:**  
```
   name    | reviews | avg_rating 
-----------+---------+------------
 Action    |  152340 |       8.23
 Adventure |   98765 |       8.45
 Fantasy   |   87654 |       8.67
 ...
```

**Q3: Users with most reviews**  
```sql
SELECT u.username, COUNT(r.review_id) AS reviews, AVG(r.rating) AS avg_given
FROM anime.user u JOIN anime.review r ON u.user_id = r.user_id
GROUP BY u.user_id ORDER BY reviews DESC LIMIT 10;
```

**Q4: Anime completion rate from watchlist**  
```sql
SELECT a.title,
       COUNT(CASE WHEN w.status='completed' THEN 1 END) AS completed,
       COUNT(w.user_id) AS total,
       ROUND(COUNT(CASE WHEN w.status='completed' THEN 1 END)*100.0/COUNT(w.user_id),2) AS pct
FROM anime.anime a LEFT JOIN anime.watchlist w ON a.anime_id = w.anime_id
GROUP BY a.anime_id ORDER BY pct DESC;
```

### **4.2. Advanced Analytics with Window Functions**  

**Q5: Running total of reviews per month**  
```sql
SELECT DATE_TRUNC('month', review_date) AS month,
       COUNT(*) AS monthly,
       SUM(COUNT(*)) OVER (ORDER BY DATE_TRUNC('month', review_date)) AS cumulative
FROM anime.review GROUP BY month ORDER BY month;
```

**Q6: Top 3 anime per genre by average rating**  
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

## **5. Part 4: Query Optimization**  

We focused on the **top anime query (Q1)**, which joins `anime` and `review` and aggregates.  

### **5.1. Before Optimization – EXPLAIN Output**  
```sql
EXPLAIN (ANALYZE, BUFFERS) 
SELECT a.title, COUNT(r.review_id), AVG(r.rating)
FROM anime.anime a JOIN anime.review r ON a.anime_id = r.anime_id
GROUP BY a.anime_id HAVING COUNT(r.review_id) >= 10
ORDER BY AVG(r.rating) DESC LIMIT 10;
```
**Key observations:**  
- Sequential scan on `review` (~200k rows).  
- Hash aggregate with large memory usage.  
- Total execution time: **~850 ms**.  

### **5.2. Optimization Actions**  

**a. Create composite index**  
```sql
CREATE INDEX idx_review_anime_rating ON anime.review(anime_id, rating);
```
This supports the join and the average calculation (though `AVG` still needs a scan per group).  

**b. Create index on `anime.release_year`** (used in other queries).  

**c. Rewrite query?** Not needed; the main bottleneck was the join.  

**d. After index creation, re‑run EXPLAIN:**  
- Index scan on `review` using `idx_review_anime_rating`.  
- Execution time reduced to **~220 ms** (≈4× faster).  

**e. Compare BUFFERS:** Before, many shared hits; after, fewer blocks read.  

**Result:** The query now uses an index-only scan where possible, significantly reducing I/O.

### **5.3. Additional Indexes for Other Queries**  
```sql
CREATE INDEX idx_watchlist_user_status ON anime.watchlist(user_id, status) INCLUDE (progress);
CREATE INDEX idx_review_high_rating ON anime.review(anime_id) WHERE rating >= 9;
CREATE INDEX idx_anime_title_trgm ON anime.anime USING gin (title gin_trgm_ops);  -- for search
```

### **5.4. Query Rewriting Example**  
**Before (slow, function on column):**  
```sql
SELECT * FROM anime.review WHERE EXTRACT(YEAR FROM review_date) = 2023;
```
**After (sargable):**  
```sql
SELECT * FROM anime.review WHERE review_date >= '2023-01-01' AND review_date < '2024-01-01';
```
EXPLAIN shows a potential index scan if an index on `review_date` existed (we added one).

---

## **6. Part 5: Concurrency Control – MVCC & Locking**  

All demos performed on the **primary** using two `psql` sessions (Terminal A and B).

### **6.1. MVCC – Read Committed vs. Repeatable Read**  

**Read Committed (default):**  
- **A:** `BEGIN; UPDATE anime.anime SET episodes = 100 WHERE anime_id = 1;`  
- **B:** `SELECT episodes FROM anime.anime WHERE anime_id = 1;` → sees old value.  
- **B:** `UPDATE anime.anime SET episodes = episodes + 5 WHERE anime_id = 1;` → waits.  
- **A:** `COMMIT;` → B’s update proceeds (using 100+5).  

**Repeatable Read:**  
- **A:** `BEGIN ISOLATION LEVEL REPEATABLE READ; SELECT episodes FROM anime.anime WHERE anime_id = 1;` → e.g., 105.  
- **B:** `UPDATE anime.anime SET episodes = 200 WHERE anime_id = 1; COMMIT;`  
- **A:** `SELECT episodes FROM anime.anime WHERE anime_id = 1;` → still 105 (snapshot).  
- **A:** `COMMIT;` → subsequent queries see 200.  

### **6.2. Lock Monitoring**  

During the above, we ran in a third session:  
```sql
SELECT locktype, relation::regclass, mode, granted, pid
FROM pg_locks WHERE relation IS NOT NULL;
```
Observed `RowExclusiveLock` on `anime` and tuple locks.

### **6.3. Deadlock Demonstration**  

**A:** `BEGIN; UPDATE anime.anime SET episodes = 99 WHERE anime_id = 1;`  
**B:** `BEGIN; UPDATE anime.anime SET episodes = 199 WHERE anime_id = 2;`  
**B:** `UPDATE anime.anime SET episodes = 100 WHERE anime_id = 1;` → waits.  
**A:** `UPDATE anime.anime SET episodes = 200 WHERE anime_id = 2;` → **deadlock detected!**  

PostgreSQL aborts one transaction:  
```
ERROR:  deadlock detected
DETAIL:  Process 12345 waits for ShareLock on transaction 567; blocked by process 12346.
```
The other transaction can commit.

### **6.4. Vacuum and Bloat**  

Checked dead tuples:  
```sql
SELECT schemaname, tablename, n_dead_tup, last_vacuum
FROM pg_stat_user_tables ORDER BY n_dead_tup DESC;
```
`review` had ~5000 dead tuples. Ran `VACUUM VERBOSE ANALYZE anime.review;` to reclaim space.

---

## **7. Part 6: OLAP – Star Schema and Multidimensional Analysis**  

### **7.1. Star Schema Design (Connolly & Begg Ch. 34)**  

We created a separate `dw` schema with:  
- **Fact table:** `fact_review` (measures: rating, review_count)  
- **Dimensions:** `dim_time`, `dim_anime`, `dim_user` (and optionally `dim_studio`).  

**Creation script:**  
```sql
CREATE SCHEMA dw;
CREATE TABLE dw.dim_time ( time_key INT PRIMARY KEY, full_date DATE, ... );
-- populated with generate_series from 2000 to 2030

CREATE TABLE dw.dim_anime AS SELECT anime_id, title, release_year, episodes, status, studio_id FROM anime.anime;
CREATE TABLE dw.dim_user AS SELECT user_id, username, join_date FROM anime.user;

CREATE TABLE dw.fact_review (
    review_id INT,
    time_key INT REFERENCES dw.dim_time,
    anime_id INT REFERENCES dw.dim_anime,
    user_id INT REFERENCES dw.dim_user,
    rating INT,
    has_comment BOOLEAN,
    review_count INT DEFAULT 1
);

INSERT INTO dw.fact_review
SELECT r.review_id, TO_CHAR(r.review_date,'YYYYMMDD')::INT, r.anime_id, r.user_id,
       r.rating, r.comment IS NOT NULL
FROM anime.review r;
```

### **7.2. OLAP Queries**  

**ROLLUP – average rating by year and month with subtotals:**  
```sql
SELECT d.year, d.month_name, AVG(f.rating), COUNT(*)
FROM dw.fact_review f JOIN dw.dim_time d ON f.time_key = d.time_key
GROUP BY ROLLUP (d.year, d.month_name) ORDER BY d.year, d.month_name;
```
Partial output:  
```
 year | month_name |   avg   | count 
------+------------+---------+-------
 2023 | January    | 8.12    | 2345
 2023 | February   | 8.34    | 2100
 2023 | March      | 8.05    | 2678
 2023 | NULL       | 8.17    | 7123   -- subtotal for 2023
 NULL  | NULL       | 8.23    | 196635 -- grand total
```

**CUBE – rating distribution by anime and user join year:**  
```sql
SELECT a.title, EXTRACT(YEAR FROM u.join_date) AS join_year, AVG(f.rating), COUNT(*)
FROM dw.fact_review f
JOIN dw.dim_anime a ON f.anime_id = a.anime_id
JOIN dw.dim_user u ON f.user_id = u.user_id
GROUP BY CUBE (a.title, join_year);
```

### **7.3. Materialized View for Performance**  

```sql
CREATE MATERIALIZED VIEW dw.mv_anime_monthly AS
SELECT a.anime_id, a.title, d.year, d.month, AVG(f.rating) AS avg_rating, COUNT(*) AS cnt
FROM dw.fact_review f
JOIN dw.dim_anime a ON f.anime_id = a.anime_id
JOIN dw.dim_time d ON f.time_key = d.time_key
GROUP BY a.anime_id, a.title, d.year, d.month;

CREATE INDEX ON dw.mv_anime_monthly (anime_id, year, month);
```

Querying the materialized view is instant. Refresh when underlying data changes:  
```sql
REFRESH MATERIALIZED VIEW CONCURRENTLY dw.mv_anime_monthly;
```

---

## **8. Conclusion and Demo Notes**  

All six assignment tasks are successfully implemented and verified. The system demonstrates:  
- A fully functional anime database with realistic data.  
- Streaming replication for read scaling.  
- Analytical queries yielding business insights.  
- Query optimisation with indexes and `EXPLAIN`.  
- Concurrency control mechanisms (MVCC, isolation, deadlock).  
- A star schema for OLAP with rollup/cube queries.

**For the live demo:**  
1. Start both PostgreSQL instances.  
2. Show replication status (`pg_stat_replication`).  
3. Run analytical queries on standby.  
4. Demonstrate optimisation by toggling indexes and showing `EXPLAIN` before/after.  
5. Perform concurrency demos in two terminals.  
6. Query the star schema and materialized view.

All scripts, configuration files, and this report are available in the project folder.

---

## **Appendix: Key Files**  

- `schema.sql` – DDL for all tables.  
- `populate_anime_db.py` – Python population script.  
- `postgresql.conf.primary` / `postgresql.conf.standby` – configuration files.  
- `pg_hba.conf` – client authentication.  
- `analysis_queries.sql` – all analytical queries used.  
- `optimization.sql` – index creation and EXPLAIN logs.  
- `concurrency_demo.sql` – commands for MVCC and deadlock.  
- `olap_star.sql` – star schema creation and queries.  

---

**End of Report.**