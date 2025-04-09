#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <unistd.h>
#include <sys/wait.h>
#include <errno.h>

int main (int argc, char *argv[])
{
	int arr[] = {1, 2, 3, 4, 1, 2, 7, 7};
	int arr_size = sizeof(arr) / sizeof(int);
	int start, end;
	int fd[2]; // fd[0] - read, fd[1] - write
	
	if (pipe(fd) == -1)
	{
		return (1);
	}
	int f_id;
	f_id = fork();
	if (f_id == -1)
	{
		return (2);
	}
	if (f_id == 0)
	{
		start = 0;
		end = arr_size / 2;

	} else
	{
		start = arr_size / 2;
		end = arr_size;
	}

	int arr_sum = 0;

	int i = start;
	for (; i < end; i++)
	{
		arr_sum += arr[i];
	}
	printf("sum partial: %d\n", arr_sum);

	if (f_id == 0){
		close(fd[0]);
		write(fd[1], &arr_sum, sizeof(arr_sum));
		close(fd[1]);
	}
	else
	{
		int sum_from_child;
		close(fd[1]);
		read(fd[0], &sum_from_child, sizeof(sum_from_child));
		close(fd[0]);
	}
	return (0);
}
