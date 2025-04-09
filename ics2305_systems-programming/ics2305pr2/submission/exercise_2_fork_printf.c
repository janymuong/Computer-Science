/* Jany Muong SCT211-0848/2018 */

/** not all of these files are used in system calls 
* each header file will be used as needed
* thougt I put all of them here for convenience
*/

#include <stdio.h> /* needed for printf() and main */ 
// #include <stdlib.h> /* for exit */
#include <unistd.h> /* needed to define getpid() */
// #include <sys/types.h>

/** Exercise fork and printf;
* this C program creates multiple/duplicates processes using fork;
*/


int main(int argc,char *argv[])
{
    printf("X\n");
    fork();
    printf("Y\n");
    fork();
    printf("Z\n");

    return (0); 
} 
