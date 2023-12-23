#!/usr/bin/python3
'''Programming Languages Class - Oct 13th | 2023'''

chars = 'characters'
idx = 0

print(f'Length of string: {len(chars)}')
for char in chars:
    if char == 't':
        print(f'Demo when BREAK statemeent occurred:')
        print(f'\t POSITION from string.index() method: {chars.index(char)}')
        print('\t POSITION from loop iterator: ', idx)
        break
    idx += 1
    print(char)

print(f'Print initial STRING LITERAL to stdout -> : {chars}')
print()
print(f'INDEX of character "e" from string.find(): {chars.find("e")}')
print(f"REPLACE 'e' with 'E' with string.replace(): {chars.replace('e', 'E')}")
print(f'PRINT in CAPS with str.upper(): {chars.upper()}')
print(f"COUNT of character 'e': {chars.count('e')}")

my_list = ['stuff', 'facetime', 'android']
# result = my_list.append('GTA')
my_list.append('GTA')
print(my_list)
