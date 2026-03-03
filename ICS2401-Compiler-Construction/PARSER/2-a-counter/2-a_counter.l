%{
#include <stdio.h>
#include "2-a_counter.tab.h"
%}

%%
[ \t]       ;  /* skip whitespace (not newline) */
\n          { return '\n'; }  /* return newline to parser */
"a"         { return A; }
"b"         { return B; }
.           { fprintf(stderr, "invalid character: '%c'\n", yytext[0]); }
%%

int yywrap(void) {
    return 1;
}
