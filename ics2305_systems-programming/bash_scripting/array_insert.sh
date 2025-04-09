numbers=("element1" "element2" "element3")
echo ${numbers[*]}

numbers[0]="element0"
echo ${numbers[*]}
numbers[5]="element5"
echo ${numbers[*]}
numbers[6]="element6"
echo ${numbers[*]}

numbers[-1]="element8"
echo ${numbers[*]}
