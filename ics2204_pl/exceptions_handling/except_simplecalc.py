#!/usr/bin/python3
'''
SCT211-0848/2018
Jany Muong
'''


class SimpleCalc():
    '''
    This class defines a template for a calculator object.
    Initializes attributes from various inputs from a user,
    performs basic arithmetic operations, and prints the result.
    '''
    def __init__(self):
        '''Constructor - initialize attributes'''
        self.user_name = None
        self.first_num = None
        self.second_num = None

    def welcome_user(self):
        '''Welcome user method'''
        self.user_name = str(input('Please enter your name: '))
        salute = f'Hello, {self.user_name}. Welcome to my calculator :)'
        print(salute)
        print()

    def get_integer_input(self):
        '''Prompt for integer input from the user'''
        try:
            self.first_num = int(input('Please enter first integer: '))
            self.second_num = int(input('Please enter second integer: '))
        except ValueError:
            print('Error: Please enter valid integer values.')
            self.get_integer_input()

    def calculate_sum(self):
        '''Calculate and print the sum'''
        print(f'The sum of {self.first_num} and {self.second_num} is: {self.first_num + self.second_num}')

    def calculate_diff(self):
        '''Calculate and print the difference'''
        print(f'The difference of {self.first_num} and {self.second_num} is: {self.first_num - self.second_num}')

    def calculate_product(self):
        '''Calculate and print the product'''
        print(f'The product of {self.first_num} and {self.second_num} is: {self.first_num * self.second_num}')

    def calculate_quotient(self):
        '''Calculate and print the quotient'''
        try:
            if self.second_num != 0:
                print(f'The quotient of {self.first_num} and {self.second_num} is: {self.first_num / self.second_num}')
            else:
                print("Error: Division by zero.")
        except ZeroDivisionError:
            raise ("Error: Division by zero.")


if __name__ == '__main__':
    # run in command-line as a main program
    # create objects/call instance methods
    calculator = SimpleCalc()

    calculator.welcome_user()
    calculator.get_integer_input()
    calculator.calculate_sum()
    calculator.calculate_diff()
    calculator.calculate_product()
    calculator.calculate_quotient()
