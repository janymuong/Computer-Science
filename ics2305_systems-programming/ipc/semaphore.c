#include <sys/sem.h>
#include <sys/ipc.h>
#include <stdio.h>

// Union for semaphore control
union semun {
    int val;
    struct semid_ds *buf;
    unsigned short *array;
};

int main() {
    key_t key = ftok("/tmp", 65);
    
    // Create semaphore set with one semaphore
    int semid = semget(key, 1, 0666 | IPC_CREAT);
    
    // Initialize semaphore
    union semun sem_union;
    sem_union.val = 1;  // Initial value: resource available
    semctl(semid, 0, SETVAL, sem_union);

    // Semaphore wait operation (P operation)
    struct sembuf sem_wait = {0, -1, 0};
    
    // Semaphore signal operation (V operation)
    struct sembuf sem_signal = {0, 1, 0};

    // Wait for resource
    semop(semid, &sem_wait, 1);
    
    // Critical section - exclusive access
    printf("Entering critical section\n");
    
    // Release resource
    semop(semid, &sem_signal, 1);

    return 0;
}
