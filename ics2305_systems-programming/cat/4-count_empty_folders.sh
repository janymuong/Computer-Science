#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 4-count_empty_folders:
# script to count the number of empty folders (size = 0) in the current directory
# and output their names along with creation times.


PWD=$(pwd)

# find empty directories
empty_folders=$(find "$PWD" -type d -empty)

# check if there are any empty directories
if [ -z "$empty_folders" ]; then
    echo "No empty folders found in '$PWD'."
    exit 0
fi


# count the number of empty directories
empty_count=$(echo "$empty_folders" | wc -l)

# print empty folders and their creation times
echo "Number of empty folders: $empty_count"
echo "Empty folders and their creation times:"

for dir in $empty_folders; do
    # get creation time of each empty folder
    creation_time=$(stat --format='%W' "$dir")
    # human readable
    if [ "$creation_time" -eq 0 ]; then
        creation_time="Unknown"
    else
        creation_time=$(date -d @$creation_time)
    fi
    echo "$dir - Created: $creation_time"
done
