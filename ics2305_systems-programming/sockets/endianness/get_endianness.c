#include <stdio.h>

/**
 * get_endianness - checks the endiannes
 *
 * Return: 0 if big endian, 1 if little endian.
 */
 int main() {
	char uint_endiannes;
	char *ptr;

	uint_endiannes = 1;
	ptr = (char *)&uint_endiannes;

	/* Little Endian */
	if (*ptr)
	{
        printf("Little-Endian\n");
	}
    else
		printf("Big-Endian\n");
	return (0);
}

// #include "main.h"

// /**
//  * get_endianness - checks the endiannes
//  *
//  * Return: 0 if big endian, 1 if little endian.
//  */
// int get_endianness(void)
// {
// 	char uint_endiannes;
// 	char *ptr;

// 	uint_endiannes = 1;
// 	ptr = &uint_endiannes;

// 	/* Little Endian */
// 	if (*ptr != 0)
// 	{
// 		return (1);
// 	}
// 	return (0);
// }