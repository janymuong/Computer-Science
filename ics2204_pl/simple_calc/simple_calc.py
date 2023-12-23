#!/usr/bin/python3
'''
SCT211-0848/2018
Jany Muong
'''


def simple_calc():
    '''
    this function accepts various input from a user
    adds two integer numbers, and prints the summation of them.
    '''

    # welcome user:
    user_name = str(input('Please enter your name: '))
    salute = f'Hello, {user_name}. Welcome to my calculator :)'
    print(salute)

    # prompt for integer input from the user:
    first_num = int(input('Please enter first integer: '))
    second_num = int(input('Please enter second integer: '))

    # single op - addition
    print()
    print(f'The sum of {first_num} and {second_num} is: {first_num + second_num}')

simple_calc()