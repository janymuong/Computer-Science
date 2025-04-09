#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 5-jpg_to_tiff_converter:
# script to convert .jpg files in a directory to .tiff format

# check if ImageMagick is installed
if ! command -v convert &> /dev/null; then
   echo "Error: ImageMagick is not installed. Please install it first:"
   echo "On Ubuntu/Debian: sudo apt-get install imagemagick"
   echo "On CentOS/RHEL: sudo yum install ImageMagick"
   exit 1
fi

# prompt user for file path
read -p "Enter the full path to the directory containing JPG files: " input_dir

# Validate directory existence
if [ ! -d "$input_dir" ]; then
   echo "Error: Directory '$input_dir' does not exist."
   exit 1
fi

# change to the input directory
cd "$input_dir" || exit

# count and convert JPG files to TIFF
conversion_count=0

# use nullglob to handle case when no .jpg files exist
shopt -s nullglob

# loop jpg files and convert
for jpg_file in *.jpg; do
   # check if file exists (due to nullglob)
   if [ -f "$jpg_file" ]; then
       # create tiff filename by replacing extension
       tiff_file="${jpg_file%.*}.tiff"

       # convert using ImageMagick(has to be installed)
       convert "$jpg_file" "$tiff_file"

       # check for conversion success
       if [ $? -eq 0 ]; then
           ((conversion_count++))
           echo "Converted: $jpg_file -> $tiff_file"
       else
           echo "Failed to convert: $jpg_file"
       fi
   fi
done


# disable nullglob
shopt -u nullglob

# conversion summary
if [ $conversion_count -eq 0 ]; then
   echo "No JPG files found in the specified directory."
else
   echo "-----------------------------------"
   echo "Total images converted: $conversion_count"
fi