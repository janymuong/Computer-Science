# OpenGL-Fruit-Bars - Gachororo:



## Fruit Preference Visualization with OpenGL

![Bar Chart Example](screenshot.png) *(Add screenshot after uploading)*

### Overview
OpenGL programs visualizing youth fruit preference survey data from Gachororo. Contains two implementations:
1. Standard bar chart filling the window
2. Chart starting at world coordinate (5,5) with reference grid

### Features
- Color-coded bars matching fruit colors
- Automatic window scaling
- Rotated text labels
- Axis labeling (red Y-axis, black X-axis)
- Coordinate system transformations

### Files
| File | Description |
|------|-------------|
| `a_fruit_bars.c` | Standard bar chart implementation |
| `b_fruit_bars.c` | Version starting at coordinate (5,5) |
| `a_fruit_bars.py` | Python version of standard chart |
| `b_fruit_bars.py` | Python version of (5,5) chart |

### Requirements
#### C Version
- OpenGL
- FreeGLUT
- GLEW

Install on Ubuntu:
```bash
sudo apt-get install freeglut3-dev libglew-dev
```

#### Python Version
```bash
pip install PyOpenGL PyOpenGL_accelerate PyGLM
```

### Compilation & Execution
#### C Programs
```bash
# Standard version
gcc a_fruit_bars.c -lglut -lGL -lGLEW -o partA
./partA

# (5,5) version 
gcc b_fruit_bars.c -lglut -lGL -lGLEW -o partB
./partB
```

#### Python Programs
```bash
./a_fruit_bars.py
./b_fruit_bars.py
```

### Group Members
- Jany Muong (SCT211-0848/2018)
- Joram Kireki (SCT211-0079/2022)
- Josphat Waweru Thumi (SCT211-0003/2022) 
- Akech Atem (SCT211-0535/2022)
