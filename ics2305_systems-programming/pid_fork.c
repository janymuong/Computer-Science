#include <stdio.h>
#include <unistd.h>

int main()
{
	int pid;
	printf("Before Fork\n");

	pid = fork();
	if (pid == 0)
	{
		printf("Child process\n");
	}
	else {
		printf("Parent process\n");
	}
	return 0;
}
