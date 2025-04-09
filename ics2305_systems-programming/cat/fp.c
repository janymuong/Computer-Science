#include <stdio.h> 
int main() { 
FILE *fptr;

fptr = fopen("JKUAT.txt", "w"); // "w" defines "writing mode" /* write to file */ 
fputs("Computer Science in JKUAT rocks \n", fptr); 
fclose(fptr); 
return 0; 
}

