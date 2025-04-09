# testing setup in python

from OpenGL.GL import *
from OpenGL.GLUT import *
from OpenGL.GLU import *



def display():
    glClear(GL_COLOR_BUFFER_BIT)
    glBegin(GL_TRIANGLES)
    glColor3f(1.0, 0.0, 0.0)
    glVertex2f(-0.5, -0.5)
    glColor3f(0.0, 1.0, 0.0)
    glVertex2f(0.5, -0.5)
    glColor3f(0.0, 0.0, 1.0)
    glVertex2f(0.0, 0.5)
    glEnd()
    glFlush()

glutInit()
glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB)
glutInitWindowSize(400, 400)
glutCreateWindow(b"OpenGL Test")
glutDisplayFunc(display)
glutMainLoop()

# pip install PyOpenGL PyOpenGL_accelerate PyGLM