#!/bin/bash
setAge() {
    local AGE=25
    echo "Local Variable Age: $AGE"
}
AGE=40
setAge
echo "Global Age: $AGE"
