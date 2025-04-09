numbers=("element1" "element2" "element3")
echo ${numbers[*]}
unset numbers[-1]
echo ${numbers[*]}
