/* Jany Muong SCT211-0848/2018 */

#include <stdio.h> /* needed for printf() and main */ 
#include <stdlib.h> /* for exit */
#include <unistd.h> /* needed to define getpid() */
#include <sys/types.h>

/**
* this C program creates/duplicates processes using fork;
*/

int main(int argc, char *argv[])
{
    int c = 5;
    pid_t pid = fork(); // get process ID from fork first fork syscall

    if (pid == 0)
    {
        c += 5;
    } else 
    {
        pid = fork(); // fork on condition we get a non - success from first
        c += 10;
        
        if (pid) {
            c += 10;
        }
    }

    fork(); // second fork 

    // print out to stdout the value of character c;
    printf("%d\n", c);


    return (0);
}