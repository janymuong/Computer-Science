#include <stdio.h>
#include <stdlib.h>
#include <time.h>

double* create_matrix(int n) {
    double* A = (double*)malloc(n * n * sizeof(double));
    for (int i = 0; i < n * n; i++) A[i] = 1.0; // simple test values
    return A;
}

double* create_vector(int n) {
    double* x = (double*)malloc(n * sizeof(double));
    for (int i = 0; i < n; i++) x[i] = 1.0;
    return x;
}

void mat_vec_mul_seq(double* A, double* x, double* y, int n) {
    for (int i = 0; i < n; i++) {
        y[i] = 0.0;
        for (int j = 0; j < n; j++) {
            y[i] += A[i * n + j] * x[j];
        }
    }
}

int main() {
    int sizes[] = {100, 500, 1000};
    for (int s = 0; s < 3; s++) {
        int n = sizes[s];
        double* A = create_matrix(n);
        double* x = create_vector(n);
        double* y = (double*)calloc(n, sizeof(double));

        clock_t start = clock();
        mat_vec_mul_seq(A, x, y, n);
        clock_t end = clock();

        double time_taken = (double)(end - start) / CLOCKS_PER_SEC;
        printf("Sequential C, size=%d, time=%.6f sec\n", n, time_taken);

        free(A); free(x); free(y);
    }
    return 0;
}
