// Jany Muong SCT211-0848/2018

#include <stdio.h> // needed for input/output operations
#include <unistd.h> // needed for process creation/fork
#include <sys/types.h>
#include <errno.h> // header for error handling

#define LOOP 3

/**
 * this program demonstrates the use of the fork() system call to create child processes.
 * child process prints "Niko Juja" 3 times,
 * the parent process prints "ICS2305 ni softlife" 3 times.
 * the child process is not required to wait for the parent process to finish before printing its message.
 */

int main(int argc, char *argv[]) {
    pid_t pid = fork(); // make a child process

    if (pid == 0) { // Child process
        // print "Niko Juja"
        for (int i = 0; i < LOOP; i++) {
            printf("Niko Juja\n");
            sleep(5); // sleep for 5 second/shell
        }
    } else if (pid > 0) { // parent process
        // print "ICS2305 ni softlife"
        for (int i = 0; i < LOOP; i++) {
            printf("ICS2305 ni softlife\n");
            sleep(5); // shell sleep for 5 second
        }
    } else {
        // error handling for failed fork - log message to stderr
        perror("fork");
        return (1);
    }

    return (0);
}
