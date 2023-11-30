#!/bin/bash

# Set the input and output directories
SVG_DIRECTORY="svg"
PNG_DIRECTORY="png"

# Use find to locate all SVG files in the directory
find "$SVG_DIRECTORY" -name "*.svg" -type f | while read -r svg_file; do
    # Extract file name without extension
    base_name=$(basename -- "$svg_file")
    file_name="${base_name%.*}"

    # Output file path
    png_file="$PNG_DIRECTORY/$file_name.png"

    # Convert SVG to PNG using rsvg-convert
    rsvg-convert -f png -o "$png_file" "$svg_file"

    echo "Converted $svg_file to $png_file"
done

echo "Conversion complete!"
