// SCT211-0848/2018 - Jany Muong
// midpoint.c
#include <GL/glew.h>
#include <GL/freeglut.h>
#include <GL/glut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>

// function to draw the coordinate system (axes, grid, and labels)
void drawCoordinateSystem() {
    // main axes
    glColor3f(0.5, 0.5, 0.5);  // gray color for axes
    glLineWidth(2.0);
    glBegin(GL_LINES);
        // x-axis
        glVertex2f(-10.0, 0.0);
        glVertex2f(10.0, 0.0);
        // y-axis
        glVertex2f(0.0, -10.0);
        glVertex2f(0.0, 10.0);
    glEnd();

    // draw grid lines
    glLineWidth(1.0);
    glColor3f(0.2, 0.2, 0.2);  // grid color
    glBegin(GL_LINES);
    for (int i = -10; i <= 10; i++) {
        if (i == 0) continue; // skip the axes
        // vertical lines
        glVertex2f(i, -10.0);
        glVertex2f(i, 10.0);
        // Horizontal lines
        glVertex2f(-10.0, i);
        glVertex2f(10.0, i);
    }
    glEnd();

    // draw tick marks and numbers
    glColor3f(1.0, 1.0, 1.0);  // White color for numbers
    for (int i = -10; i <= 10; i++) {
        if (i == 0) continue; // Skip origin

        // draw tick marks
        glBegin(GL_LINES);
            // x-axis ticks
            glVertex2f(i, -0.2);
            glVertex2f(i, 0.2);
            // y-axis ticks
            glVertex2f(-0.2, i);
            glVertex2f(0.2, i);
        glEnd();

        // draw numbers
        char str[10];

        // x-axis numbers
        glRasterPos2f(i - 0.1, -0.6);
        sprintf(str, "%d", i);
        for (char* c = str; *c != '\0'; c++) {
            glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
        }

        // y-axis numbers
        if (i != 0) {  // Skip 0 for y-axis
            glRasterPos2f(-0.6, i - 0.1);
            sprintf(str, "%d", i);
            for (char* c = str; *c != '\0'; c++) {
                glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
            }
        }
    }

    // draw origin "0"
    glRasterPos2f(-0.4, -0.6);
    glutBitmapCharacter(GLUT_BITMAP_8_BY_13, '0');
}

// function to compute intermediate points using midpoint algorithm
void computeAndPrintPoints(int x0, int y0, int x1, int y1) {
    int dx = abs(x1 - x0);
    int dy = abs(y1 - y0);
    int sx = (x0 < x1) ? 1 : -1;
    int sy = (y0 < y1) ? 1 : -1;
    int err = dx - dy;

    printf("\nIntermediate points for Midpoint Algorithm:\n");
    printf("Starting point: (%d, %d)\n", x0, y0);
    while (1) {
        printf("Point: (%d, %d)\n", x0, y0);
        if (x0 == x1 && y0 == y1) break;

        int e2 = 2 * err;
        if (e2 > -dy) {
            err -= dy;
            x0 += sx;
        }
        if (e2 < dx) {
            err += dx;
            y0 += sy;
        }
    }
    printf("Ending point: (%d, %d)\n\n", x1, y1);
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);

    // draw coordinate system
    drawCoordinateSystem();

    // draw the line in green
    glColor3f(0.0, 1.0, 0.0);  // green color for the line
    glLineWidth(2.0);
    glBegin(GL_LINES);
        glVertex2i(-3, 4);  // start point
        glVertex2i(5, -2);  // end point
    glEnd();

    // draw endpoints as points
    glColor3f(1.0, 0.0, 0.0);  // red color for points
    glPointSize(5.0);
    glBegin(GL_POINTS);
        glVertex2i(-3, 4);  // start point
        glVertex2i(5, -2);  // end point
    glEnd();

    glFlush();
}

// initialize OpenGL
void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0);  // background
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(-10, 10, -10, 10);  // cartesian plane calibration
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(800, 800);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("Midpoint Line-Drawing Algorithm (-3, 4) to (5, -2)");

    glewInit();
    init();

    // compute and print intermediate points
    computeAndPrintPoints(-3, 4, 5, -2);

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}
