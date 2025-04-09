// SCT211-0848/2018 - Jany Muong
// 2-midpoint_ellipse_algorithm.c - ellipse drawing using midpoint algorithm and flood-fill
// drawing an ellipse with center (1,2) given by: ((x-2)^2)/36 + ((y+1)^2)/25 = 1

#include <GL/glew.h>
#include <GL/freeglut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <stdbool.h>
#include <stdlib.h>

#define WIDTH 800
#define HEIGHT 800
#define PI 3.14159265358979323846

unsigned char frameBuffer[HEIGHT][WIDTH][3]; // RGB frame buffer for flood fill

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
        if(i == 0) continue; // Skip the axes
        // Vertical lines
        glVertex2f(i, -10.0);
        glVertex2f(i, 10.0);
        // Horizontal lines
        glVertex2f(-10.0, i);
        glVertex2f(10.0, i);
    }
    glEnd();

    // draw tick marks and numbers
    glColor3f(1.0, 1.0, 1.0);  // White color for numbers
    for(int i = -10; i <= 10; i++) {
        if(i == 0) continue; // Skip origin
        
        // Draw tick marks
        glBegin(GL_LINES);
            // x-axis ticks
            glVertex2f(i, -0.2);
            glVertex2f(i, 0.2);
            // y-axis ticks
            glVertex2f(-0.2, i);
            glVertex2f(0.2, i);
        glEnd();

        // Draw numbers
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

    // Draw origin "0"
    glRasterPos2f(-0.4, -0.6);
    glutBitmapCharacter(GLUT_BITMAP_8_BY_13, '0');
}

// Function to set a pixel in our frame buffer
void setFrameBufferPixel(int x, int y, unsigned char r, unsigned char g, unsigned char b) {
    // Map from OpenGL coordinates to screen coordinates
    int screenX = (x + 10) * (WIDTH / 20.0);
    int screenY = (y + 10) * (HEIGHT / 20.0);
    
    if (screenX >= 0 && screenX < WIDTH && screenY >= 0 && screenY < HEIGHT) {
        frameBuffer[screenY][screenX][0] = r;
        frameBuffer[screenY][screenX][1] = g;
        frameBuffer[screenY][screenX][2] = b;
    }
}

// Function to draw a pixel on the screen
void drawPixel(int x, int y, float r, float g, float b) {
    glColor3f(r, g, b);
    glBegin(GL_POINTS);
    glVertex2i(x, y);
    glEnd();
}

// Implementation of the midpoint ellipse algorithm with 8-way symmetry
void midpointEllipse(int xc, int yc, int rx, int ry) {
    glColor3f(0.0f, 1.0f, 0.0f); // green for the outline
    glPointSize(2.0);            // larger points
    
    float dx, dy, d1, d2, x, y;
    x = 0;
    y = ry;

    // Initial decision parameter for region 1
    d1 = (ry * ry) - (rx * rx * ry) + (0.25 * rx * rx);
    dx = 2 * ry * ry * x;
    dy = 2 * rx * rx * y;
    
    glBegin(GL_POINTS);
    
    // Region 1
    while (dx < dy) {
        // Plot points in all octants
        glVertex2i(xc + x, yc + y);
        glVertex2i(xc - x, yc + y);
        glVertex2i(xc + x, yc - y);
        glVertex2i(xc - x, yc - y);
        
        // Mark pixels in the frame buffer for later flood fill
        setFrameBufferPixel(xc + x, yc + y, 0, 255, 0);
        setFrameBufferPixel(xc - x, yc + y, 0, 255, 0);
        setFrameBufferPixel(xc + x, yc - y, 0, 255, 0);
        setFrameBufferPixel(xc - x, yc - y, 0, 255, 0);
        
        // Update
        if (d1 < 0) {
            x++;
            dx += 2 * ry * ry;
            d1 += dx + (ry * ry);
        } else {
            x++;
            y--;
            dx += 2 * ry * ry;
            dy -= 2 * rx * rx;
            d1 += dx - dy + (ry * ry);
        }
    }

    // Decision parameter for region 2
    d2 = ((ry * ry) * ((x + 0.5) * (x + 0.5))) + ((rx * rx) * ((y - 1) * (y - 1))) - (rx * rx * ry * ry);
    
    // Region 2
    while (y >= 0) {
        // Plot points in all octants
        glVertex2i(xc + x, yc + y);
        glVertex2i(xc - x, yc + y);
        glVertex2i(xc + x, yc - y);
        glVertex2i(xc - x, yc - y);
        
        // Mark pixels in the frame buffer for later flood fill
        setFrameBufferPixel(xc + x, yc + y, 0, 255, 0);
        setFrameBufferPixel(xc - x, yc + y, 0, 255, 0);
        setFrameBufferPixel(xc + x, yc - y, 0, 255, 0);
        setFrameBufferPixel(xc - x, yc - y, 0, 255, 0);
        
        // Update
        if (d2 > 0) {
            y--;
            dy -= 2 * rx * rx;
            d2 += (rx * rx) - dy;
        } else {
            y--;
            x++;
            dx += 2 * ry * ry;
            dy -= 2 * rx * rx;
            d2 += dx - dy + (rx * rx);
        }
    }
    
    glEnd();
}

// draw smooth ellipse using parametric equation
void drawSmoothEllipse(int xc, int yc, int rx, int ry) {
    glColor3f(0.0f, 1.0f, 0.0f); // Green for the outline
    glPointSize(1.5);            // Smaller points for smoother appearance
    
    glBegin(GL_POINTS);
    
    // Use the parametric form of the ellipse equation:
    // x = xc + rx * cos(t)
    // y = yc + ry * sin(t)
    // with t going from 0 to 2π
    
    // The number of segments determines the smoothness
    int segments = 1000;
    for (int i = 0; i < segments; i++) {
        float theta = 2.0f * PI * i / segments;
        float x = xc + rx * cos(theta);
        float y = yc + ry * sin(theta);
        
        glVertex2f(x, y);
        
        // Also mark in frame buffer for fill
        setFrameBufferPixel(x, y, 0, 255, 0);
    }
    
    glEnd();
}

