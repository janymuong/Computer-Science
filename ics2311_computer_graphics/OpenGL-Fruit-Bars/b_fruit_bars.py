#!/usr/bin/env python

from OpenGL.GL import *
from OpenGL.GLUT import *
from OpenGL.GLU import *
import sys

# Fruit data - same as part A
fruits = [
    {"name": "Avocado", "count": 36, "color": [0.34, 0.51, 0.01]},  # dark green
    {"name": "Orange", "count": 41, "color": [1.00, 0.65, 0.00]},   # orange color
    {"name": "Banana", "count": 19, "color": [0.89, 0.81, 0.34]},   # yellow
    {"name": "Kiwifruit", "count": 28, "color": [0.62, 0.89, 0.31]}, # kiwi green
    {"name": "Mangos", "count": 30, "color": [1.00, 0.78, 0.25]},    # mango orange
    {"name": "Grapes", "count": 16, "color": [0.50, 0.19, 0.58]}     # purple
]
num_fruits = len(fruits)
window_width, window_height = 800, 600

# Offset for the chart (starting point at (5,5))
x_offset = 5.0
y_offset = 5.0

def reshape(width, height):
    global window_width, window_height
    window_width, window_height = width, height
    glViewport(0, 0, width, height)
    glutPostRedisplay()

def draw_text(text, x, y, r, g, b):
    glColor3f(r, g, b)
    glRasterPos2f(x, y)
    for c in text:
        glutBitmapCharacter(GLUT_BITMAP_9_BY_15, ord(c))

def draw_base_coordinate_system():
    # Draw main world axes
    glColor3f(0.5, 0.5, 0.5)  # gray color for base axes
    glLineWidth(1.0)
    glBegin(GL_LINES)
    glVertex2f(0.0, 0.0); glVertex2f(12.0, 0.0)  # x-axis
    glVertex2f(0.0, 0.0); glVertex2f(0.0, 12.0)  # y-axis
    glEnd()
    
    # Label the axes
    draw_text("0", -0.3, -0.3, 0.5, 0.5, 0.5)  # Origin
    draw_text("X", 12.2, 0.0, 0.5, 0.5, 0.5)   # X-axis
    draw_text("Y", 0.0, 12.2, 0.5, 0.5, 0.5)   # Y-axis
    draw_text("World Coordinate System", 2.0, 11.5, 0.5, 0.5, 0.5)

    # Grid lines (lighter)
    glColor3f(0.3, 0.3, 0.3)
    glLineWidth(0.5)
    glBegin(GL_LINES)
    for i in range(1, 13):
        glVertex2f(i, 0.0); glVertex2f(i, 12.0)  # vertical
        glVertex2f(0.0, i); glVertex2f(12.0, i)  # horizontal
    glEnd()
    
    # Label key grid points
    for i in range(1, 13):
        if i % 2 == 0 or i == 5:  # only label even numbers and 5
            draw_text(str(i), i - 0.1, -0.3, 0.5, 0.5, 0.5)  # x-axis labels
            draw_text(str(i), -0.3, i - 0.1, 0.5, 0.5, 0.5)  # y-axis labels

    # Highlight the starting point (5,5) with a red dot
    glColor3f(1.0, 0.0, 0.0)
    glPointSize(8.0)
    glBegin(GL_POINTS)
    glVertex2f(x_offset, y_offset)
    glEnd()
    
    # Draw arrow pointing to (5,5)
    glColor3f(1.0, 0.0, 0.0)
    glLineWidth(1.5)
    glBegin(GL_LINES)
    glVertex2f(x_offset + 0.1, y_offset + 0.1)
    glVertex2f(x_offset + 0.2, y_offset + 0.2)
    glEnd()

