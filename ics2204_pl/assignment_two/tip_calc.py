#!/usr/bin/python3
'''
SCT211-0848/2018
Jany Muong

Assignment 2. PART A: `Data Types` Recap
'''

# preset tip values to select from
PERCENT_TIP = [10, 12, 15]
TIP_MSG = f'Invalid tip percentage. Please choose: {PERCENT_TIP[0]}, {PERCENT_TIP[1]}, or {PERCENT_TIP[2]}.'


def calculate_tip(total_bill_amount, percent_tip, quorum):
    '''calculates the amount each person should pay for a bill, including tip.

    user is prompted to enter the total bill amount, the tip percentage, and
    the number of people splitting the bill.

    returns:
        amount each person should pay, rounded to two decimal points.
    '''

    # Check if the entered tip percentage is valid
    if percent_tip not in PERCENT_TIP:
        print(TIP_MSG)
        return None

    tip_amount = total_bill_amount * (percent_tip / 100)

    # calculate the total bill including tip
    total_with_tip = total_bill_amount + tip_amount

    # calculate the amount per person
    amount_per_person = total_with_tip / quorum

    return amount_per_person


def main():
    # welcome user
    user_name = str(input('Please enter your name: '))
    salute = f'Hello, {user_name}. Welcome to my TIP calculator :)'
    print(salute)
    print()

    # get total bill amount.
    total_bill_amount = float(input('Please enter the total bill amount: '))

    percent_tip = float(input('Enter the tip percentage (10, 12, or 15): '))

    # user - enter the number of people (quorum) splitting the bill.
    quorum = int(input('Enter the number of people splitting the bill: '))

    # calculate the amount each person should pay.
    amount_per_person = calculate_tip(total_bill_amount, percent_tip, quorum)

    if amount_per_person is not None:
        # print the amount each person should pay. 2DP
        print(f'Each person should pay ${amount_per_person:.2f}.')


if __name__ == '__main__':
    # run as a main program
    main()
