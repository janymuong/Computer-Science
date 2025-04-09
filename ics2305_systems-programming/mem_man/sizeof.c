#include <stdio.h>
#include <stdlib.h>


int myInt;
float myFloat;
double myDouble;
char myChar;

int main(int argc, char *argv[])
{
    printf("C Memory Management Built-In DTypes\n");
    printf("Size of int: %lu\n", sizeof(myInt));      // 4 bytes
    printf("Size of float: %lu\n", sizeof(myFloat));    // 4 bytes
    printf("Size of double: %lu\n", sizeof(myDouble));   // 8 bytes
    printf("Size of char: %lu\n", sizeof(myChar));     // 1 byte
    return (0);
}
