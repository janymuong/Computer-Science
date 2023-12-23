# Python Exceptions

> ### `Exceptions and Handling them :)`:  
> Implementation of `exception handdling` in previous OOP - [Simple Calc](../oop_simplecalc/oop_simple_calc.py).  
> - AS IN: `try`, `except`, `finally`


## Run the [file](except_simplecalc.py) as a Python script in command-line;

- First off, give the effective user executable file permission: 
```bash 
chmod +x except_simplecalc.py
mu-o@HP:~/cs_jkuat/programming_languages/exceptions_handling$ ls
except_simplecalc.py
mu-o@HP:~/cs_jkuat/programming_languages/exceptions_handling$
```

- Run the calculator as a script with no arguments;
```bash
./except_simplecalc.py
```

```bash
mu-o@HP:~/cs_jkuat/programming_languages/exceptions_handling$ ./except_simplecalc.py
Please enter your name: world wide weeb
Hello, world wide weeb. Welcome to my calculator :)

Please enter first integer: 7
Please enter second integer: 3
The sum of 7 and 3 is: 10
The difference of 7 and 3 is: 4
The product of 7 and 3 is: 21
The quotient of 7 and 3 is: 2.3333333333333335
mu-o@HP:~/cs_jkuat/programming_languages/exceptions_handling$ ./except_simplecalc.py
Please enter your name: world wide weeb
Hello, world wide weeb. Welcome to my calculator :)

Please enter first integer: 7
Please enter second integer: 0
The sum of 7 and 0 is: 7
The difference of 7 and 0 is: 7
The product of 7 and 0 is: 0
Error: Division by zero.
mu-o@HP:~/cs_jkuat/programming_languages/exceptions_handling$ ./except_simplecalc.py
Please enter your name: world wide weeb
Hello, world wide weeb. Welcome to my calculator :)

Please enter first integer: ackerman
Error: Please enter valid integer values.
Please enter first integer: 7
Please enter second integer: 5
The sum of 7 and 5 is: 12
The difference of 7 and 5 is: 2
The product of 7 and 5 is: 35
The quotient of 7 and 5 is: 1.4
mu-o@HP:~/cs_jkuat/programming_languages/exceptions_handling$
```

---
> Environment:  
>> GNU Linux - Ubuntu 20.04