// non-recursive flood fill algorithm using a queue-based approach
void floodFill(int x, int y, unsigned char fillR, unsigned char fillG, unsigned char fillB) {
    // map OpenGL coords to screen coords
    int startX = (x + 10) * (WIDTH / 20.0);
    int startY = (y + 10) * (HEIGHT / 20.0);
    
    // target color (black background)
    unsigned char targetR = 0;
    unsigned char targetG = 0;
    unsigned char targetB = 0;
    
    // check if starting point is already filled or is a boundary
    if (frameBuffer[startY][startX][0] != targetR || 
        frameBuffer[startY][startX][1] != targetG || 
        frameBuffer[startY][startX][2] != targetB) {
        return;
    }
    
    // simple queue implementation for BFS approach
    typedef struct {
        int x, y;
    } Point;
    
    Point* queue = (Point*)malloc(WIDTH * HEIGHT * sizeof(Point));
    int queueStart = 0;
    int queueEnd = 0;
    
    // addd starting point to queue
    queue[queueEnd].x = startX;
    queue[queueEnd].y = startY;
    queueEnd++;
    
    // Process queue until empty
    while (queueStart < queueEnd) {
        Point current = queue[queueStart++];
        
        // Skip if this point is already processed or is a boundary
        if (frameBuffer[current.y][current.x][0] != targetR || 
            frameBuffer[current.y][current.x][1] != targetG || 
            frameBuffer[current.y][current.x][2] != targetB) {
            continue;
        }
        
        // Fill this point
        frameBuffer[current.y][current.x][0] = fillR;
        frameBuffer[current.y][current.x][1] = fillG;
        frameBuffer[current.y][current.x][2] = fillB;
        
        // Add 4-connected neighbors to queue
        int dx[4] = {0, 1, 0, -1};
        int dy[4] = {1, 0, -1, 0};
        
        for (int i = 0; i < 4; i++) {
            int nx = current.x + dx[i];
            int ny = current.y + dy[i];
            
            if (nx >= 0 && nx < WIDTH && ny >= 0 && ny < HEIGHT &&
                frameBuffer[ny][nx][0] == targetR && 
                frameBuffer[ny][nx][1] == targetG && 
                frameBuffer[ny][nx][2] == targetB) {
                
                queue[queueEnd].x = nx;
                queue[queueEnd].y = ny;
                queueEnd++;
            }
        }
    }
    
    free(queue);
    
    // draw the filled area to the screen
    glPointSize(1.0);
    glBegin(GL_POINTS);
    glColor3f(fillR/255.0f, fillG/255.0f, fillB/255.0f);
    
    for (int y = 0; y < HEIGHT; y++) {
        for (int x = 0; x < WIDTH; x++) {
            if (frameBuffer[y][x][0] == fillR && 
                frameBuffer[y][x][1] == fillG && 
                frameBuffer[y][x][2] == fillB) {
                
                // Convert screen coords back to OpenGL coords
                float glX = (x / (float)WIDTH) * 20.0f - 10.0f;
                float glY = (y / (float)HEIGHT) * 20.0f - 10.0f;
                glVertex2f(glX, glY);
            }
        }
    }
    glEnd();
}

// Alternative fill approach using scan-line algorithm
void fillEllipseWithScanline(int xc, int yc, int rx, int ry) {
    glColor3f(1.0f, 0.65f, 0.0f); // Orange
    
    // For each scan line within the ellipse bounding box
    for (int y = yc - ry; y <= yc + ry; y++) {
        // Find intersection points of scan line with ellipse
        // Using the ellipse equation: (x-xc)²/rx² + (y-yc)²/ry² = 1
        // Solving for x: (x-xc)² = rx²(1 - (y-yc)²/ry²)
        float temp = 1.0f - (float)(y - yc) * (y - yc) / (ry * ry);
        
        if (temp >= 0) {
            int xwidth = rx * sqrt(temp);
            
            // Draw horizontal line between intersection points
            glBegin(GL_LINES);
            glVertex2i(xc - xwidth, y);
            glVertex2i(xc + xwidth, y);
            glEnd();
        }
    }
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // Initialize frame buffer to black (background color)
    memset(frameBuffer, 0, WIDTH * HEIGHT * 3);
    
    // Draw coordinate system
    drawCoordinateSystem();

    // Draw the ellipse using the equation ((x-2)^2)/36 + ((y+1)^2)/25 = 1
    // This translates to center (2, -1) with rx=6, ry=5
    int xc = 2, yc = -1;
    int rx = 6, ry = 5;
    
    // Use parametric approach for smoother ellipse
    drawSmoothEllipse(xc, yc, rx, ry);
    
    // Fill the ellipse with orange color using scan-line algorithm
    fillEllipseWithScanline(xc, yc, rx, ry);
    
    // Redraw the ellipse outline to ensure it's visible over the fill
    drawSmoothEllipse(xc, yc, rx, ry);
    
    glFlush();
}

void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0);  // Black background
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(-10, 10, -10, 10);  // Coordinate system - grid 20 by 20
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(WIDTH, HEIGHT);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("ICS2311 CAT Question 2 - Ellipse and Filling");

    glewInit();
    init();

    glutDisplayFunc(display);
    glutMainLoop();
    
    return 0;
}