#!/bin/zsh
echo "=== Sequential C ==="
gcc matvec_seq.c -o matvec_seq
./matvec_seq

echo "=== Sequential Python ==="
python3 matvec_seq.py

echo "=== OpenMP (static & dynamic) ==="
gcc -fopenmp matvec_omp.c -o matvec_omp
export OMP_NUM_THREADS=2,4,8
./matvec_omp

echo "=== Python multiprocessing ==="
python3 matvec_mp.py