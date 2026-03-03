/*
 * ics 2401 compiler construction - assignment II - pset 1
 * recursive descent parser for simple calculator
 *
 * grammar:
 *   expr   -> term expr'
 *   expr'  -> + term expr' | ε
 *   term   -> factor term'
 *   term'  -> * factor term' | ε
 *   factor -> number | ( expr )
 *
 * implements integer arithmetic with + and * operators
 * using mutually recursive routines.
 */

#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

/* global variables */
char lookahead;     /* current token */
int pos = 0;        /* position in input string */
char input[1000];   /* input buffer */
int error_flag = 0; /* flag to indicate parse error */

/* function declarations (mutually recursive) */
int expr();
int expr_prime(int left);
int term();
int term_prime(int left);
int factor();
void match(char expected);
void error(const char *msg);
void skip_whitespace();
void reset_parser();

/*
 * main entry point of program
 */
int main()
{
    printf("=== RECURSIVE  DESCENT CALCULATOR ===\n");
    printf("supports: + (addition) and * (multiplication)\n");
    printf("e.g: 2+3*4 = 14\n");
    printf("enter 'quit' to exit\n\n");

    while (1)
    {
        printf("enter expression: ");

        if (fgets(input, sizeof(input), stdin) == NULL)
        {
            break; /* EOF or error */
        }

        /* check for quit command as a command-line input */
        if (input[0] == 'q' || input[0] == 'Q')
        {
            printf("goodbye!\n");
            break;
        }

        /* reset parser state */
        reset_parser();

        /* parse and evaluate */
        int result = expr();

        /* check for errors */
        if (error_flag)
        {
            error_flag = 0; /* reset for next iteration */
            continue;
        }

        /* check for end of input */
        if (lookahead != '\n' && lookahead != '\0')
        {
            fprintf(stderr, "parse error: unexpected characters after expression\n");
            continue;
        }

        printf("result: %d\n\n", result);
    }

    return 0;
}

/*
 * expr -> term expr'
 * parses addition expressions
 */
int expr()
{
    int left = term();       /* Get left operand */
    return expr_prime(left); /* Handle remaining additions */
}

/*
 * expr' -> + term expr' | ε
 * handles left-associative addition
 */
int expr_prime(int left)
{
    if (lookahead == '+')
    {
        match('+');                /* consume '+' */
        int right = term();        /* get right operand */
        int result = left + right; /* compute sum */
        return expr_prime(result); /* continue with more additions */
    }
    /* ε (empty) production - just return accumulated value */
    return left;
}

/*
 * term -> factor term'
 * parses multiplication expressions
 */
int term()
{
    int left = factor();     /* get left operand */
    return term_prime(left); /* handle remaining multiplications */
}

/*
 * term' -> * factor term' | ε
 * handles left-associative multiplication
 */
int term_prime(int left)
{
    if (lookahead == '*')
    {
        match('*');                /* Consume '*' */
        int right = factor();      /* Get right operand */
        int result = left * right; /* Compute product */
        return term_prime(result); /* Continue with more multiplications */
    }
    /* ε (empty) production - just return accumulated value */
    return left;
}

/*
 * factor -> number | ( expr )
 * parses numbers and parenthesized expressions
 */
int factor()
{
    skip_whitespace();

    /* check for number */
    if (isdigit(lookahead))
    {
        int value = 0;
        /* parse multi-digit number */
        while (isdigit(lookahead))
        {
            value = value * 10 + (lookahead - '0');
            match(lookahead);
        }
        return value;
    }
    /* check for parenthesized expression */
    else if (lookahead == '(')
    {
        match('(');         /* consume '(' */
        int value = expr(); /* recursively parse expression */
        match(')');         /* consume ')' */
        return value;
    }
    /* error - expected number or '(' */
    else
    {
        error("expected number or '('");
        return 0;
    }
}

/*
 * match expected character and advance to next
 */
void match(char expected)
{
    if (lookahead == expected)
    {
        pos++;
        lookahead = input[pos];
        skip_whitespace();
    }
    else
    {
        char msg[100];
        sprintf(msg, "expected '%c' but found '%c'", expected, lookahead);
        error(msg);
    }
}

/*
 * skip whitespace characters
 */
void skip_whitespace()
{
    while (lookahead == ' ' || lookahead == '\t')
    {
        pos++;
        lookahead = input[pos];
    }
}

/*
 * print error message and continue (don't exit)
 */
void error(const char *msg)
{
    fprintf(stderr, "parse error at position %d: %s\n", pos, msg);
    fprintf(stderr, "input: %s", input);
    fprintf(stderr, "       ");
    for (int i = 0; i < pos; i++)
    {
        fprintf(stderr, " ");
    }
    fprintf(stderr, "^\n");
    error_flag = 1; /* set error flag instead of exiting */
}

/*
 * reset parser state for new input
 */
void reset_parser()
{
    pos = 0;
    lookahead = input[pos];
    error_flag = 0;
    skip_whitespace();
}
