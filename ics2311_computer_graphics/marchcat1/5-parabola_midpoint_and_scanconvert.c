// SCT211-0848/2018 - Jany Muong
// 5-parabola_midpoint_and_scanconvert.c:
// OpenGL program to scan convert the parabola x = y^2 using midpoint method

#include <GL/glew.h>
#include <GL/freeglut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>

// storing points for visualization of midpoint method
#define MAX_POINTS 1000
int numPoints = 0;
float pointsX[MAX_POINTS];
float pointsY[MAX_POINTS];
float midpointX[MAX_POINTS];
float midpointY[MAX_POINTS];
int isMidpointBelow[MAX_POINTS]; // 1 if below the curve, 0 if above

void plotPixel(float x, float y) {
    // store the point for later rendering
    if (numPoints < MAX_POINTS) {
        pointsX[numPoints] = x;
        pointsY[numPoints] = y;
        numPoints++;
    }
}

void scanConvertParabola() {
    // clear previous points
    numPoints = 0;
    int midpointCount = 0;
    
    // midpoint method to draw the parabola x = y^2
    // starting with the interval -10 ≤ y ≤ 10
    
    // since the parabola is symmetric about the x-axis, we can compute
    // for 0 ≤ y ≤ 10 and mirror for negative y
    
    // for x = y^2, the slope dy/dx = 1/(2y)
    // in regions where |slope| < 1, we increment x and compute y
    // in regions where |slope| > 1, we increment y and compute x
    
    // for a parabola x = y^2, |slope| = 1/(2|y|) < 1 when |y| > 0.5
    // So for |y| > 0.5, we increment y and compute x
    
    // compute points for y ≥ 0.5
    float y = 0.5;
    float x = y * y;
    
    // plot the starting point
    plotPixel(x, y);
    plotPixel(x, -y); // Use symmetry about the x-axis
    
    while (y <= 10.0) {
        // for the parabola x = y^2, we decide whether to choose
        // (x, y+1) or (x+1, y+1) as our next point
        
        // midpoint calculation: (x, y+0.5)
        float midX = x;
        float midY = y + 0.5;
        float midXOnCurve = midY * midY; // x-value on the curve at midY
        
        if (midpointCount < MAX_POINTS) {
            midpointX[midpointCount] = midX;
            midpointY[midpointCount] = midY;
            
            // determine if midpoint is below or above the curve
            if (midX < midXOnCurve) {
                // midpoint is below the curve
                isMidpointBelow[midpointCount] = 1;
                // choose (x+1, y+1)
                x = x + 1;
            } else {
                // midpoint is above the curve
                isMidpointBelow[midpointCount] = 0;
                // choose (x, y+1)
            }
            midpointCount++;
        }
        
        y = y + 1;
        
        // plot this point
        plotPixel(x, y);
        plotPixel(x, -y); // use symmetry about the x-axis
    }
    
    // compute points for 0 ≤ y < 0.5
    // for small y values, the slope is very steep, so increment x and compute y
    x = 0.0;
    float yOnCurve = sqrt(x);
    
    // plot the starting point (0,0)
    plotPixel(x, 0.0);
    
    while (x <= 0.25) { // 0.25 = (0.5)^2
        // for each x, compute the corresponding y
        float nextX = x + 1;
        float nextYOnCurve = sqrt(nextX);
        
        // midpoint calculation: (x+0.5, y)
        float midX = x + 0.5;
        float midY = yOnCurve;
        float midYOnCurve = sqrt(midX);
        
        if (midpointCount < MAX_POINTS) {
            midpointX[midpointCount] = midX;
            midpointY[midpointCount] = midY;
            
            // determine if midpoint is below or above the curve
            if (midY < midYOnCurve) {
                // midpoint is below the curve
                isMidpointBelow[midpointCount] = 1;
                // choose (x+1, y+1)
                x = nextX;
                yOnCurve = nextYOnCurve;
            } else {
                // midpoint is above the curve
                isMidpointBelow[midpointCount] = 0;
                // choose (x+1, y)
                x = nextX;
                // yOnCurve stays the same
            }
            midpointCount++;
        }
        
        // plot this point
        plotPixel(x, yOnCurve);
        plotPixel(x, -yOnCurve); // Use symmetry about the x-axis
    }
}

