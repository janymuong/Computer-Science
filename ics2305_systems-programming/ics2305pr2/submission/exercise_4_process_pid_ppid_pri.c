// Jany Muong SCT211-0848/2018

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <dirent.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/resource.h>

/**
 * this program prints the process ID, 
 * priority, and parent ID of all processes 
 * currently in RAM.
 */

int main(void)
{
    struct dirent *entry;
    DIR *dp = opendir("/proc"); // open the /proc directory

    if (dp == NULL) {
        perror("opendir failed");
        return EXIT_FAILURE;
    }

    // iterate through the /proc directory entries
    while ((entry = readdir(dp)) != NULL) {
        // check if the entry is a digit (process ID)
        if (entry->d_type == DT_DIR && atoi(entry->d_name) > 0) {
            pid_t pid = atoi(entry->d_name); // convert directory name to PID
            char path[256];
            snprintf(path, sizeof(path), "/proc/%d/stat", pid); // create path to stat file

            FILE *fp = fopen(path, "r"); // open the stat file
            if (fp != NULL) {
                int ppid; // parent process ID
                int pri; // process priority
                fscanf(fp, "%*d %*s %*c %d %d", &ppid, &pri); // read PPID and priority
                fclose(fp);
                
                // print out the process ID, priority, and parent ID
                printf("Process ID: %d, Priority: %d, Parent ID: %d\n", pid, pri, ppid);
            } else {
                perror("fopen failed");
            }
        }
    }

    closedir(dp); // close the /proc directory
    return EXIT_SUCCESS; // exit the program
}
