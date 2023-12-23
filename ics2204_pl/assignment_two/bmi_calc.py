#!/usr/bin/python3
'''
SCT211-0848/2018
Jany Muong


Assignment 2. Part B: Control Flow - instruction 3

BMI - Body Mass Index;
    Used measure to estimate a person's body fat,
    and assess whether they have a healthy weight for their height.
    BMI is used as a screening tool to categorize individuals
    into different weight categories - to identify potential health risks associated with
    underweight, overweight, or obese.
BMI formula: BMI = weight (kg) / (height (m) ** 2)
'''

# this is info about BMI actegory limits - upper and lower - based on task instruction
bmi_stats = (18.5, 24.9)
bmi_msg = ['Underweight',
           'Normal weight',
           'Overweight'
           ]


def bmi_calc(weight_kg, height_m):
    '''Calculate BMI - Body Mass Index
    '''
    bmi = weight_kg / (height_m ** 2)
    return bmi


def classify_bmi(bmi):
    '''Print MESSAGES to the user'''
    if bmi < bmi_stats[0]:
        return bmi_msg[0]
    elif bmi_stats[0] <= bmi < bmi_stats[1]:
        return bmi_msg[1]
    else:
        return bmi_msg[2]

# prompt for input: mass/weight in kg and height in meters
weight = float(input('Enter your MASS in kilograms: '))
height = float(input('Enter your HEIGHT in meters: '))

# determine BMI, and classify BMI
bmi = bmi_calc(weight, height)
bmi_category = classify_bmi(bmi)

print()
print(f'Your BMI is: {bmi:.2f}')
print(f'Your BMI category is: {bmi_category}')
