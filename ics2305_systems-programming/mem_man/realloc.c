#include <stdio.h>
#include <stdlib.h>

int main() {
    int* arr;
    int initial_size = 5, new_size = 10;

    // dynamic allocating initial memory - can be malloc or calloc
    arr = (int*)malloc(initial_size * sizeof(int));
    if (arr == NULL) {
        printf("Initial allocation failed.\n");
        return 1;
    }

    // filling initial memory with values
    for (int i = 0; i < initial_size; i++) {
        arr[i] = i + 1;
    }

    // resizing the array
    int* rloc;
    rloc = (int*)realloc(arr, new_size * sizeof(int));
    if (rloc == NULL) {
        printf("Reallocation failed.\n");
        return (1);
    }

    // initializing new elements
    for (int i = initial_size; i < new_size; i++) {
        rloc[i] = i + 1;
    }

    // displaying the array
    for (int i = 0; i < new_size; i++) {
        printf("%d ", rloc[i]);
    }
    printf("\n");

    // freeing memory
    free(rloc);

    return (0);
}
