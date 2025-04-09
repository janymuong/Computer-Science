#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 2b-string_search:
# script to search for 'Mpangale' in Angukanayo.txt

# check if file exists
if [ ! -f "Angukanayo.txt" ]; then
    echo "Error: File Angukanayo.txt not found"
    exit 1
fi

# search for the string
match=$(grep -n "Mpangale" Angukanayo.txt)

# check if string was found
if [ -z "$match" ]; then
    echo "String 'Mpangale' not found in the file."
else
    echo "String 'Mpangale' found - at these LINES:"
    echo "$match"
fi
