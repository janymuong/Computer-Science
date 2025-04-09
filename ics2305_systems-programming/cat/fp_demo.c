#include <stdio.h>
#include <stdlib.h>

int main() {
    FILE *file_pointer;
    char buffer[30], c;

    // Open jokes-cp.txt
    file_pointer = fopen("jokes-cp.txt", "r");
    if (file_pointer == NULL) {
        perror("Error opening jokes-cp.txt");
        return 1;
    }

    printf("----read a line----\n");
    fgets(buffer, sizeof(buffer), file_pointer);
    printf("%s\n", buffer);
    fclose(file_pointer);

    printf("----read and parse data----\n");

    // Open fprintf_test.txt
    file_pointer = fopen("fprintf_test.txt", "r");
    if (file_pointer == NULL) {
        perror("Error opening fprintf_test.txt");
        return 1;
    }

    char str1[10], str2[2], str3[20], str4[2];
    if (fscanf(file_pointer, "%s %s %s %s", str1, str2, str3, str4) != 4) {
        printf("Error reading from file.\n");
    } else {
        printf("Read String1 |%s|\n", str1);
        printf("Read String2 |%s|\n", str2);
        printf("Read String3 |%s|\n", str3);
        printf("Read String4 |%s|\n", str4);
    }
    fclose(file_pointer);

    printf("----read the entire file----\n");

    // Open ICS2305.txt
    file_pointer = fopen("ICS2305.txt", "r");
    if (file_pointer == NULL) {
        perror("Error opening ICS2305.txt");
        return 1;
    }

    while ((c = getc(file_pointer)) != EOF)
        putchar(c);

    fclose(file_pointer);
    return 0;
}
