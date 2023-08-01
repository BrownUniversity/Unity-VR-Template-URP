#!/bin/bash

# Create Unity Template from Project
# This script takes a package folder from an existing package 
# and combines it with project files from a existing project 
# to make a new template archive (tgz file)

unity_version="2022.3.4f1"
template_path="/Applications/Unity/Hub/Editor/$unity_version/Unity.app/Contents/Resources/PackageManager/ProjectTemplates/"
project_path=$1
package_folder_path=$2

template_name="vrurp"
full_template_name="com.unity.template.$template_name"
template_display_name="VR using URP"
template_description="A template for VR apps using the Universal Render Pipeline"

err() {
  echo "[$(date +'%Y-%m-%dT%H:%M:%S%z')]: $*" >&2
}

log() {
  echo "[$(date +'%Y-%m-%dT%H:%M:%S%z')]: $*" >&1
}

delete_dir_contents() {
    # Check if the provided path is a directory
    if [ ! -d "$1" ]; then
        err "ERROR: '$1' is not a valid directory."
        exit 1
    fi

    # Prompt for confirmation
    read -p "Are you sure you want to delete all files and subdirectories in \n'$1'? (y/n): " confirm

    # Check user's confirmation
    if [[ "$confirm" != "y" && "$confirm" != "Y" ]]; then
        echo "Operation canceled."
        exit 0
    fi

    # Delete all files and subdirectories inside the directory
    echo "Deleting files and subdirectories in directory: $1"
    rm -rf "$1"/*
}

# read -p "Template name (no spaces or special characters): " template_name
# read -p "Template display name: " template_display_name
# read -p "Template description: " template_description

# Prompt for confirmation
read -p "Will copy project data from '$1' to '$2' package folder? (y/n): " confirm

# Check user's confirmation
if [[ "$confirm" != "y" && "$confirm" != "Y" ]]; then
    echo "Operation canceled."
    exit 0
fi

project_data_path="$package_folder_path/ProjectData~"

delete_dir_contents $project_data_path

ditto "$project_path/Assets" "$project_data_path/Assets"
ditto "$project_path/Packages" "$project_data_path/Packages"
ditto "$project_path/ProjectSettings" "$project_data_path/ProjectSettings"

rm "$project_data_path/ProjectSettings/ProjectVersion.txt"

# Go to package directory parent and then make tar file
cd "$package_folder_path/.."
tar -cvzf "$full_template_name.tgz" package

exit 0