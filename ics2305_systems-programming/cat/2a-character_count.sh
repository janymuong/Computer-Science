#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 2a-character_count:
# script to count characters in Angukanayo.txt

PWD=$(pwd)

# chheck if file exists
if [ ! -f "Angukanayo.txt" ]; then
    echo "Error: File Angukanayo.txt doesn't exist in ${PWD}"
    exit 1
fi

# count characters using wc command
char_count=$(wc -m < Angukanayo.txt)

echo "FROM WC: Angukanayo.txt has $char_count characters"