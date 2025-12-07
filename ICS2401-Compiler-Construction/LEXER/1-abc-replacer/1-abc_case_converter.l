%{
#include <stdio.h>
%}

%%
abc     { printf("ABC"); }  /* replace string 'abc' with string 'ABC' */
.       { ECHO; }            /* print all else to console as-is */
%%

int main() {
    yylex();
    return 0;
}
