import time

def mat_vec_mul_seq(A, x):
    n = len(A)
    y = [0.0] * n
    for i in range(n):
        total = 0.0
        for j in range(n):
            total += A[i][j] * x[j]
        y[i] = total
    return y

if __name__ == "__main__":
    sizes = [100, 500, 1000]
    for n in sizes:
        A = [[1.0] * n for _ in range(n)]
        x = [1.0] * n

        start = time.time()
        y = mat_vec_mul_seq(A, x)
        end = time.time()

        print(f"Sequential Python, size={n}, time={end-start:.6f} sec")
