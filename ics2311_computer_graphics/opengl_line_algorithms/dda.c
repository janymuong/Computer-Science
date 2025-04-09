// SCT211-0848/2018 - Jany Muong
// dda.c - DIGITAL DIFFERENTIAL ANALYZER
#include <GL/glew.h>
#include <GL/freeglut.h>
#include <GL/glut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>

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
    glColor3f(0.2, 0.2, 0.2);  // grid
    glBegin(GL_LINES);
    for(int i = -10; i <= 10; i++) {
        if(i == 0) continue; // skip the axes
        // vertical lines
        glVertex2f(i, -10.0);
        glVertex2f(i, 10.0);
        // horizontal lines
        glVertex2f(-10.0, i);
        glVertex2f(10.0, i);
    }
    glEnd();

    // draw tick marks and numbers
    glColor3f(1.0, 1.0, 1.0);  // White color for numbers
    for(int i = -10; i <= 10; i++) {
        if(i == 0) continue; // Skip origin
        
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
        for(char* c = str; *c != '\0'; c++) {
            glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
        }
        
        // y-axis numbers
        if(i != 0) {  // Skip 0 for y-axis
            glRasterPos2f(-0.6, i - 0.1);
            sprintf(str, "%d", i);
            for(char* c = str; *c != '\0'; c++) {
                glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
            }
        }
    }

    // draw origin "0"
    glRasterPos2f(-0.4, -0.6);
    glutBitmapCharacter(GLUT_BITMAP_8_BY_13, '0');
}

void computeAndPrintPoints(int x0, int y0, int x1, int y1) {
    int dx = x1 - x0, dy = y1 - y0, steps;
    float xInc, yInc, x = x0, y = y0;

    steps = abs(dx) > abs(dy) ? abs(dx) : abs(dy);
    xInc = dx / (float)steps;
    yInc = dy / (float)steps;

    printf("\nIntermediate points for DDA Algorithm:\n");
    printf("Starting point: (%d, %d)\n", x0, y0);
    for (int i = 0; i <= steps; i++) {
        printf("Point: (%d, %d)\n", (int)round(x), (int)round(y));
        x += xInc;
        y += yInc;
    }
    printf("Ending point: (%d, %d)\n\n", x1, y1);
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // draw coordinate system
    drawCoordinateSystem();

    // draw the line in green
    glColor3f(0.0, 1.0, 0.0);
    glLineWidth(2.0);
    glBegin(GL_LINES);
        glVertex2i(5, 2);  // start point
        glVertex2i(10, 3); // end point
    glEnd();

    // draw endpoints as points
    glColor3f(1.0, 0.0, 0.0);  // red color for points
    glPointSize(5.0);
    glBegin(GL_POINTS);
        glVertex2i(5, 2);  // start point
        glVertex2i(10, 3); // end point
    glEnd();

    glFlush();
}

void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(-10, 10, -10, 10);
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(800, 800);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("DDA Line-Drawing Algorithm");

    glewInit();
    init();

    // compute and print points
    computeAndPrintPoints(5, 2, 10, 3);

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}