/* Jany Muong SCT211-0848/2018 */

/* header files for system calls to use; */

#include <stdlib.h> /* needed to define exit() */
#include <stdlib.h> /* for exit */
#include <unistd.h> /* needed to define getpid() */ 
#include <stdio.h> /* needed for printf() */ 


int main(int argc, char **argv) 
{
	/* display to stdout PID of process */
	printf("My process ID is %d\n", getpid());
	exit(0); 
}
