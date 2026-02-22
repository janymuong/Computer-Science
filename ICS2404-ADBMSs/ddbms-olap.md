---

---
## datawarehousing + olap (for shows)
### *this is a snowflake schema setup*

### **overview**
we transformed the operational anime database into a **snowflake schema** to support analytical queries and decision‑making. this design separates **facts** (review measurements) from **dimensions** (context: time, anime, user, genre), enabling fast aggregations, drill‑downs, and trend analysis. the genre dimension is normalized to avoid repeating genre names across anime – a  snowflake pattern.

### **schema structure**

#### **fact table – `fact_review`**
- **measures**: `rating`, `review_count`, `has_comment`
- **foreign keys**: `time_key`, `anime_key`, `user_key`

#### **dimension tables**
- `dim_time`: date hierarchy (year, quarter, month, day, etc.) – **denormalized** (star).
- `dim_anime`: anime attributes (`title`, `release_year`, `episodes`, `studio_name`) – **denormalized** (star).
- `dim_user`: user attributes (`username`, `join_date`, derived `join_year`, `join_month`) – **denormalized** (star).
- `dim_genre`: genre names – **normalized** (snowflake).
- `bridge_anime_genre`: many‑to‑many relationship between anime and genre (snowflake).

> **why snowflake?**  
> a pure star schema would embed genre names directly into `dim_anime` (e.g., as an array or concatenated string). but, precisely because an anime can have multiple genres and we wanted to maintain a clean, `normalized` structure for the genre dimension, we introduced a bridge table. 
> **NOTE**: this avoids data redundancy and allows genre‑centric analysis without duplication. the trade‑off is additional joins, but with proper indexing the performance impact is minimal.

### **steps**

1. **create dimension tables** (ddl with appropriate keys).
2. **populate dimensions** from operational tables (`anime.anime`, `anime.user`, `anime.genre`, etc.).
3. **create fact table** and load it from `anime.review`, joining dimension keys.
4. **add indexes** on foreign keys and frequently queried columns.
5. **build materialized views** for pre‑aggregated summaries:
   - `mv_anime_monthly`: review count and average rating per anime per month.
   - `mv_genre_trends`: review count per genre per quarter.

