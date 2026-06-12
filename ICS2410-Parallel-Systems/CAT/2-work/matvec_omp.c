#include <stdio.h>
#include <stdlib.h>
#include <omp.h>

double* create_matrix(int n) {
    double* A = (double*)malloc(n * n * sizeof(double));
    for (int i = 0; i < n * n; i++) A[i] = 1.0;
    return A;
}

double* create_vector(int n) {
    double* x = (double*)malloc(n * sizeof(double));
    for (int i = 0; i < n; i++) x[i] = 1.0;
    return x;
}

void mat_vec_mul_omp(double* A, double* x, double* y, int n, int num_threads, int schedule_type) {
    omp_set_num_threads(num_threads);
    #pragma omp parallel for schedule(runtime)
    for (int i = 0; i < n; i++) {
        double sum = 0.0;
        for (int j = 0; j < n; j++) {
            sum += A[i * n + j] * x[j];
        }
        y[i] = sum;
    }
}

int main(int argc, char* argv[]) {
    int sizes[] = {100, 500, 1000};
    int thread_counts[] = {2, 4, 8};
    char* schedule_names[] = {"static", "dynamic"};

    for (int s = 0; s < 3; s++) {
        int n = sizes[s];
        double* A = create_matrix(n);
        double* x = create_vector(n);
        double* y = (double*)calloc(n, sizeof(double));

        for (int t = 0; t < 2; t++) { // schedule types
            for (int thr = 0; thr < 3; thr++) {
                int num_threads = thread_counts[thr];
                omp_set_schedule(t == 0 ? omp_sched_static : omp_sched_dynamic, 0);

                double start = omp_get_wtime();
                mat_vec_mul_omp(A, x, y, n, num_threads, t);
                double end = omp_get_wtime();

                printf("OMP size=%d threads=%d schedule=%s time=%.6f sec\n",
                       n, num_threads, schedule_names[t], end - start);
            }
        }
        free(A); free(x); free(y);
    }
    return 0;
}
