#include <stdio.h>
#include <stdlib.h> // For malloc()

int a = 5; // Stored in data section
int b[20]; // Stored in bss
const char *hello = "Hello world"; // Stored in read-only data

int main() { // Stored in text section
    int x; // Stored in stack
    int *p = (int*) malloc(sizeof(int)); // Stored in heap

    // Corrected printf statements
    printf("(Data) &a=0x%p\n", (void*)&a);         // Data section
    printf("(Bss) &b[0]=0x%p\n", (void*)&b[0]);    // BSS section
    printf("(Stack) &x=0x%p\n", (void*)&x);        // Stack section
    printf("(Heap) p=0x%p\n", (void*)p);           // Heap section
    printf("(ROData) Hello=0x%p\n", (void*)hello); // Read-only data
    printf("(TEXT) main=0x%p\n", (void*)main);     // Text section

    free(p); // Free allocated memory
    return 0;
}

