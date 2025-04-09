// Jany Muong SCT211-0848/2018

#include <stdio.h>       // for printf()
#include <unistd.h>      // for exec functions and fork()
#include <sys/types.h>   // needed for pid_t
#include <stdlib.h>      // needed for exit()
#include <sys/wait.h>    // wait() on child proceses


/**
* main - entry point
 * this program demonstrates the usage of various exec family functions
 * by forking a process to ping google.com using different exec calls.
 */

int main(int argc, char *argv[], char *envp[])
{
    pid_t pid;  // unique ID of the process

    // using execlp() to ping google.com
    printf("Example 1: execlp() - ping google.com\n");
    pid = fork(); // create a first process
    if (pid == 0) {
        execlp("ping", "ping", "-c", "4", "google.com", NULL); // ping google.com 4 times
        perror("execlp failed"); // print error if execlp fails
        exit(EXIT_FAILURE);
    }

    // execle() to ping google.com
    printf("Example 2: execle() - ping google.com\n");
    pid = fork(); // make another process
    if (pid == 0) {
        char *envp[] = { "PATH=/bin", NULL }; // custom environment
        execle("/bin/ping", "ping", "-c", "4", "google.com", NULL, envp); // ping google.com 4 times
        perror("execle failed"); // print error if execle fails
        exit(EXIT_FAILURE);
    }

    // execv() to ping google.com
    printf("Example 3: Using execv() to ping google.com\n");
    pid = fork(); // create another process
    if (pid == 0) {
        char *args1[] = { "ping", "-c", "4", "google.com", NULL }; // Arguments array
        execv("/bin/ping", args1); // execute ping command
        perror("execv failed"); // print error if execv fails
        exit(EXIT_FAILURE);
    }

    // execvp() to ping google.com
    printf("Example 4: Using execvp() to ping google.com\n");
    pid = fork(); // make a process
    if (pid == 0) {
        char *args2[] = { "ping", "-c", "4", "google.com", NULL }; // arguments array
        execvp("ping", args2); // execute ping command
        perror("execvp failed"); // print error if execvp fails
        exit(EXIT_FAILURE);
    }

    // execve() to ping google.com
    printf("Example 5: Using execve() to ping google.com\n");
    pid = fork(); // make a process
    if (pid == 0) {
        char *args3[] = { "ping", "-c", "4", "google.com", NULL }; // Arguments array
        char *envp2[] = { "PATH=/bin", NULL };
        execve("/bin/ping", args3, envp2); // ping w/ execve
        perror("execve failed"); // print error if execve fails
        exit(EXIT_FAILURE);
    }

    // wait for all child processes to complete
    for (int i = 0; i < 5; i++) {
        wait(NULL); // wait for child processes
    }

    return (0); // exit the program - on success
}
