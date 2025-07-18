-- Create users table
CREATE TABLE IF NOT EXISTS users (
    userid SERIAL PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL
);

-- Create activitylog table
CREATE TABLE IF NOT EXISTS activitylog (
    logid SERIAL PRIMARY KEY,
    userid INTEGER REFERENCES users (userid),
    activitytype VARCHAR(255) NOT NULL,
    duration INTEGER,
    met FLOAT,
    calories FLOAT
);

-- Create bodymeasurements table
CREATE TABLE IF NOT EXISTS bodymeasurements (
    id SERIAL PRIMARY KEY,
    userid INTEGER REFERENCES users (userid),
    height FLOAT NOT NULL,
    bodyweight FLOAT NOT NULL,
    bmi FLOAT
);

-- Create goalsprogress table
CREATE TABLE IF NOT EXISTS goalsprogress (
    goalid SERIAL PRIMARY KEY,
    userid INTEGER REFERENCES users (userid),
    goaldescription VARCHAR(255) NOT NULL,
    goalstatus VARCHAR(50) NOT NULL
);

-- Create feedback table
CREATE TABLE IF NOT EXISTS feedback (
    id SERIAL PRIMARY KEY,
    userid INTEGER REFERENCES users (userid),
    feedback_text TEXT NOT NULL,
    submitted_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
