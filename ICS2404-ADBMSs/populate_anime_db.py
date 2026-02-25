import psycopg2
from faker import Faker
import random

# peer authentication (user)
conn = psycopg2.connect(
    database="db_name",
    user="db_user"
)
cur = conn.cursor()
fake = Faker()

# Clear existing data and reset sequences
tables = ['watchlist', 'review', 'episode', 'character', 'anime_genre', 'anime', 'genre', 'studio', 'user']
for table in tables:
    cur.execute(f"TRUNCATE TABLE anime.{table} RESTART IDENTITY CASCADE;")
conn.commit()
print("Existing data cleared and sequences reset.")

# 1. Insert studios (real ones)
studios = [
    ('Wit Studio', 'Japan', 2012),
    ('MAPPA', 'Japan', 2011),
    ('Pierrot', 'Japan', 1979),
    ('Ufotable', 'Japan', 2000),
    ('Madhouse', 'Japan', 1972)
]
for studio in studios:
    cur.execute("INSERT INTO anime.studio (name, country, founded_year) VALUES (%s, %s, %s)", studio)
conn.commit()
print("Studios inserted.")

# Fetch studio IDs and create mapping name → id
cur.execute("SELECT studio_id, name FROM anime.studio")
studio_rows = cur.fetchall()
studio_map = {name: sid for sid, name in studio_rows}
studio_ids = [sid for sid, _ in studio_rows]

# 2. Insert genres
genres = ['Action', 'Adventure', 'Drama', 'Fantasy', 'Horror', 'Comedy', 'Romance', 'Sci-Fi', 'Slice of Life']
for genre in genres:
    cur.execute("INSERT INTO anime.genre (name) VALUES (%s)", (genre,))
conn.commit()
print("Genres inserted.")

# 3. Insert anime (favorites + random)
anime_list = [
    ('Attack on Titan', 'Humanity fights for survival against Titans.', 2013, 87, 'completed', studio_map['Wit Studio']),
    ('Jujutsu Kaisen', 'A boy joins a secret organization of sorcerers.', 2020, 24, 'ongoing', studio_map['MAPPA']),
    ('Naruto', 'A ninja aims to become the Hokage.', 2002, 220, 'completed', studio_map['Pierrot']),
    ('Naruto Shippuden', 'Continuation of Naruto.', 2007, 500, 'completed', studio_map['Pierrot']),
    ('Demon Slayer', 'A boy becomes a demon slayer to save his sister.', 2019, 26, 'completed', studio_map['Ufotable']),
    ('One Punch Man', 'A hero who can defeat anyone with one punch.', 2015, 12, 'completed', studio_map['Madhouse']),
]
# Add 20 random anime
for _ in range(20):
    title = fake.catch_phrase()
    year = random.randint(2000, 2024)
    eps = random.randint(12, 100)
    status = random.choice(['ongoing', 'completed', 'hiatus'])
    studio_id = random.choice(studio_ids)
    anime_list.append((title, fake.text(100), year, eps, status, studio_id))

for anime in anime_list:
    cur.execute("""
        INSERT INTO anime.anime (title, description, release_year, episodes, status, studio_id)
        VALUES (%s, %s, %s, %s, %s, %s)
    """, anime)
conn.commit()
print(f"{len(anime_list)} anime inserted.")

# Fetch anime IDs for later use
cur.execute("SELECT anime_id FROM anime.anime")
anime_ids = [row[0] for row in cur.fetchall()]

# 4. Assign genres to anime (many-to-many)
cur.execute("SELECT genre_id FROM anime.genre")
genre_ids = [row[0] for row in cur.fetchall()]
for aid in anime_ids:
    # each anime gets 1-3 random genres
    selected_genres = random.sample(genre_ids, random.randint(1, min(3, len(genre_ids))))
    for gid in selected_genres:
        cur.execute("INSERT INTO anime.anime_genre (anime_id, genre_id) VALUES (%s, %s)", (aid, gid))
conn.commit()
print("Anime-genre relationships inserted.")

# 5. Insert characters (real + random)
characters = [
    ('Eren Yeager', 'protagonist', 'Main character of Attack on Titan', anime_list[0][0] if isinstance(anime_list[0][0], int) else 'need ID'),
    ('Mikasa Ackerman', 'supporting', 'Eren\'s adoptive sister', anime_list[0][0]),
    ('Levi Ackerman', 'supporting', 'Humanity\'s strongest soldier', anime_list[0][0]),
    ('Yuji Itadori', 'protagonist', 'Main character of Jujutsu Kaisen', anime_list[1][0]),
    ('Satoru Gojo', 'supporting', 'Powerful jujutsu sorcerer', anime_list[1][0]),
    ('Naruto Uzumaki', 'protagonist', 'Main character of Naruto', anime_list[2][0]),
    ('Sasuke Uchiha', 'antagonist', 'Rival of Naruto', anime_list[2][0]),
]
# Fix: use actual anime IDs from the database, not the list positions
# We need to get the IDs for the specific titles. Simpler: fetch again after insertion.
# Let's fetch a mapping of title to anime_id after insertion.
cur.execute("SELECT anime_id, title FROM anime.anime")
anime_title_map = {title: aid for aid, title in cur.fetchall()}

