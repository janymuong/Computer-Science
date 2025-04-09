// SCT211-0848/2018 - Jany Muong
// 1b_circumscribed_triangle.c - program to draw a triangle and circle on on its vertices

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
    glColor3f(0.2, 0.2, 0.2);  // grid color
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
        if(i == 0) continue; // skip origin
        
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

// function to draw a circle outline
void drawCircleOutline(float cx, float cy, float radius) {
    int num_segments = 100;
    glLineWidth(2.0);
    glBegin(GL_LINE_LOOP);
    for (int i = 0; i < num_segments; i++) {
        float angle = 2.0f * M_PI * i / num_segments;
        float x = radius * cosf(angle);
        float y = radius * sinf(angle);
        glVertex2f(cx + x, cy + y);
    }
    glEnd();
}

// function to draw a filled circle with transparency
void drawFilledCircle(float cx, float cy, float radius) {
    int num_segments = 100;
    glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
    glBegin(GL_TRIANGLE_FAN);
    glColor4f(1.0, 0.0, 0.0, 0.3);  // red color with 0.3 alpha (transparency - I am doing this to make the triangle visible)
    glVertex2f(cx, cy);  // center of the circle(centroid though we cannot see it on my OpenGL display)
    for (int i = 0; i <= num_segments; i++) {
        float angle = 2.0f * M_PI * i / num_segments;
        float x = radius * cosf(angle);
        float y = radius * sinf(angle);
        glVertex2f(cx + x, cy + y);
    }
    glEnd();
    glDisable(GL_BLEND);
    
    // draw the outline with solid color
    glColor3f(1.0, 0.0, 0.0);  // solid red for outline
    drawCircleOutline(cx, cy, radius);
}

// function to draw text in the scene
void drawText(const char* text, float x, float y) {
    glRasterPos2f(x, y);
    for(const char* c = text; *c != '\0'; c++) {
        glutBitmapCharacter(GLUT_BITMAP_9_BY_15, *c);
    }
}

// function to calculate the circumcircle of a triangle
void calculateCircumcircle(float x1, float y1, float x2, float y2, float x3, float y3, float *cx, float *cy, float *radius) {
    // using a circumcenter formula 
    float D = 2 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
    
    // check if D is too close to zero ( for collinear points)
    if (fabs(D) < 0.0001) {
        // handle collinear points by using centroid as fallback
        *cx = (x1 + x2 + x3) / 3.0;
        *cy = (y1 + y2 + y3) / 3.0;
        
        // use the distance to the farthest vertex as radius
        float d1 = sqrt((*cx - x1) * (*cx - x1) + (*cy - y1) * (*cy - y1));
        float d2 = sqrt((*cx - x2) * (*cx - x2) + (*cy - y2) * (*cy - y2));
        float d3 = sqrt((*cx - x3) * (*cx - x3) + (*cy - y3) * (*cy - y3));
        
        *radius = fmax(d1, fmax(d2, d3));
        return;
    }
    
    // compute the squared lengths of the sides of the triangle
    float a_squared = (x1*x1) + (y1*y1);
    float b_squared = (x2*x2) + (y2*y2);
    float c_squared = (x3*x3) + (y3*y3);
    
    // compute the circumcenter
    *cx = (a_squared * (y2 - y3) + b_squared * (y3 - y1) + c_squared * (y1 - y2)) / D;
    *cy = (a_squared * (x3 - x2) + b_squared * (x1 - x3) + c_squared * (x2 - x1)) / D;
    
    // compute the circumradius
    *radius = sqrt((*cx - x1) * (*cx - x1) + (*cy - y1) * (*cy - y1));
}

// draw a point at a specific location
void drawPoint(float x, float y, float size, float r, float g, float b) {
    glPointSize(size);
    glColor3f(r, g, b);
    glBegin(GL_POINTS);
        glVertex2f(x, y);
    glEnd();
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // draw coordinate system
    drawCoordinateSystem();

    // define the triangle vertices
    float x1 = -1.0, y1 = 6.0;
    float x2 = 2.0, y2 = 0.0;
    float x3 = -4.0, y3 = 9.0;

    // draw the triangle
    glColor3f(0.0, 0.0, 1.0);  // blue color for the triangle
    glBegin(GL_TRIANGLES);
        glVertex2f(x1, y1);
        glVertex2f(x2, y2);
        glVertex2f(x3, y3);
    glEnd();
    
    // draw the triangle outline for better visibility
    glColor3f(0.0, 0.7, 1.0);  // Light blue color for outline
    glLineWidth(2.0);
    glBegin(GL_LINE_LOOP);
        glVertex2f(x1, y1);
        glVertex2f(x2, y2);
        glVertex2f(x3, y3);
    glEnd();

    // calculate the circumcircle
    float cx, cy, radius;
    calculateCircumcircle(x1, y1, x2, y2, x3, y3, &cx, &cy, &radius);

    // draw the circumcircle
    drawFilledCircle(cx, cy, radius);
    
    // draw and label the triangle vertices
    drawPoint(x1, y1, 8.0, 1.0, 1.0, 0.0);  // yellow
    drawPoint(x2, y2, 8.0, 1.0, 1.0, 0.0);  // yellow
    drawPoint(x3, y3, 8.0, 1.0, 1.0, 0.0);  // yellow
    
    // draw and label the circumcenter
    drawPoint(cx, cy, 8.0, 0.0, 1.0, 0.0);  // Green
    
    // label the vertices
    glColor3f(1.0, 1.0, 1.0);  // white text
    drawText("(-1,6)", x1 - 0.5, y1 + 0.5);
    drawText("(2,0)", x2 + 0.5, y2 - 0.5);
    drawText("(-4,9)", x3 - 0.5, y3 + 0.5);
    
    // label the circumcenter and radius
    char circleInfo[50];
    sprintf(circleInfo, "Circumcenter: (%.2f, %.2f)", cx, cy);
    drawText(circleInfo, cx - 3, cy - 0.7);
    sprintf(circleInfo, "Radius: %.2f", radius);
    drawText(circleInfo, cx - 3, cy - 1.3);

    glFlush();
}

void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0);  // black background
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(-10, 10, -10, 10);  // coordinate system - grid 20 by 20
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(800, 800);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("ICS2311 CAT Question 1(b) - Triangle and Circumcircle");

    glewInit();
    init();

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}