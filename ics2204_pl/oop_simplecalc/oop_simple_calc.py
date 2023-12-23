#!/usr/bin/python3
'''
SCT211-0848/2018
Jany Muong
'''


class SimpleCalc():
    '''
    this class defijnes a templates for calculator oject
    iniitializes attributes from various input from a user
    adds two integer numbers, and prints the summation of them.
    '''
    def __init__(self):
        '''constructor - init attributes'''
        self.user_name = None
        self.first_num = None
        self.second_num = None

    '''Instance methods for SimpleCalc'''
    def welcome_user(self):
        '''welcome user method:
        '''
        self.user_name = str(input('Please enter your name: '))
        salute = f'Hello, {self.user_name}. Welcome to my calculator :)'
        print(salute)

    def get_integer_input(self):
        '''prompt for integer input from the user:
        '''
        self.first_num = int(input('Please enter first integer: '))
        self.second_num = int(input('Please enter second integer: '))

    def calculate_sum(self):
        '''single op - addition
        based on initial Lecturer's task specification.
        '''
        # sum = self.first_num + self.second_num
        print(f'The sum of {self.first_num} and {self.second_num} is: {self.first_num + self.second_num}')


if __name__ == '__main__':
    # run in comman-line as a main prog;
    # create objects/call instance methhods
    calculator = SimpleCalc()
    calculator.welcome_user()
    calculator.get_integer_input()
    calculator.calculate_sum()
