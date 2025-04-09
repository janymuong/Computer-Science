#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 3-check_user_logins:
# Script to count the number of active logins for a given UID and display their login times.

# UID is provided as a commandline arg
if [ $# -eq 0 ]; then
    echo "Usage: $0 <UID>"
    exit 1
fi

# get the UID from the argument
uid=$1

# UID is a positive integer
if ! [[ "$uid" =~ ^[0-9]+$ ]]; then
    echo "Error: '$uid' is not a valid UID. Please provide a numeric UID."
    exit 1
fi

# resolve the username associated with the UID
username=$(getent passwd "$uid" | cut -d: -f1)

# check if the username exists
if [ -z "$username" ]; then
    echo "Error: No user found with UID '$uid'."
    exit 1
fi

# all sessions for the username
logins=$(who | awk -v user="$username" '$1 == user')

# active logins
login_count=$(echo "$logins" | wc -l)

# print to console
if [ "$login_count" -eq 0 ]; then
    echo "User with UID '$uid' (username: $username) is not currently logged in."
else
    echo "User with UID '$uid' (username: $username) is logged in $login_count time(s)."
    echo "Login TIMES:"
    echo "$logins" | awk '{print $4}'
fi
