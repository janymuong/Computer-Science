// SCT211-0848/2018 - Jany Muong
// 1a_bresenham_and_rotate_circle.c - file to draw and rotate a circle with visual indicators

#include <GL/glew.h>
#include <GL/freeglut.h>
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
    glColor3f(0.2, 0.2, 0.2);  // Grid color
    glBegin(GL_LINES);
    for(int i = -10; i <= 10; i++) {
        if(i == 0) continue; // Skip the axes
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
        if(i != 0) {  // skip 0 for y-axis
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

// function to draw a circle using Bresenham's Circle Drawing Algorithm
void drawBresenhamCircle(int cx, int cy, int radius) {
    int x = 0, y = radius;
    int d = 3 - 2 * radius;

    glBegin(GL_POINTS);
    while (x <= y) {
        // plot points in all octants
        glVertex2i(cx + x, cy + y);
        glVertex2i(cx - x, cy + y);
        glVertex2i(cx + x, cy - y);
        glVertex2i(cx - x, cy - y);
        glVertex2i(cx + y, cy + x);
        glVertex2i(cx - y, cy + x);
        glVertex2i(cx + y, cy - x);
        glVertex2i(cx - y, cy - x);

        if (d < 0) {
            d = d + 4 * x + 6;
        } else {
            d = d + 4 * (x - y) + 10;
            y--;
        }
        x++;
    }
    glEnd();
}

// function to draw a filled circle
void drawFilledCircle(float cx, float cy, float radius) {
    int num_segments = 100;
    glBegin(GL_TRIANGLE_FAN);
    glVertex2f(cx, cy);  // Center of the circle
    for (int i = 0; i <= num_segments; i++) {
        float angle = 2.0f * M_PI * i / num_segments;
        float x = radius * cosf(angle);
        float y = radius * sinf(angle);
        glVertex2f(cx + x, cy + y);
    }
    glEnd();
}

// function to draw a line with a label
void drawLineWithLabel(float x1, float y1, float x2, float y2, const char* label) {
    glBegin(GL_LINES);
    glVertex2f(x1, y1);
    glVertex2f(x2, y2);
    glEnd();

    // draw label at the midpoint of the line
    float midX = (x1 + x2) / 2;
    float midY = (y1 + y2) / 2;
    glRasterPos2f(midX, midY);
    for (const char* c = label; *c != '\0'; c++) {
        glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
    }
}

// function to draw a point with a label
void drawPointWithLabel(float x, float y, const char* label) {
    glPointSize(5.0);
    glBegin(GL_POINTS);
    glVertex2f(x, y);
    glEnd();

    // draw label next to the point
    glRasterPos2f(x + 0.2, y + 0.2);
    for (const char* c = label; *c != '\0'; c++) {
        glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
    }
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // draw coordinate system
    drawCoordinateSystem();

    // draw the original circle using Bresenham's algorithm
    glColor3f(0.0, 0.0, 1.0);  // blue color for original circle
    drawBresenhamCircle(1, 1, 4);  // center at (1, 1), radius = 4

    // label the center of the circle
    drawPointWithLabel(1.0, 1.0, "(1, 1)");

    // draw a reference line (radius) before rotation
    glColor3f(0.0, 1.0, 0.0);  // Green color for reference line
    drawLineWithLabel(1.0, 1.0, 5.0, 1.0, "4 cm");

    // mark the original point on the circumference
    char originalLabel[20];
    sprintf(originalLabel, "(5, 1)");
    drawPointWithLabel(5.0, 1.0, originalLabel);

    // rotate the circle 60 degrees clockwise using OpenGL transformations
    glPushMatrix();  // save the current matrix
    glTranslatef(1.0, 1.0, 0.0);  // Translate to the circle's center
    glRotatef(60.0, 0.0, 0.0, 1.0);  // rotate 60 degrees clockwise
    glTranslatef(-1.0, -1.0, 0.0);  // translate back

    // draw the rotated and filled circle
    glColor3f(1.0, 0.0, 0.0);  // Red color for rotated circle
    drawFilledCircle(1.0, 1.0, 4.0);  // Center at (1, 1), radius = 4

    // calculate the rotated point on the circumference
    float rotatedX = 1.0 + 4 * cos(60.0 * M_PI / 180.0);
    float rotatedY = 1.0 + 4 * sin(60.0 * M_PI / 180.0);

    // mark the final (rotated) point on the circumference
    char rotatedLabel[20];
    sprintf(rotatedLabel, "(%.1f, %.1f)", rotatedX, rotatedY);
    drawPointWithLabel(rotatedX, rotatedY, rotatedLabel);

    glPopMatrix();  // restore the original matrix

    // draw the angle label (60 degrees)
    glColor3f(1.0, 1.0, 1.0);  // white color for angle label
    glRasterPos2f(2.0, 1.5);
    const char* angleLabel = "60 degrees";
    for (const char* c = angleLabel; *c != '\0'; c++) {
        glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
    }

    glFlush();
}

void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0);  // black background
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(-10, 10, -10, 10);  // coordinate system 20 by 20
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(800, 800);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("ICS2311 CAT Question 1(a) - Bresenham Circle");

    glewInit();
    init();

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}