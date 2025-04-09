// SCT211-0848/2018 - Jany Muong
#include <GL/glew.h>
#include <GL/freeglut.h>
#include <GL/glut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>

// function to draw the coordinate system (axes, grid, and labels)
void drawCoordinateSystem() {
    // draw main axes
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
        // horizontal lines
        glVertex2f(-10.0, i);
        glVertex2f(10.0, i);
    }
    glEnd();

    // draw tick marks and numbers
    glColor3f(1.0, 1.0, 1.0);  // white color for numbers
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

// function to compute intermediate points and print them
void computeAndPrintPoints(int x0, int y0, int x1, int y1) {
    int dx = x1 - x0, dy = y1 - y0;
    int steep = abs(dy) > abs(dx);

    if (steep) {
        int temp = x0; x0 = y0; y0 = temp;
        temp = x1; x1 = y1; y1 = temp;
    }
    if (x0 > x1) {
        int temp = x0; x0 = x1; x1 = temp;
        temp = y0; y0 = y1; y1 = temp;
    }

    dx = x1 - x0;
    dy = y1 - y0;
    float gradient = dx == 0 ? 1 : (float)dy / dx;

    float y = y0 + gradient;
    printf("\nIntermediate points for Xiaolin Wu's Algorithm:\n");
    printf("Starting point: (%d, %d)\n", x0, y0);
    for (int x = x0 + 1; x < x1; x++) {
        printf("Point: (%d, %d)\n", steep ? (int)y : x, steep ? x : (int)y);
        y += gradient;
    }
    // Correct the end point printing
    printf("Ending point: (%d, %d)\n\n", steep ? y1 : x1, steep ? x1 : y1);
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);

    // draw coordinate system
    drawCoordinateSystem();

    // draw the line in green
    glColor3f(0.0, 1.0, 0.0);  // green color for the line
    glLineWidth(2.0);
    glBegin(GL_LINES);
        glVertex2i(1, 1);  // start point
        glVertex2i(3, 5);  // end point
    glEnd();

    // draw endpoints as points
    glColor3f(1.0, 0.0, 0.0);  // red color for points
    glPointSize(5.0);
    glBegin(GL_POINTS);
        glVertex2i(1, 1);  // start point
        glVertex2i(3, 5);  // end point
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
    glutCreateWindow("Xiaolin Wu's Line Algorithm");

    glewInit();
    init();

    // compute and print intermediate points
    computeAndPrintPoints(1, 1, 3, 5);

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}