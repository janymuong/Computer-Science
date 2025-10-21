## JSON structure:
> jupyter notebooks are **just JSON files** with a specific structure and some conventions - they look this way under the hood:

```json
{
  "cells": [
    {
      "cell_type": "code|markdown|raw",
      "source": ["code or text here"],
      "metadata": {},
      "outputs": [],
      "id": "uuid-here"
    }
  ],
  "metadata": {
    "kernelspec": {},
    "language_info": {}
  },
  "nbformat": 4,
  "nbformat_minor": 5
}
```

## components

### 1. **notebook metadata**
```json
"metadata": {
  "kernelspec": {
    "name": "python3",
    "display_name": "Python 3",
    "language": "python"
  },
  "language_info": {
    "name": "python",
    "version": "3.9.0",
    "mimetype": "text/x-python"
  }
}
```
- this lets jupyter know which programming language/kernel to use
- can include custom metadata for extensions

### 2. **cells array** - this is the core content
each cell has:
- **`cell_type`**: `"code"`, `"markdown"`, or `"raw"`
- **`source`**: array of strings containing the actual content
- **`metadata`**: settings for that cell
- **`id`**: unique identifier - is a`uuid` or random string in older notebooks formats 
- **`outputs`**: execution results (for code cells) 

### 3. **output:**
```json
"outputs": [
  {
    "output_type": "stream|display_data|execute_result|error",
    "name": "stdout|stderr",
    "text": ["hello world!\n"]
  },
  {
    "output_type": "display_data",
    "data": {
      "text/plain": "'hello world!'",
      "image/png": "base64-encoded-image-data"
    }
  }
]
```

## how jupyter works w/ JSON

### browser UI
> think of browser as your frontend for notebooks:
- **reads** the JSON file and renders cells as editable UI elements
- **watches** for changes and saves back to JSON
- **sends** code cells to the kernel for execution
- **receives** results and updates the `outputs` field

### kernel
> this is the exectuion engine 
- **receives** code from specific cells
- **executes** the code in the chosen language (Python, R, Julia, etc.)
- **returns** results (stdout, images, errors, etc.)
- **maintains** state between cell executions

### save/load cycle
1. you edit a cell in the browser
2. jupyter frontend updates the JSON structure in memory
3. auto-save writes the JSON back to the `.ipynb` file
4. when you execute a cell:
   - code sent to kernel
   - kernel executes and returns output
   - frontend updates cell's `outputs` array
   - JSON file is saved with new outputs

## cell execution:

**before execution:**
```json
{
  "cell_type": "code",
  "source": ["print('hello world!')\n", "x = 42"],
  "outputs": [],
  "metadata": {}
}
```

**after execution:**
```json
{
  "cell_type": "code", 
  "source": ["print('hello world!')\n", "x = 42"],
  "outputs": [
    {
      "output_type": "stream",
      "name": "stdout", 
      "text": ["hello world!\n"]
    }
  ],
  "metadata": {}
}
```


### MIME-type Outputs
jupyter supports rich outputs through MIME types:
```json
"data": {
  "text/plain": "42",
  "text/html": "<b>42</b>", 
  "image/png": "iVBORw0KGgoAAAANSUhEUg...",
  "application/json": "{\"answer\": 42}",
  "text/latex": "$42$"
}
```
the frontend chooses the best format to display.

### custom metadata
extensions can store their own data:
```json
"metadata": {
  "tags": ["hide-input", "important"],
  "collapsed": true,
  "scrolled": false,
  "my_extension": {"custom": "data"}
}
```

## you should like this JSON/jupyter notebook setup:

1. **human readable** (as JSON)
2. **version control friendly** (text-based diffs)
3. **extensible** (custom metadata, new output types)
4. **language agnostic** (any kernel can work with it)
5. **lool interoperability** (many tools can parse JSON)
   
   
> WRAPS: when you're working in Jupyter, you're essentially editing a structured JSON document that serves as both the presentation layer and the persistent storage format