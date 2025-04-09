// SCT211-0848/2018 - Jany Muong

/**
 * putw_write_to_file.c :
 *  
 * Description: program to write integer input to file using putw()
*/

#include <stdio.h>
#include <stdlib.h>


int main() {
    // for storin user input from keyboard
    int num;

    // file pointer of type FILE
    FILE *fp_out;
    
    // open file in write mode using relative path - to store anywhere in drive
    fp_out = fopen("Kenya.txt", "w");
    
    if (fp_out == NULL) {
        printf("Error opening file!\n");
        return (1);
    }
    
    // input from user - using scanf
    printf("Enter an integer: ");
    scanf("%d", &num);

    printf("___Writing to File___: \n");
    printf(".....\n");

    // write number to file;
    putw(num, fp_out);

    fclose(fp_out); // close Kenya.txt
    printf("Integer written to Kenya.txt\n");

    return (0);
}
