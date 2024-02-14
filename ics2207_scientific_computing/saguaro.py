#!/usr/bin/env python
'''
SCT211-0848/2018
Jany Muong

ICS 2207: Scientific Computing - CS 2.2

module: saguaro.py

Building Python Programs
Programming Assignment Project 2: ASCII Art
        'Part B: Saguaro'
'''

# constant for saguaro figure size
SIZE = 3


def draw_header(size):
    '''
    Prints the header of the cactus.

    Args:
        size (int): The size of the cactus.

    Returns:
        None
    '''
    print(f' {size * "x"}    xxxxxx')


def top_arms(size):
    '''
    Generates the top arms of the cactus with appropriate spacing.

    Args:
        size: The desired size of the arms.

    Returns:
        A string representing the top arms of the cactus.
    '''
    for i in range(1, 6):
        print(f'X{size * "-"}X  X', end='')

        # print trunk part
        for j in range(1, i + 1):
            print('/', end='')
            
        for j in range(5, i - 1, -1):
            print('-', end='')
            
        print('X', end='')
        print()

    # left arm:
    print(f' {size * "x"}xxxX{6 * "~"}X   {size * "x"}')


    for i in range(1, 6):
        # print blanks
        print(f' {size * " "}   X', end='')
        
        # Print center part
        for j in range(1, i + 1):
            print('-', end='')
            
        for j in range(5, i - 1, -1):
            print('\\', end='')
            
        # Print right part
        print(f'X  X{size * "-"}X', end='')
        print()

    # left hand of saguaro
    print(f' {size * " "}   X{6 * "~"}Xxxx{size * "x"}')



def draw_base(size):
    '''
    Generates the base of the cactus with appropriate spacing.

    Args:
        size: The desired size of the base.

    Returns:
        A string representing the base of the cactus.
        '''
    for _ in range(1, 7):
        # print pattern "X~~X"
        print(f' {size * " "}   X{6 * "~"}X')


def draw_cactus(size):
    '''
    Prints the saguaro cactus using the specified size constant.
    '''
    draw_header(size)
    top_arms(size)
    draw_base(size)


if __name__ == '__main__':
  draw_cactus(SIZE)
