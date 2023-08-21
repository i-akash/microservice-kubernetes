#!/bin/bash

# Function to recursively apply YAML files
apply_yaml_files() {
  local dir="$1"
  
  for yaml_file in "$dir"/*.yaml; do
    if [[ -f "$yaml_file" ]]; then
      echo "Applying $yaml_file"
      kubectl apply -f "$yaml_file"
    fi
  done
  
  for subdir in "$dir"/*; do
    if [ -d "$subdir" ]; then
      echo "Subdir: $subdir"
      apply_yaml_files "$subdir"
    fi
  done
}

# Specify the root directory
root_directory="$pwd"

# Navigate to the root directory
cd "$root_directory"

# Start applying YAML files recursively
apply_yaml_files .

echo "Finished applying YAML files."