void drawCoordinateSystem() {
    // draw main axes
    glColor3f(0.5, 0.5, 0.5);  // gray color for axes
    glLineWidth(2.0);
    glBegin(GL_LINES);
        // x-axis
        glVertex2f(-10.0, 0.0);
        glVertex2f(110.0, 0.0);
        // y-axis
        glVertex2f(0.0, -10.0);
        glVertex2f(0.0, 10.0);
    glEnd();

    // draw grid lines
    glLineWidth(1.0);
    glColor3f(0.2, 0.2, 0.2);  // grid color
    glBegin(GL_LINES);
    for(int i = -10; i <= 110; i += 10) {
        if(i == 0) continue; // skip the axes
        // vertical lines
        glVertex2f(i, -10.0);
        glVertex2f(i, 10.0);
    }
    for(int i = -10; i <= 10; i += 1) {
        if(i == 0) continue; // skip the axes
        // horizontal lines
        glVertex2f(-10.0, i);
        glVertex2f(110.0, i);
    }
    glEnd();

    // draw tick marks and numbers
    glColor3f(1.0, 1.0, 1.0);  // White color for numbers
    for(int i = -10; i <= 110; i += 10) {
        if(i == 0) continue; // skip origin
        
        // draw x-axis tick marks
        glBegin(GL_LINES);
            glVertex2f(i, -0.2);
            glVertex2f(i, 0.2);
        glEnd();
        
        // draw x-axis numbers
        char str[10];
        glRasterPos2f(i - 1.0, -0.6);
        sprintf(str, "%d", i);
        for(char* c = str; *c != '\0'; c++) {
            glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
        }
    }
    
    for(int i = -10; i <= 10; i += 1) {
        if(i == 0) continue; // skip origin
        
        // draw y-axis tick marks
        glBegin(GL_LINES);
            glVertex2f(-0.2, i);
            glVertex2f(0.2, i);
        glEnd();
        
        // draw y-axis numbers
        if (i % 5 == 0) { // Only label every 5 units for clarity
            char str[10];
            glRasterPos2f(-1.5, i - 0.1);
            sprintf(str, "%d", i);
            for(char* c = str; *c != '\0'; c++) {
                glutBitmapCharacter(GLUT_BITMAP_8_BY_13, *c);
            }
        }
    }

    // draw origin "0"
    glRasterPos2f(-0.5, -0.6);
    glutBitmapCharacter(GLUT_BITMAP_8_BY_13, '0');
}

// function to draw the actual parabola for reference
void drawParabola() {
    glColor3f(0.0, 0.5, 1.0);  // light blue
    glLineWidth(1.0);
    glBegin(GL_LINE_STRIP);
    
    for(float y = -10.0f; y <= 10.0f; y += 0.1f) {
        float x = y * y;  // x = y^2
        glVertex2f(x, y);
    }
    
    glEnd();
}

// function to draw text in the scene
void drawText(const char* text, float x, float y) {
    glRasterPos2f(x, y);
    for(const char* c = text; *c != '\0'; c++) {
        glutBitmapCharacter(GLUT_BITMAP_9_BY_15, *c);
    }
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // draw coordinate system
    drawCoordinateSystem();
    
    // draw the actual continuous parabola for reference
    drawParabola();
    
    // apply the midpoint algorithm to scan convert the parabola
    scanConvertParabola();
    
    // draw the scan-converted points (rasterized parabola)
    glColor3f(1.0, 0.0, 0.0);  // red
    glPointSize(4.0);
    glBegin(GL_POINTS);
    for(int i = 0; i < numPoints; i++) {
        glVertex2f(pointsX[i], pointsY[i]);
    }
    glEnd();
    
    // draw midpoints used in decision making
    glPointSize(3.0);
    for(int i = 0; i < numPoints && i < MAX_POINTS; i++) {
        if (isMidpointBelow[i]) {
            glColor3f(0.0, 1.0, 0.0);  // green for midpoints below curve
        } else {
            glColor3f(1.0, 1.0, 0.0);  // yellow for midpoints above curve
        }
        glBegin(GL_POINTS);
        glVertex2f(midpointX[i], midpointY[i]);
        glEnd();
    }
    
    // Add legend and information
    glColor3f(1.0, 1.0, 1.0);  // white text
    drawText("Parabola: x = y^2  [-10 <= y <= 10]", 10, 9);
    drawText("Red points: scan-converted points", 10, 8);
    
    glColor3f(0.0, 1.0, 0.0);  // green text
    drawText("Green points: midpoints below curve", 10, 7);
    
    glColor3f(1.0, 1.0, 0.0);  // yellow text
    drawText("Yellow points: midpoints above curve", 10, 6);
    
    glColor3f(0.0, 0.5, 1.0);  // light blue text
    drawText("Light blue line: actual parabola", 10, 5);
    
    glColor3f(1.0, 1.0, 1.0);  // white text
    drawText("Midpoint method: For each point, calculate the midpoint of the next potential pixels.", 10, 3);
    drawText("If the midpoint is below the curve, choose the upper-right pixel.", 10, 2);
    drawText("If the midpoint is above the curve, choose the lower-right pixel.", 10, 1);
    drawText("We use symmetry about the x-axis to mirror points for negative y values.", 10, 0);
    
    glFlush();
}

void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0);  // black background
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(-10, 110, -10, 10);  // coordinate system adjusted for parabola
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(900, 600);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("ICS2311 CAT - Parabola Scan Conversion, and Midpoint Method");

    glewInit();
    init();

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}