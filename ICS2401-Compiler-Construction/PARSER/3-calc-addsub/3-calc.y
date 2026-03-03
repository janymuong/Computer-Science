%{
#include <stdio.h>
#include <stdlib.h>

void yyerror(const char *s);
int yylex(void);
%}

/* token declarations */
%token NUMBER
%token PLUS MINUS
%token LPAREN RPAREN

/* operator precedence and associativity */
%left PLUS MINUS

%%

/* grammar rules */
program:
    /* empty */
    | program expression '\n'  { printf("result: %d\n\n", $2); }
    | program error '\n'       { yyerrok; printf("\n"); }
    | program '\n'             /* allow blank lines */
    ;

expression:
    NUMBER                        { $$ = $1; }
    | expression PLUS expression  { $$ = $1 + $3; }
    | expression MINUS expression { $$ = $1 - $3; }
    | MINUS expression            { $$ = -$2; }
    | LPAREN expression RPAREN    { $$ = $2; }
    ;

%%

void yyerror(const char *s) {
    fprintf(stderr, "parse error: %s\n", s);
    fprintf(stderr, "valid input: numbers with + and - operators\n");
    fprintf(stderr, "e.g.: 5+3, 10-2+4, -(5-3)\n");
}

int main(void) {
    printf("=== other calculator :) ===\n");
    printf("supports: + (addition) and - (subtraction)\n");
    printf("e.g: 10-5+3 = 8\n");
    printf("enter expressions (or use ctrl+d to exit):\n\n");
    yyparse();
    printf("goodbye!\n");
    return 0;
}
