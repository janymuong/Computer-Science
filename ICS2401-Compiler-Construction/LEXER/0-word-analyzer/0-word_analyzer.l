%{
#include <stdio.h>
int word_count = 0;
int total_size = 0;
%}

%%
[a-zA-Z]+   { word_count++; total_size += yyleng; }  /* regex - match words and count them */
.|\n        ;  /* ignore non-alphabetic characters */
%%

int main() {
    yylex();
    printf("COUNT of WORDS: %d\n", word_count);
    printf("Total SIZE of WORDS (chars): %d BYTES\n", total_size);
    return (0);
}
