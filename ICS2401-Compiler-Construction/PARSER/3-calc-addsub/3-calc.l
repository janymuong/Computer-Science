%{
#include <stdio.h>
#include "3-calc.tab.h"
%}

%%
[ \t]       ;  /* skip whitespace (not newline) */
\n          { return '\n'; }  /* return newline to parser */
[0-9]+      { yylval = atoi(yytext); return NUMBER; }
"+"         { return PLUS; }
"-"         { return MINUS; }
"("         { return LPAREN; }
")"         { return RPAREN; }
.           { printf("Unknown character: %s\n", yytext); }
%%

int yywrap(void) {
    return 1;
}