### 1 - schema + tables(facts and dimension tables)
```sql
-- create warehouse schema
CREATE SCHEMA dw;

-- DIMENSION: time (with proper hierarchy)
CREATE TABLE dw.dim_time (
    time_key INTEGER PRIMARY KEY,
    full_date DATE UNIQUE NOT NULL,
    year INTEGER,
    quarter INTEGER,
    quarter_name VARCHAR(10),
    month INTEGER,
    month_name VARCHAR(20),
    week INTEGER,
    day_of_week INTEGER,
    day_name VARCHAR(20),
    is_weekend BOOLEAN,
    -- For OLAP drill-down: year → quarter → month → day
    CONSTRAINT valid_date CHECK (full_date IS NOT NULL)
);

-- Populate 20 years of dates (2000-2020, covers all review data)
INSERT INTO dw.dim_time
SELECT 
    TO_CHAR(d, 'YYYYMMDD')::INTEGER,
    d,
    EXTRACT(YEAR FROM d),
    EXTRACT(QUARTER FROM d),
    'Q' || EXTRACT(QUARTER FROM d),
    EXTRACT(MONTH FROM d),
    TO_CHAR(d, 'Month'),
    EXTRACT(WEEK FROM d),
    EXTRACT(DOW FROM d),
    TO_CHAR(d, 'Day'),
    EXTRACT(DOW FROM d) IN (0, 6)
FROM generate_series('2000-01-01'::date, '2030-12-31'::date, '1 day') d;

-- DIMENSION: anime (with slowly changing dimension support)
CREATE TABLE dw.dim_anime (
    anime_key SERIAL PRIMARY KEY,
    anime_id INTEGER,                    -- Natural key from source
    title VARCHAR(200) NOT NULL,
    release_year INTEGER,
    episodes INTEGER,
    status VARCHAR(20),
    studio_name VARCHAR(100),
    studio_country VARCHAR(50),
    -- SCD Type 2 columns (for tracking changes)
    valid_from DATE DEFAULT '1900-01-01',
    valid_to DATE DEFAULT '9999-12-31',
    is_current BOOLEAN DEFAULT true,
    -- Metadata
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Populate anime dimension (initial load)
INSERT INTO dw.dim_anime (anime_id, title, release_year, episodes, status, studio_name, studio_country)
SELECT 
    a.anime_id,
    a.title,
    a.release_year,
    a.episodes,
    a.status,
    s.name,
    s.country
FROM anime.anime a
LEFT JOIN anime.studio s ON a.studio_id = s.studio_id;

-- DIMENSION: user
CREATE TABLE dw.dim_user (
    user_key SERIAL PRIMARY KEY,
    user_id INTEGER UNIQUE,
    username VARCHAR(50),
    join_date DATE,
    join_year INTEGER,
    join_month INTEGER
    -- account_age_days can be computed in a view or query
);

INSERT INTO dw.dim_user (user_id, username, join_date, join_year, join_month)
SELECT 
    user_id,
    username,
    join_date,
    EXTRACT(YEAR FROM join_date),
    EXTRACT(MONTH FROM join_date)
FROM anime.user;

-- ## **view  for `dim_user`**


create a view for: `account_age_days` 

CREATE VIEW dw.v_dim_user_with_age AS
SELECT *, (CURRENT_DATE - join_date) AS account_age_days
FROM dw.dim_user;




-- DIMENSION: genre (for multi-valued dimensions, we use a bridge table)
CREATE TABLE dw.dim_genre (
    genre_key SERIAL PRIMARY KEY,
    genre_name VARCHAR(50) UNIQUE
);

INSERT INTO dw.dim_genre (genre_name) SELECT name FROM anime.genre;

-- Bridge table for anime-genre (handles many-to-many)
CREATE TABLE dw.bridge_anime_genre (
    anime_key INTEGER REFERENCES dw.dim_anime(anime_key),
    genre_key INTEGER REFERENCES dw.dim_genre(genre_key),
    PRIMARY KEY (anime_key, genre_key)
);

-- Populate bridge table
INSERT INTO dw.bridge_anime_genre (anime_key, genre_key)
SELECT da.anime_key, dg.genre_key
FROM anime.anime_genre ag
JOIN dw.dim_anime da ON ag.anime_id = da.anime_id
JOIN dw.dim_genre dg ON ag.genre_id = dg.genre_key;   -- genre_key = genre_id here because we inserted in same order

-- FACT TABLE: reviews (with degenerate dimensions where appropriate)
CREATE TABLE dw.fact_review (
    review_key BIGSERIAL PRIMARY KEY,
    review_id INTEGER,                    -- degenerate dimension
    time_key INTEGER REFERENCES dw.dim_time(time_key),
    user_key INTEGER REFERENCES dw.dim_user(user_key),
    anime_key INTEGER REFERENCES dw.dim_anime(anime_key),
    rating INTEGER NOT NULL,
    has_comment BOOLEAN,
    -- Measures
    review_count INTEGER DEFAULT 1,        -- always 1, for counting
    rating_sum INTEGER,                    -- same as rating, for weighted averages
    loaded_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Populate fact table
INSERT INTO dw.fact_review (review_id, time_key, user_key, anime_key, rating, has_comment, rating_sum)
SELECT 
    r.review_id,
    TO_CHAR(r.review_date, 'YYYYMMDD')::INTEGER,
    du.user_key,
    da.anime_key,
    r.rating,
    r.comment IS NOT NULL,
    r.rating
FROM anime.review r
JOIN dw.dim_user du ON r.user_id = du.user_id
JOIN dw.dim_anime da ON r.anime_id = da.anime_id;

```

### 2- create indexes for fact-review table
> optimization
```sql
CREATE INDEX idx_fact_time ON dw.fact_review(time_key);
CREATE INDEX idx_fact_anime ON dw.fact_review(anime_key);
CREATE INDEX idx_fact_user ON dw.fact_review(user_key);
CREATE INDEX idx_fact_rating ON dw.fact_review(rating);
```
### **3 -  create materialized views for common aggregations**

```sql
-- Monthly anime performance
CREATE MATERIALIZED VIEW dw.mv_anime_monthly AS
SELECT 
    da.anime_key,
    da.title,
    dt.year,
    dt.month,
    dt.month_name,
    COUNT(fr.review_key) AS review_count,
    AVG(fr.rating) AS avg_rating,
    SUM(fr.rating_sum) AS rating_total,
    COUNT(DISTINCT fr.user_key) AS unique_reviewers
FROM dw.fact_review fr
JOIN dw.dim_anime da ON fr.anime_key = da.anime_key
JOIN dw.dim_time dt ON fr.time_key = dt.time_key
GROUP BY da.anime_key, da.title, dt.year, dt.month, dt.month_name;

CREATE UNIQUE INDEX idx_mv_anime_monthly ON dw.mv_anime_monthly (anime_key, year, month);

-- Genre popularity over time
CREATE MATERIALIZED VIEW dw.mv_genre_trends AS
SELECT 
    dg.genre_name,
    dt.year,
    dt.quarter,
    COUNT(fr.review_key) AS review_count,
    AVG(fr.rating) AS avg_rating
FROM dw.fact_review fr
JOIN dw.bridge_anime_genre bag ON fr.anime_key = bag.anime_key
JOIN dw.dim_genre dg ON bag.genre_key = dg.genre_key
JOIN dw.dim_time dt ON fr.time_key = dt.time_key
GROUP BY dg.genre_name, dt.year, dt.quarter;

CREATE INDEX idx_mv_genre_trends ON dw.mv_genre_trends (year, genre_name);

-- refresh views periodically (after data loads)
REFRESH MATERIALIZED VIEW CONCURRENTLY dw.mv_anime_monthly;
REFRESH MATERIALIZED VIEW CONCURRENTLY dw.mv_genre_trends;
```

