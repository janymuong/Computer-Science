#include <stdio.h>
#include <stdlib.h>

int main()
{
	int i;
	FILE *fptr;
	char fn[50];
	char str[] = "Masomo yetu\n";
	fptr = fopen("ICS2305.txt", "w"); // "w" defines "writing mode"
	
	printf("WRITE To File Operation :)\n");
	printf("ICS2305.txt\n");
	for (i = 0; str[i] != '\n'; i++)
	{
		/* write to file using fputc() function */
		fputc(str[i], fptr);
	}
	fclose(fptr);
	return (0); 
}
