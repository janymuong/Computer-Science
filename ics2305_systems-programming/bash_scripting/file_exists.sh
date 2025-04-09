#!/bin/bash

file_path=gentoo

if [ -d "$file_path" ]
then
	echo "file ${file_path} exists."

else
	echo "file ${file_path} exists, and is not a directory"
fi
