#!/bin/bash
FOLDER=gentoo

if [[ -d "$FOLDER" && -w "$FOLDER" && -x "$FOLDER" ]]
then
    echo "Directory exists, writable and executable"
else
    echo "Directory does not meet all conditions"
fi
