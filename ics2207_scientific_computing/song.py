#!/usr/bin/env python
'''
SCT211-0848/2018
Jany Muong

ICS 2207: Scientific Computing - CS 2.2

Building Python Programs
Project 1: Song - generates/prints the cumulative song
        'There Was An Old Lady Who Swallowed A Fly'
'''

# write animals to a list; access them in main func;
animals = ['fly', 'spider', 'bird', 'cat', 'dog', 'horse']


def song_out(song):
    '''print the entitre song in main'''
    print(song)

def fly():
    '''this is the only statement that print "perhaps she'll die." 
    '''
    return "I don't know why she swallowed that fly,\n"\
        "Perhaps she'll die.\n"

def spider():
    '''spider verse'''
    return 'That wriggled and iggled and jiggled inside her,\n'\
        'She swallowed the spider to catch the fly,\n' + fly()

def bird():
    return 'How absurd to swallow a bird,\n' + spider()

def cat():
    return 'Imagine that to swallow a cat,\n' + bird()

def dog():
    return 'What a hog to swallow a dog,\n' + cat()

def custom_verse():
    '''this is my composed veres :)'''
    return 'She studied Python, the language, from dusk until dawn,\n'\
        'But ended up with a snake to catch a dog, not a program to spawn,\n' + dog()

def horse():
    return 'She died of course.'

def verse_common_lines(animal):
    '''extracted the common lines in verse to eliminate redundancy'''

    return 'There was an old woman who swallowed a ' + animal + ',\n'


def main():
    '''final output and structure'''
    song = verse_common_lines(animals[0]) + fly() + '\n'
    song += verse_common_lines(animals[1]) + spider() + '\n'
    song += verse_common_lines(animals[2]) + bird() + '\n'
    song += verse_common_lines(animals[3]) + cat() + '\n'
    song += verse_common_lines(animals[4]) + dog() + '\n'
    song += custom_verse() + '\n'
    song += verse_common_lines(animals[5]) + horse()

    song_out(song)


if __name__ == '__main__':
    main()
