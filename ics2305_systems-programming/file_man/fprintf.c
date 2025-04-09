#include <stdio.h> 
int main()
{ 
    FILE *fptr;
    fptr = fopen("JKUAT.txt", "w"); // "w" defines "writing mode"
    /* write to file */ 
    fprintf(fptr, "Computer Science in JKUAT rocks \n"); 
    fclose(fptr); 
    return 0; 
}
