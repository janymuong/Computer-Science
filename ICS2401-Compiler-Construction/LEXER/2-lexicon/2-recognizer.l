%{
#include <stdio.h>
#include <string.h>

char verbs_found[1000][50];  /* array to store found verbs */
int verb_count = 0;          /* counter for verbs */
%}

%%
(is|am|are|were|was|be|being|been|do|does|did|will|would|should|can|could|has|have|had|go)/[^a-zA-Z]  { strcpy(verbs_found[verb_count++], yytext); printf("%s", yytext); }  /* recognize complete verbs only */
[a-zA-Z]+                       { printf("%s", yytext); }  /* print other words */
.|\n                            { ECHO; }  /* print all other characters */
%%

int main() {
    yylex();

    printf("\n\nVERBS FOUND:\n");
    for(int i = 0; i < verb_count; i++) {
        printf("  - %s\n", verbs_found[i]);
    }

    return (0);
}