# Rebuild characters with correct IDs
characters = [
    ('Eren Yeager', 'protagonist', 'Main character of Attack on Titan', anime_title_map['Attack on Titan']),
    ('Mikasa Ackerman', 'supporting', 'Eren\'s adoptive sister', anime_title_map['Attack on Titan']),
    ('Levi Ackerman', 'supporting', 'Humanity\'s strongest soldier', anime_title_map['Attack on Titan']),
    ('Yuji Itadori', 'protagonist', 'Main character of Jujutsu Kaisen', anime_title_map['Jujutsu Kaisen']),
    ('Satoru Gojo', 'supporting', 'Powerful jujutsu sorcerer', anime_title_map['Jujutsu Kaisen']),
    ('Naruto Uzumaki', 'protagonist', 'Main character of Naruto', anime_title_map['Naruto']),
    ('Sasuke Uchiha', 'antagonist', 'Rival of Naruto', anime_title_map['Naruto']),
]
# Add 100 random characters
for _ in range(100):
    name = fake.name()
    role = random.choice(['protagonist', 'antagonist', 'supporting', 'other'])
    desc = fake.sentence()
    aid = random.choice(anime_ids)
    characters.append((name, role, desc, aid))

for ch in characters:
    cur.execute("""
        INSERT INTO anime.character (name, role, description, anime_id)
        VALUES (%s, %s, %s, %s)
    """, ch)
conn.commit()
print(f"{len(characters)} characters inserted.")

# 6. Insert episodes for each anime
for aid in anime_ids:
    cur.execute("SELECT episodes FROM anime.anime WHERE anime_id = %s", (aid,))
    eps_count = cur.fetchone()[0]
    if eps_count is None:
        eps_count = random.randint(12, 50)
    for ep_num in range(1, eps_count + 1):
        air_date = fake.date_between(start_date='-10y', end_date='today')
        title = f"Episode {ep_num}: {fake.sentence(nb_words=4)}"
        cur.execute("""
            INSERT INTO anime.episode (anime_id, episode_number, title, air_date)
            VALUES (%s, %s, %s, %s)
        """, (aid, ep_num, title, air_date))
    if eps_count % 100 == 0:
        conn.commit()
conn.commit()
print("Episodes inserted.")

# 7. Insert users (10,000) – with duplicate handling
print("Inserting 10,000 users (this may take a moment)...")
user_count = 0
while user_count < 10000:
    username = fake.user_name() + str(random.randint(1000, 9999))  # extra randomness
    email = fake.email()
    join_date = fake.date_between(start_date='-5y', end_date='today')
    try:
        cur.execute("INSERT INTO anime.user (username, email, join_date) VALUES (%s, %s, %s)",
                    (username, email, join_date))
        user_count += 1
        if user_count % 1000 == 0:
            conn.commit()
            print(f"  {user_count} users inserted...")
    except psycopg2.IntegrityError:
        conn.rollback()  # duplicate, just skip and retry
        continue
conn.commit()
print(f"{user_count} users inserted.")

# Get user IDs for later use
cur.execute("SELECT user_id FROM anime.user")
user_ids = [row[0] for row in cur.fetchall()]

# 8. Insert reviews (200,000)
print("Inserting 200,000 reviews...")
review_count = 0
for i in range(200000):
    uid = random.choice(user_ids)
    aid = random.choice(anime_ids)
    rating = random.randint(1, 10)
    comment = fake.sentence() if random.random() > 0.3 else None
    review_date = fake.date_time_between(start_date='-3y', end_date='now')
    try:
        cur.execute("""
            INSERT INTO anime.review (user_id, anime_id, rating, comment, review_date)
            VALUES (%s, %s, %s, %s, %s)
        """, (uid, aid, rating, comment, review_date))
        review_count += 1
    except psycopg2.IntegrityError:
        conn.rollback()  # duplicate review (user already reviewed this anime)
        continue
    if i % 10000 == 0 and i > 0:
        conn.commit()
        print(f"  {i} attempts processed, {review_count} reviews inserted...")
conn.commit()
print(f"{review_count} reviews inserted.")

# 9. Insert watchlist entries (300,000)
print("Inserting 300,000 watchlist entries...")
watch_count = 0
for i in range(300000):
    uid = random.choice(user_ids)
    aid = random.choice(anime_ids)
    status = random.choice(['watching', 'completed', 'plan_to_watch', 'dropped'])
    progress = 0
    if status == 'watching':
        progress = random.randint(1, 20)
    elif status == 'completed':
        cur.execute("SELECT episodes FROM anime.anime WHERE anime_id = %s", (aid,))
        eps = cur.fetchone()[0]
        progress = eps if eps else 24
    added_date = fake.date_time_between(start_date='-2y', end_date='now')
    try:
        cur.execute("""
            INSERT INTO anime.watchlist (user_id, anime_id, status, progress, added_date)
            VALUES (%s, %s, %s, %s, %s)
        """, (uid, aid, status, progress, added_date))
        watch_count += 1
    except psycopg2.IntegrityError:
        conn.rollback()
        continue
    if i % 50000 == 0 and i > 0:
        conn.commit()
        print(f"  {i} attempts processed, {watch_count} entries inserted...")
conn.commit()
print(f"{watch_count} watchlist entries inserted.")

print("psssst! db is populated w/ anime goodness :)")
cur.close()
conn.close()