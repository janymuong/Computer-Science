#include <stdio.h> 
int main()
{ 
    FILE *fp;
    char str[] = "How was the CAT last week?\n";
    char str1[] = "Easier than we expected\n";
    char str2[] = "Easier than we expected\n";

    printf("Writing to FPUTS.txt in WRITE/READ Mode");
    fp = fopen("FPUTS.txt", "w+");
    fputs(str, fp); 
    fputs(str1, fp); 
    fputs(str1, fp);
    fclose(fp);

    return (0);
}
