// SCT211-0848/2018 - Jany Muong

/**
 * getw_read_from_file.c :
 *  
 * Description: program to read integer from file using getw()
*/


#include <stdio.h>
#include <stdlib.h>


int main() {
    // for storing integer read from file(previously written to it)
    int num;

    // type FILE for file pointer to read from file
    FILE *fp_in;

    // open file in read mode using relative path - to retrieve anywhere(in working dir) in drive

    fp_in = fopen("Kenya.txt", "r");

    // check if file was opened successfully
    if (fp_in == NULL) {
        printf("Error opening file!\n");
        return (1);
    }

    printf("___Opening File___: \n");

    // get/read integr from file using getw()
    num = getw(fp_in);

    // check for read error
    if (num != EOF) {
        printf("Integer read from file: %d\n", num);
    } else {
        printf("Error reading from file!\n");
    }

    fclose(fp_in); // close Kenya.txt

    return (0);
}