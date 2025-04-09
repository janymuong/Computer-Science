// bresenham.c - points from (1,5) to (2,8)
#include <GL/glew.h>
#include <GL/freeglut.h>
#include <GL/glut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>

// store points for drawing
struct Point {
    int x;
    int y;
};
struct Point points[1000];
int num_points = 0;

void drawCoordinateSystem() {
    // draw main axes
    glColor3f(0.5, 0.5, 0.5);
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
    glColor3f(0.2, 0.2, 0.2);
    glBegin(GL_LINES);
    for(int i = -10; i <= 10; i++) {
        if(i == 0) continue;
        // vertical lines
        glVertex2f(i, -10.0);
        glVertex2f(i, 10.0);
        // horizontal lines
        glVertex2f(-10.0, i);
        glVertex2f(10.0, i);
    }
    glEnd();

    // draw tick marks and numbers
    glColor3f(1.0, 1.0, 1.0);
    for(int i = -10; i <= 10; i++) {
        if(i == 0) continue;

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
        if(i != 0) {
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

void storePoint(int x, int y) {
    points[num_points].x = x;
    points[num_points].y = y;
    num_points++;
    printf("Point: (%d, %d)\n", x, y);
}

void computeAndPrintPoints(int x1, int y1, int x2, int y2) {
    num_points = 0;  // reset points array
    printf("\nIntermediate points for Bresenham's Algorithm:\n");
    printf("Starting point: (%d, %d)\n", x1, y1);

    int dx = abs(x2 - x1);
    int dy = abs(y2 - y1);
    int x = x1;
    int y = y1;
    int sx = x1 < x2 ? 1 : -1;
    int sy = y1 < y2 ? 1 : -1;
    int err = dx - dy;

    while (1) {
        storePoint(x, y);
        
        if (x == x2 && y == y2) break;
        
        int e2 = 2 * err; // error terms
        if (e2 > -dy) {
            err -= dy;
            x += sx;
        }
        if (e2 < dx) {
            err += dx;
            y += sy;
        }
    }
    
    printf("Ending point: (%d, %d)\n\n", x2, y2);
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // draw coordinate system
    drawCoordinateSystem();

    // draw the actual line first
    glColor3f(0.0, 1.0, 0.0);  // green
    glLineWidth(2.0);
    glBegin(GL_LINES);
        glVertex2i(1, 5);   // start point
        glVertex2i(2, 8);   // End point
    glEnd();

    // draw the computed points
    glColor3f(1.0, 1.0, 1.0);  // white color for computed points
    glPointSize(3.0);
    glBegin(GL_POINTS);
    for(int i = 0; i < num_points; i++) {
        glVertex2i(points[i].x, points[i].y);
    }
    glEnd();

    // draw endpoints
    glColor3f(1.0, 0.0, 0.0);  // red color for endpoints
    glPointSize(5.0);
    glBegin(GL_POINTS);
        glVertex2i(1, 5);  // start point
        glVertex2i(2, 8);  // end point
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
    glutCreateWindow("Bresenham's Line Algorithm");

    glewInit();
    init();

    // compute points
    computeAndPrintPoints(1, 5, 2, 8);

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}
