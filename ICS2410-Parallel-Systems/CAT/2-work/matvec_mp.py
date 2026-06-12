import multiprocessing as mp
import time
import sys

def worker_colwise(A_cols_block, x_block, result_queue, worker_id):
    """
    A_cols_block: list of column lists (each column is a list of n elements)
    x_block: list of vector entries corresponding to those columns
    result_queue: queue to send back partial result (list of length n)
    """
    n_rows = len(A_cols_block[0]) if A_cols_block else 0
    partial = [0.0] * n_rows
    for col_idx, col in enumerate(A_cols_block):
        x_val = x_block[col_idx]
        for row in range(n_rows):
            partial[row] += col[row] * x_val
    result_queue.put((worker_id, partial))

def mat_vec_mul_mp(A, x, num_processes):
    n = len(A)
    # convert matrix to column-major: list of columns
    columns = [[A[row][col] for row in range(n)] for col in range(n)]
    
    # split columns and x among workers
    chunk_size = (n + num_processes - 1) // num_processes
    chunks = []
    for i in range(0, n, chunk_size):
        col_chunk = columns[i:i+chunk_size]
        x_chunk = x[i:i+chunk_size]
        chunks.append((col_chunk, x_chunk))
    
    # create queue and processes
    result_queue = mp.Queue()
    processes = []
    for pid, (col_chunk, x_chunk) in enumerate(chunks):
        if not col_chunk:
            continue
        p = mp.Process(target=worker_colwise, args=(col_chunk, x_chunk, result_queue, pid))
        processes.append(p)
        p.start()

    # collect results
    results = {}
    for _ in processes:
        wid, partial = result_queue.get()
        results[wid] = partial
    
    for p in processes:
        p.join()
    
    # aggregate partial results (addition elementwise)
    y = [0.0] * n
    for partial in results.values():
        for i in range(n):
            y[i] += partial[i]
    return y

if __name__ == "__main__":
    sizes = [100, 500, 1000]
    process_counts = [2, 4, 8]
    # Use a fixed matrix/vector of ones for correctness
    for n in sizes:
        A = [[1.0] * n for _ in range(n)]
        x = [1.0] * n
        
        # sequential baseline (already measured in obj1, but we include here for consistency)
        start_seq = time.time()
        y_seq = [sum(row) for row in A]  # because x=1 => each row sum = n
        end_seq = time.time()
        seq_time = end_seq - start_seq
    
        for p in process_counts:
            if p > n:
                print(f"Skipping n={n}, processes={p} (more processes than columns)")
                continue
            start = time.time()
            y_par = mat_vec_mul_mp(A, x, p)
            end = time.time()
            par_time = end - start
            speedup = seq_time / par_time if par_time > 0 else 0
            print(f"MP Python, size={n}, processes={p}, time={par_time:.6f} sec, speedup={speedup:.2f}")
            # quick verification
            assert all(abs(y_par[i] - n) < 1e-6 for i in range(n)), "Incorrect result"