%{
#include <stdio.h>
#include <stdlib.h>

void yyerror(const char *s);
int yylex(void);

int a_count = 0;  /* counter for 'a's */
%}

/* token declarations */
%token A B

%%

/* grammar: S -> aS | b */
program:
    /* empty */
    | program S '\n'    { printf("valid string! number of 'a's: %d\n\n", a_count); a_count = 0; }
    | program error '\n' { yyerrok; a_count = 0; printf("\n"); }
    | program '\n'      /* allow blank lines */
    ;

S:
    A S { a_count++; }  /* S -> aS (recursive) */
    | B               /* S -> b (base case) */
    ;

%%

void yyerror(const char *s) {
    fprintf(stderr, "parse error: %s\n", s);
    fprintf(stderr, "valid strings match: a*b (zero or more 'a's followed by one 'b')\n");
    fprintf(stderr, "e.g.: b, ab, aab, aaab\n");
}

int main(void) {
    printf("=== grammar S -> aS | b interpreter ===\n");
    printf("a program that counts the number of 'a's in input.\n");
    printf("valid strings: b, ab, aab, aaab, etc. (a*b pattern)\n");
    printf("enter strings (use ctrl+d to exit):\n\n");

    yyparse();

    printf("goodbye!\n");
    return (0);
}
