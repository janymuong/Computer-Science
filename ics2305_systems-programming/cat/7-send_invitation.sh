#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 7-send_invitation:
# script to send a personalized email invitation to each student from a file

# check if the text file is provided
if [ $# -eq 0 ]; then
    echo "Usage: $0 <student_file>"
    exit 1
fi

# read the student file
student_file=$1

# check if the file exists
if [ ! -f "$student_file" ]; then
    echo "Error: File '$student_file' doesn't exist"
    exit 1
fi

# invitation template
invitation="Inviting you as our computing student to our 21st Open Webinar on skills optimization by jhubAfrica scheduled for Friday, 29th November from 5:00 P.M. The Zoom link for joining in on Friday is as given below. We shall also broadcast the webinar on our YouTube channel. YouTube link: https://youtu.be/ONVTA7LKMIs"

# read the file and send emails
while IFS=',' read -r name email; do
    # skip the header row if present
    if [[ "$name" == "name" ]]; then
        continue
    fi

    # construct the email body
    email_body="Hello $name,

$invitation

Best regards,
Department of Computing"

    # send the email using `mail` (ensure `mail` is installed and configured)
    echo "$email_body" | mail -s "Invitation to 21st Open Webinar" "$email"

    # print message for verification
    echo "Invitation sent to $name at $email"
done < "$student_file"

echo "Thank you, from JHUB"
