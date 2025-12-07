# compiler
CC = gcc
FLEX = flex
FLAGS = -lfl # flags

# targets
all: word_analyzer pattern_replacer verb_detector

word_analyzer: 0-word_analyzer.l
	$(FLEX) -o lex_word_analyzer.c $<
	$(CC) lex_word_analyzer.c -o $@ $(FLAGS)

pattern_replacer: 1-abc_case_converter.l
	$(FLEX) -o lex_pattern_replacer.c $<
	$(CC) lex_pattern_replacer.c -o $@ $(FLAGS)

verb_detector: 2-recognizer.l
	$(FLEX) -o lex_verb_detector.c $<
	$(CC) lex_verb_detector.c -o $@ $(FLAGS)

test: all
	@echo "=== Testing Word Analyzer ==="
	./word_analyzer < test_words.txt
	@echo "\n=== Testing Pattern Replacer ==="
	./pattern_replacer < test_abc.txt
	@echo "\n=== Testing Verb Detector ==="
	./verb_detector < test_verbs.txt

clean:
	rm -f word_analyzer pattern_replacer verb_detector
	rm -f lex_*.c lex.yy.c

.PHONY: all test clean