### **4 - olap queries for  dashboards**
> used as dataset sources in jupyter lab:

```sql
-- 1. time Series: Monthly review volume and average rating
SELECT 
    dt.year,
    dt.month_name,
    COUNT(fr.review_key) AS review_count,
    AVG(fr.rating) AS avg_rating,
    COUNT(DISTINCT fr.user_key) AS active_users
FROM dw.fact_review fr
JOIN dw.dim_time dt ON fr.time_key = dt.time_key
GROUP BY dt.year, dt.month, dt.month_name
ORDER BY dt.year, dt.month;

-- 2. top anime by rating (with genre breakdown)
SELECT 
    da.title,
    STRING_AGG(DISTINCT dg.genre_name, ', ') AS genres,
    COUNT(fr.review_key) AS reviews,
    AVG(fr.rating) AS avg_rating,
    SUM(fr.rating_sum) AS total_rating_points
FROM dw.fact_review fr
JOIN dw.dim_anime da ON fr.anime_key = da.anime_key
LEFT JOIN dw.bridge_anime_genre bag ON da.anime_key = bag.anime_key
LEFT JOIN dw.dim_genre dg ON bag.genre_key = dg.genre_key
GROUP BY da.anime_key, da.title
HAVING COUNT(fr.review_key) >= 10
ORDER BY avg_rating DESC
LIMIT 20;

-- 3. user cohort analysis: join year vs. rating behavior
SELECT 
    du.join_year,
    AVG(fr.rating) AS avg_rating_given,
    COUNT(DISTINCT du.user_key) AS users_in_cohort,
    COUNT(fr.review_key) AS total_reviews
FROM dw.fact_review fr
JOIN dw.dim_user du ON fr.user_key = du.user_key
GROUP BY du.join_year
ORDER BY du.join_year;

-- 4. ROLLUP: rating by year and genre (OLAP cube style)
SELECT 
    dt.year,
    dg.genre_name,
    COUNT(fr.review_key) AS review_count,
    AVG(fr.rating) AS avg_rating
FROM dw.fact_review fr
JOIN dw.dim_time dt ON fr.time_key = dt.time_key
JOIN dw.bridge_anime_genre bag ON fr.anime_key = bag.anime_key
JOIN dw.dim_genre dg ON bag.genre_key = dg.genre_key
GROUP BY ROLLUP (dt.year, dg.genre_name)
ORDER BY dt.year, dg.genre_name;
```


## **5 - olap queries for visualization**
### **olap operations**

these queries extract the data that you will plot with matplotlib(run in notebook).

### **query 1: time series of reviews (monthly)**
>  
>  **rOLLUP – average rating by year and month with subtotals**
>  
```sql
SELECT 
    dt.year,
    dt.month,
    dt.month_name,
    COUNT(fr.review_key) AS review_count,
    AVG(fr.rating) AS avg_rating
FROM dw.fact_review fr
JOIN dw.dim_time dt ON fr.time_key = dt.time_key
GROUP BY dt.year, dt.month, dt.month_name
ORDER BY dt.year, dt.month;
```

### **query 2: top 10 anime by average rating (with at least 10 reviews)**
```sql
SELECT 
    da.title,
    COUNT(fr.review_key) AS review_count,
    AVG(fr.rating) AS avg_rating
FROM dw.fact_review fr
JOIN dw.dim_anime da ON fr.anime_key = da.anime_key
GROUP BY da.anime_key, da.title
HAVING COUNT(fr.review_key) >= 10
ORDER BY avg_rating DESC
LIMIT 10;
```

### **query 3: rating distribution  - gets me a histogram**
```sql
SELECT 
    rating,
    COUNT(*) AS frequency
FROM dw.fact_review
GROUP BY rating
ORDER BY rating;
```


#### **CUBE – rating distribution by anime and user join year**
```sql
SELECT 
    a.title,
    EXTRACT(YEAR FROM u.join_date) AS user_join_year,
    AVG(f.rating) AS avg_rating,
    COUNT(f.review_id) AS reviews
FROM dw.fact_review f
JOIN dw.dim_anime a ON f.anime_id = a.anime_id
JOIN dw.dim_user u ON f.user_id = u.user_id
GROUP BY CUBE (a.title, user_join_year)
ORDER BY a.title, user_join_year;
```

### **query 4: genre popularity (review count per genre)**
```sql
SELECT 
    dg.genre_name,
    COUNT(fr.review_key) AS review_count
FROM dw.fact_review fr
JOIN dw.bridge_anime_genre bag ON fr.anime_key = bag.anime_key
JOIN dw.dim_genre dg ON bag.genre_key = dg.genre_key
GROUP BY dg.genre_name
ORDER BY review_count DESC;
```

---
#### tools: matplotlib pandas psycopg2-binary sqlalchemy


