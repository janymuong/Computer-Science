#!/bin/bash

# SCT211-0848/2018 - Jany Muong

# verify MD5 checksums of restored files
md5sum -c file_backup/jokes.txt.md5
md5sum -c file_backup/employees.json.md5
