#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Define a struct for a student
struct Student {
    char name[50];
    int age;
};

int main() {
    int n, i;
    struct Student *students;

    // Get the number of students
    printf("Enter the number of students:\n");
    scanf("%d", &n);

    // Dynamically allocate memory for 'n' students
    students = (struct Student*)malloc(n * sizeof(struct Student));

    // Check if memory allocation was successful
    if (students == NULL) {
        printf("Memory allocation failed!\n");
        return 1; // Exit the program with an error code
    }

    // Input student details
    for (i = 0; i < n; i++) {
        printf("Enter name of student %d:\n", i + 1);
        scanf("%s", students[i].name);
        printf("Enter age of student %d:\n", i + 1);
        scanf("%d", &students[i].age);
    }

    // Display the student details
    printf("\nStudent Details:\n");
    for (i = 0; i < n; i++) {
        printf("Student %d: Name = %s, Age = %d\n", i + 1, students[i].name, students[i].age);
    }

    // Display the memory sizes
    printf("\nSize of each Student struct: %lu bytes\n", sizeof(struct Student));
    printf("Total memory allocated for %d students: %lu bytes\n", n, n * sizeof(struct Student));

    // Free the allocated memory
    free(students);
    printf("\nMemory has been freed.\n");

    return 0;
}