def draw_chart_axes():
    # Draw y-axis (red)
    glColor3f(1.0, 0.0, 0.0)
    glLineWidth(2.0)
    glBegin(GL_LINES)
    glVertex2f(x_offset, y_offset)
    glVertex2f(x_offset, y_offset + 5.0)
    glEnd()

    # Draw x-axis (black)
    glColor3f(0.0, 0.0, 0.0)
    glBegin(GL_LINES)
    glVertex2f(x_offset, y_offset)
    glVertex2f(x_offset + 8.0, y_offset)
    glEnd()
    
    # Label the axes
    draw_text("Chart X-Axis", x_offset + 8.2, y_offset, 0.0, 0.0, 0.0)
    draw_text("Chart Y-Axis", x_offset - 0.5, y_offset + 5.2, 1.0, 0.0, 0.0)
    
    # Add y-axis ticks and labels (red)
    glColor3f(1.0, 0.0, 0.0)
    for i in range(0, 51, 10):
        y = y_offset + (i / 50.0) * 5.0
        glBegin(GL_LINES)
        glVertex2f(x_offset - 0.1, y)
        glVertex2f(x_offset, y)
        glEnd()
        draw_text(str(i), x_offset - 0.5, y - 0.1, 1.0, 0.0, 0.0)

def display():
    glClear(GL_COLOR_BUFFER_BIT)
    
    # Draw the base coordinate system to show where (5,5) is
    draw_base_coordinate_system()
    
    # Draw the chart axes starting at (5,5)
    draw_chart_axes()

    # Draw title
    draw_text("Youth Fruit Preferences in Gachororo (Starting at 5,5)", 2.0, 11.0, 1.0, 1.0, 1.0)
    draw_text("Total Participants: 170", 2.0, 10.5, 1.0, 1.0, 1.0)
    
    # Draw axes labels
    draw_text("Fruit Type", x_offset + 4.0, y_offset - 0.5, 0.0, 0.0, 0.0)

    # Calculate dimensions for the bars
    bar_width = 0.8
    bar_spacing = 0.4
    max_bar_height = 5.0  # maximum height based on y-axis scale
    start_x = x_offset + 0.5

    # Draw bars
    for fruit in fruits:
        bar_height = (fruit["count"] / 50.0) * max_bar_height
        
        # Ensure minimum height for visibility
        if bar_height < 0.1:
            bar_height = 0.1
        
        # Draw bar with fruit color
        glColor3fv(fruit["color"])
        glBegin(GL_QUADS)
        glVertex2f(start_x, y_offset)
        glVertex2f(start_x + bar_width, y_offset)
        glVertex2f(start_x + bar_width, y_offset + bar_height)
        glVertex2f(start_x, y_offset + bar_height)
        glEnd()

        # Draw outline around bar
        glColor3f(0.8, 0.8, 0.8)
        glLineWidth(1.0)
        glBegin(GL_LINE_LOOP)
        glVertex2f(start_x, y_offset)
        glVertex2f(start_x + bar_width, y_offset)
        glVertex2f(start_x + bar_width, y_offset + bar_height)
        glVertex2f(start_x, y_offset + bar_height)
        glEnd()

        # Draw value at top of bar
        draw_text(str(fruit["count"]), start_x + bar_width/2 - 0.2, y_offset + bar_height + 0.2, 0.0, 0.0, 0.0)

        # Draw fruit name below bar (rotated)
        glPushMatrix()
        glTranslatef(start_x + bar_width/2, y_offset - 0.2, 0)
        glRotatef(-45, 0, 0, 1)
        draw_text(fruit["name"], 0, 0, 1.0, 1.0, 1.0)
        glPopMatrix()

        start_x += bar_width + bar_spacing

    glFlush()

def init():
    glClearColor(0.0, 0.0, 0.0, 1.0)  # black background
    glMatrixMode(GL_PROJECTION)
    glLoadIdentity()
    gluOrtho2D(-1, 14, -1, 14)  # extended viewport
    glMatrixMode(GL_MODELVIEW)
    glLoadIdentity()

def main():
    glutInit(sys.argv)
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB)
    glutInitWindowSize(window_width, window_height)
    glutInitWindowPosition(100, 100)
    glutCreateWindow(b"ICS2311 Group 7: Fruit Preference Survey (Starting at 5,5)")
    
    init()
    glutDisplayFunc(display)
    glutReshapeFunc(reshape)
    glutMainLoop()

if __name__ == "__main__":
    main()