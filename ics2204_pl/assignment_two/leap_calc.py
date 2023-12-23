#!/usr/bin/python3
'''
SCT211-0848/2018
Jany Muong

Assignment 2. Part B: Control Flow - instruction 4
'''


def leap_calc(year):
    '''leap_calc() - LEAP YEAR checker
    Takes an input year,
    and informs you whether or not it is a leap year
    '''

    # check for LEAP conditions;
    if (year % 4 == 0 and year % 100 != 0) or (year % 400 == 0):
        return True
    else:
        return False

year = int(input('Enter a year: '))

# if TRUE return descriptive message; else other descriptive message
if leap_calc(year):
    print(f'{year} is a leap year.')
else:
    print(f'{year} is not a leap year.')
