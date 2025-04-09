#include <stdlib.h> 
#include <unistd.h> 
#include <stdio.h> 

/* first headefile - needed to define exit() 
* second, needed to define getpid() 
* third, needed for printf()
*/

int main(int argc, char **argv)
{
	printf("My process ID is %d\n", getpid());
	printf("my parent's process ID is %d\n", getppid());
	exit(0);
}
