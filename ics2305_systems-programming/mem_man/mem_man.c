#include <stdio.h>
#include <stdlib.h>

int main() {
    int n, i;
    int *ptr;

    // Get the number of elements
    printf("Enter number of elements:\n");
    scanf("%d", &n);

    // Dynamically allocate memory for 'n' integers using malloc
    ptr = (int*)malloc(n * sizeof(int));

    // Check if memory allocation was successful
    if (ptr == NULL) {
        printf("Memory allocation failed!\n");
        return 1; // Exit the program with an error code
    }

    // Display the size of each integer and the total memory allocated
    printf("Size of each integer: %lu bytes\n", sizeof(int));
    printf("Total memory allocated for %d elements: %lu bytes\n", n, n * sizeof(int));

    // Input elements into the allocated memory
    printf("Enter %d numbers:\n", n);
    for (i = 0; i < n; i++) {
        scanf("%d", ptr + i);  // Using pointer arithmetic to access array elements
    }

    // Print the elements using pointer arithmetic
    printf("The entered numbers are:\n");
    for (i = 0; i < n; i++) {
        printf("%d ", *(ptr + i));  // Dereferencing the pointer to get the value
    }
    printf("\n");

    // Free the allocated memory
    free(ptr);
    printf("Memory has been freed.\n");

    return 0;
}

