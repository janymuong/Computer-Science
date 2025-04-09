#include <stdio.h>
#include <stdlib.h>

int main() {
    int *arr;
    int n = 5;

    // Allocating memory for 5 integers
    arr = (int*) calloc(n, sizeof(int));

    if (arr == NULL) {
        printf("Memory allocation failed\n");
        return 1;
    }

    // Displaying the array elements
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]); // All values will be initialized to 0
    }

    // Freeing allocated memory
    free(arr);

    return 0;
}
