# gcc + opengL makefile
CC = gcc
CFLAGS = -Wall -std=c99 -D_DEFAULT_SOURCE
LIBS = -lGL -lGLU -lglut -lGLEW -lm

# get all .c files (default behavior)
SOURCES = $(wildcard *.c)
EXECUTABLES = $(SOURCES:.c=)

# default target - build all
all: $(EXECUTABLES)

# pattern rule to build any executable from its .c file
%: %.c
	$(CC) $(CFLAGS) -o $@ $< $(LIBS)

# build target; by name
build: $(TARGET)

# cleanup
clean:
ifdef TARGET
	rm -f $(TARGET)
else
	rm -f $(EXECUTABLES)
endif

# help target
help:
	@echo "Usage:"
	@echo "  make all                    # Build all .c files"
	@echo "  make build TARGET=program   # Build specific program (without .c extension)"
	@echo "  make clean                  # Clean all executables"
	@echo "  make clean TARGET=program   # Clean specific executable"
	@echo ""
	@echo "Available programs: $(EXECUTABLES)"

.PHONY: all build clean help

