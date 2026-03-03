# ICS2401 compiler construction - assignment II

## context:
we are implementing three different parsing/interpretation programs.


```bash
# arch linux
sudo pacman -S flex bison

# ubuntu / debian(use a variant of lex or bison/yacc that works for you)
sudo apt-get install flex bison

# fedora / rhel
sudo dnf install flex bison
```


### `part 1`: recursive descent parser
**requirement**: write a c program for a simple calculator using the recursive descent strategy with mutually recursive routines. supports integer arithmetic with '+' and '*'.

**files**:
- `1-recursive-descent/recursive_calc.c` -  implementation
- `1-recursive-descent/test_input.txt` - test file

**grammar**:
```
expr   → term expr'
expr'  → + term expr' | ε
term   → factor term'
term'  → * factor term' | ε
factor → number | ( expr )
```

**features**:
- mutually recursive functions: `expr()`, `term()`, `factor()`
- proper operator precedence (* before +)
- parentheses support
- error reporting with position indicator
- **continuous loop**: enter multiple expressions without restarting
- **error recovery**: Invalid input doesn't terminate the program
- type 'quit' or 'q' to exit

### `part 2`: a-counter interpreter
**requirement**: using grammar `S → aS | b`, create an interpreter using lex and yacc to count the number of 'a's in the input string.

**files**:
- `2-a-counter/2-a_counter.l` - lexer specification
- `2-a-counter/2-a_counter.y` - parser specification
- `2-a-counter/test_input.txt` - test file

**grammar**:
```
S → aS | b
```

**features**:
- validates input matches grammar (must end with 'b')
- counts number of 'a's
- Examples: `b` (0 a's), `ab` (1 a), `aaab` (3 a's)
- **continuous loop**: Enter multiple strings without restarting
- **error recovery**: Invalid strings show error but program continues
- use ctrl+d to exit

### `part 3`: add/subtract calculator
**requirement**: write lex and yacc specification files for a small calculator that can add and subtract numbers.

**files**:
- `3-calc-addsub/3-calc.l` - lexer specification
- `3-calc-addsub/3-calc.y` - parser specification
- `3-calc-addsub/test_input.txt` - test file

**features**:
- addition (+) and subtraction (-)
- unary minus support (e.g., -5)
- parentheses for grouping
- left-associative operators
- **interactive mode**: enter multiple expressions
- **error recovery**: parse errors don't terminate the program
- use ctrl+d to exit



## compilation + execution:

---
#### recursive Descent
```bash
cd 1-recursive-descent
gcc recursive_calc.c -o recursive_calc
./recursive_calc
# enter expressions interactively
# type 'quit' to exit
```

#### a-counter
```bash
cd 2-a-counter
flex 2-a_counter.l
bison -d 2-a_counter.y
gcc lex.yy.c 2-a_counter.tab.c -o a_counter -lfl
./a_counter
# enter strings interactively
# use ctrl+d to exit
```

#### other calculator
```bash
cd 3-calc-addsub
flex 3-calc.l
bison -d 3-calc.y
gcc lex.yy.c 3-calc.tab.c -o calc -lfl
./calc
# enter expressions interactively
# use ctrl+d to exit
```

---
## interactive session

### PSET 1: recursive descent
```bash
┌─[j@archlinux] - [~/PARSER/1-recursive-descent] - [Tue Mar 03, 22:50]
└─[$] <git:(main*)> ./recursive_calc 
=== RECURSIVE  DESCENT CALCULATOR ===
supports: + (addition) and * (multiplication)
e.g: 2+3*4 = 14
enter 'quit' to exit

enter expression: 7*3
result: 21

enter expression: 73+0
result: 73

enter expression: quit
goodbye!
```

### PSET 2: `a`-counter
```sh
┌─[j@archlinux] - [~/PARSER/2-a-counter] - [Tue Mar 03, 22:56]
└─[$] <git:(main*)> ./a_counter                  
=== grammar S -> aS | b interpreter ===
a program that counts the number of 'a's in input.
valid strings: b, ab, aab, aaab, etc. (a*b pattern)
enter strings (use ctrl+d to exit):

aaab
valid string! number of 'a's: 3

b
valid string! number of 'a's: 0

ba
parse error: syntax error
valid strings match: a*b (zero or more 'a's followed by one 'b')
e.g.: b, ab, aab, aaab

aaaaab
valid string! number of 'a's: 5

quit
invalid character: 'q'
invalid character: 'u'
invalid character: 'i'
invalid character: 't'
goodbye!
┌─[j@archlinux] - [~/PARSER/2-a-counter] - [Tue Mar 03, 22:59]
└─[$] <git:(
```

----
## concepts

### recursive descent
- **top-down parsing**: start from the root (expr) and work down
- **predictive parsing**: Look at current token to decide which rule to use
- **left factoring**: transform grammar to eliminate left recursion
- **mutually recursive**: functions call each other (expr → term, term → factor, factor → expr)
- **error recovery**: uses error flag instead of exit() to continue after errors

### grammar recognition
- **context-free grammar(cfg)**: S → aS | b
- **recursive structure**: S appears on right-hand side
- **base case**: b terminates the recursion
- **valid strings**: b, ab, aab, aaab, ... (pattern: a*b)
- **error recovery**: Uses yyerrok to reset parser state after errors

### bottom-up parsing
- **LR parsing**: bison uses LALR(1) parser
- **shift-reduce**: build parse tree from leaves to root
- **operator associativity**: left-associative for +/-
- **precedence**: handled by bison's %left directive
- **error recovery**: special error production handles invalid input

## differences:

| aspect | 1 recursive descent) | 2 & 3 (lex/yacc) |
|--------|---------------------------|---------------------|
| **parsing Strategy** | top-down (ll) | bottom-up (lr) |
| **tools** | c | flex + bison |
| **exit method** | type 'quit' | press ctrl+d |

