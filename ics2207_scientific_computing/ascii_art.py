#!/usr/bin/env python
'''
SCT211-0848/2018
Jany Muong

ICS 2207: Scientific Computing - CS 2.2

ascii_art.py

Building Python Programs
Programming Assignment Project 2: ASCII Art

Part A: ASCII Art

This program generates an ASCII art picture
    inspired by anime themes like Jujutsu Kaisen and Attack on Titan.

'''


def shingeki_kyojin(size):
    '''
    generate ASCII art of a titan inspired by attack on titan anime
    '''
    art = ''
    for i in range(size):
        art += ' ' * (size - i)
        art += 'o' * (2 * i + 1)
        art += '\n'
    return art


def generate_cursed_symbol(size):
    '''generate ASCII art of a cursed symbol
    inspired by Jujutsu Kaisen
    '''
    art = ''
    for i in range(size):
        art += ' ' * (size - i)
        art += '/' * (2 * i + 1)
        art += '\n'
    return art


def generate_character():
    '''generate ASCII art of an anime character'''
    ascii_art = ''

    # hair
    hair_top = '*' * 5
    hair_bottom = hair_top[::-1]

    ascii_art += ' ' + hair_top + '\n'
    ascii_art += ' / \\' + hair_bottom[1:] + '\n'
    ascii_art += '/___\\' + hair_bottom[:-1] + '\n'

    # face
    ascii_art += ' ( ^ o ^ )\n'
    ascii_art += '  \\V/ \n'
    ascii_art += '  / - \\'

    return ascii_art



titan_ascii = shingeki_kyojin(5)
cursed_symbol_ascii = generate_cursed_symbol(5)
character_ascii = generate_character()

# Print the ASCII art
print(f'Titan ASCII Art:\n{titan_ascii}')
print(f'Cursed Symbol ASCII Art:\n{cursed_symbol_ascii}')
print(f'Anime Character ASCII Art\n{character_ascii}')
