# Assignment 2.

> **Note**  
>> Instructions for ASSIGNMENT 2:   


## PART A: `Data Types` Recap 

1. Adjust your [`simple calculator`](../simple_calc/simple_calc.py) app to a version that takes the year of birth of a person and calculates their age in years, months and days respectively. Your app should give all three outputs.  
2. Create a tip calculator that takes in the total bill amount, the tip amount as a percentage of the total bill amount (10,12 or 15 should be the options) and the number of people 
splitting the bill. After getting these user input values your app should calculate the
amount each person should pay and display the answer rounded to two decimal points.  



## Part B: `Control Flow`
Read through the content on control flow and attempt the following code challenges.  

3. Create A BMI Calculator app. After calculating the BMI of a person, the calculator should 
inform the person if they are underweight, Normal weight or Overweight.
4. Create an app that takes an year as the input and informs you whether it is a leap year or 
not.

<br>

---
### Run the AGE calculator Script
> PART A: `Data Types` Recap - [instruction 1]()  
> Run the script.  
>> The output in command-line looks like what is printed below.  

```bash
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$ ./calc_v2_0.py
Please enter your name: Levi Ackerman
Hello, Levi Ackerman. Welcome to my AGE calculator :)
Please enter your date of birth (YYYY-MM-DD): 1995-12-25

Your AGE is 27 years, 2 months, and 6 days.
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$
```


### Run the TIP calculator Script
> PART A: `Data Types` Recap - [instruction 2]()  
> Run the script.  
>> The output in command-line looks like what is printed below.  

```bash
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$ ./tip_calc.py
Please enter your name: Jany Muong
Hello, Jany Muong. Welcome to my TIP calculator :)

Please enter the total bill amount: 30
Enter the tip percentage (10, 12, or 15): 15
Enter the number of people splitting the bill: 3
Each person should pay $11.50.
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$ ./tip_calc.py
Please enter your name: Levi Ackerman
Hello, Levi Ackerman. Welcome to my TIP calculator :)

Please enter the total bill amount: 30
Enter the tip percentage (10, 12, or 15): 73
Enter the number of people splitting the bill: 3
Invalid tip percentage. Please choose: 10, 12, or 15.
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$
```


### Run the BMI calculator Script
> PART A: `Data Types` Recap - [instruction 3]()  
> Run the script.  
>> The output in command-line looks like what is printed below.  

```bash
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$ ./bmi_calc.py
Enter your MASS in kilograms: 84.75
Enter your HEIGHT in meters: 1.92

Your BMI is: 22.99
Your BMI category is: Normal weight
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$ ./bmi_calc.py
Enter your MASS in kilograms: 84.75
Enter your HEIGHT in meters: 1.54

Your BMI is: 35.74
Your BMI category is: Overweight
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$ ./bmi_calc.py
Enter your MASS in kilograms: 64.75
Enter your HEIGHT in meters: 1.92

Your BMI is: 17.56
Your BMI category is: Underweight
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$
```


### Run the LEAP YEAR calculator Script
> PART A: `Data Types` Recap - [instruction 4]()  
> Run the script.  
>> The output in command-line looks like what is printed below.  
```bash
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$ ./leap_calc.py
Enter a year: 2024
2024 is a leap year.
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$ ./leap_calc.py
Enter a year: 2023
2023 is not a leap year.
mu-o@HP:~/cs_jkuat/programming_languages/assignment_two$
```
