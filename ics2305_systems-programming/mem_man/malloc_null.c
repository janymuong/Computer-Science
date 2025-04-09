#include<stdio.h>
#include<stdlib.h>
int main(void)
{
    int *piBuffer = NULL;
    int n = 10, i = 0;
    //creating integer of size n.
    piBuffer = malloc(n * sizeof(int));
    //make sure piBuffer is valid or not
    if (piBuffer == NULL)
    {
        // allocation failed, exit from the program
        fprintf(stderr, "Out of memory!\n");
        exit(1);
    }
    //Assigned value to allocated memory
    for (i = 0; i < n; ++i)
    {
        piBuffer[i] = i * 3;
    }
    //Print the value
    for (i = 0; i < n; ++i)
    {
        printf("%d\n", piBuffer[i]);
    }
    //free up allocated memory
    free(piBuffer);
    return 0;
}
