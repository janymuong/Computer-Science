#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 8-disk_space:
# script to check available disk space and alert user

# function to check disk space
check_disk_space() {
   # df - for disk space information

   # for Linux systems
   if [[ "$OSTYPE" == "linux-gnu"* ]]; then
       # check for C drive equivalent (typically / or /home)
       disk_space=$(df -m / | awk 'NR==2 {print $4}')
       echo "the space available is $disk_space MB"
   
   # for macOS
   elif [[ "$OSTYPE" == "darwin"* ]]; then
       disk_space=$(df -m / | awk 'NR==2 {print $4}')
       echo "the space available is $disk_space MB"
   
   # for Windows (can use Cygwin)
   elif [[ "$OSTYPE" == "msys"* ]] || [[ "$OSTYPE" == "cygwin"* ]]; then
       # For Windows, use wmic to get C: drive space
       disk_space=$(wmic logicaldisk where deviceid="C:" get freespace | tail -n 2 | head -n 1 | awk '{print $1/1048576}' | cut -d. -f1)
       echo "the space available is $disk_space MB"
   
   else
       echo "Unsupported operating system"
       exit 1
   fi
}

main() {
   check_disk_space
}

main