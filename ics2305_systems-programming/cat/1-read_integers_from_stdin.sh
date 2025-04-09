#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 1-read_integers_from_stdin:
# script to read 6 numbers and calculate their sum


# validate whether input is an intger - with regex
is_int() {
    re='^[0-9]+([.][0-9]+)?$'
    if ! [[ $1 =~ $re ]]; then
        return 1
    fi
    return 0
}

sum=0
count=0

echo "Please enter 6 numbers:"

# loop numbers from keyboard
while [ $count -lt 6 ]; do
    read -p "Enter number $(($count + 1)): " num

    if ! is_int "$num"; then
        echo "Error: '$num' is not a valid number."
        continue
    fi

    # addd numbers
    sum=$(echo "$sum + $num" | bc)
    ((count++))
done

echo "This is Your SUM: $sum"
