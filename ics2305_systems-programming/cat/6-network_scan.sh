#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# 6-network_scan:
# script to scan the network for hosts attached to an IP address and check if the host is up.

# prompt user for the IP address or range
echo "Enter the IP address or network range (e.g., 192.168.1.0/24):"
read ip_range

# check if the IP range is provided
if [ -z "$ip_range" ]; then
    echo "Error: No IP address or range provided."
    exit 1
fi

# scan the IP range for active hosts, show their status
echo "Scanning the network for hosts attached to $ip_range:"
echo "-----------------------------------------------------"
nmap -sn "$ip_range" | while read line; do
    # look for  if 'Host is up' in the nmap output
    if echo "$line" | grep -q "Host is up"; then
        # extract the IP address
        ip_address=$(echo "$line" | awk '{print $2}')
        echo "Host $ip_address is up (Yes)"
    fi
done
