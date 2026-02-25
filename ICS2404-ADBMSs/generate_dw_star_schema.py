import psycopg2
import graphviz

conn = psycopg2.connect("dbname=db-name user=userwhatev")
cur = conn.cursor()

# get foreign key relationships
cur.execute("""
    SELECT
        tc.table_name, kcu.column_name,
        ccu.table_name AS foreign_table_name,
        ccu.column_name AS foreign_column_name
    FROM information_schema.table_constraints tc
    JOIN information_schema.key_column_usage kcu
        ON tc.constraint_name = kcu.constraint_name
    JOIN information_schema.constraint_column_usage ccu
        ON ccu.constraint_name = tc.constraint_name
    WHERE tc.constraint_type = 'FOREIGN KEY'
      AND tc.table_schema = 'dw'
""")
fk_rows = cur.fetchall()

dot = graphviz.Digraph(comment='Star Schema', format='png')
dot.attr(rankdir='LR')  # left-to-right layout

# add nodes for all tables in dw schema
cur.execute("SELECT table_name FROM information_schema.tables WHERE table_schema='dw'")
tables = [row[0] for row in cur.fetchall()]
for tbl in tables:
    dot.node(tbl, tbl, shape='box3d')

# add edges for foreign keys
for row in fk_rows:
    tbl, col, ftbl, fcol = row
    dot.edge(tbl, ftbl, label=f"{col} → {fcol}")

dot.render('star_schema', view=True)  # opens the image