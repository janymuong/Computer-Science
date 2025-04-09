// SCT211-0848/2018 - Jany Muong
// 3-translation_rotation_square.c - OpenGL program to draw a square, translate it, and rotate it

#include <GL/glew.h>
#include <GL/freeglut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>

// original square coordinates
float originalSquare[4][2] = {
    {0.0, 0.0},  // D
    {4.0, 0.0},  // C
    {3.0, 4.0},  // B
    {0.0, 4.0}   // A
};

// translated square coordinates
float translatedSquare[4][2];

// rotated square coordinates
float rotatedSquare[4][2];

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

// function to draw text in the scene
void drawText(const char* text, float x, float y) {
    glRasterPos2f(x, y);
    for(const char* c = text; *c != '\0'; c++) {
        glutBitmapCharacter(GLUT_BITMAP_9_BY_15, *c);
    }
}

// function to draw a polygon outline
void drawPolygonOutline(float vertices[][2], int numVertices, float r, float g, float b) {
    glColor3f(r, g, b);
    glLineWidth(2.0);
    glBegin(GL_LINE_LOOP);
    for(int i = 0; i < numVertices; i++) {
        glVertex2f(vertices[i][0], vertices[i][1]);
    }
    glEnd();
}

// function to draw a filled polygon with transparency
void drawFilledPolygon(float vertices[][2], int numVertices, float r, float g, float b, float alpha) {
    glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
    
    glColor4f(r, g, b, alpha);
    glBegin(GL_POLYGON);
    for(int i = 0; i < numVertices; i++) {
        glVertex2f(vertices[i][0], vertices[i][1]);
    }
    glEnd();
    
    glDisable(GL_BLEND);
}

// draw a point at a specific location
void drawPoint(float x, float y, float size, float r, float g, float b) {
    glPointSize(size);
    glColor3f(r, g, b);
    glBegin(GL_POINTS);
        glVertex2f(x, y);
    glEnd();
}

// translate coordinates by tx in x direction and ty in y direction
void translateCoordinates() {
    float tx = 2.0; // translate 2 units in x direction
    float ty = 2.0; // translate 2 units in y direction
    
    for(int i = 0; i < 4; i++) {
        translatedSquare[i][0] = originalSquare[i][0] + tx;
        translatedSquare[i][1] = originalSquare[i][1] + ty;
    }
}

// rotate coordinates around origin by angle (in degrees)
void rotateCoordinates(float angle) {
    float theta = angle * M_PI / 180.0; // convert degrees to radians
    float cosTheta = cos(theta);
    float sinTheta = sin(theta);
    
    for(int i = 0; i < 4; i++) {
        float x = translatedSquare[i][0];
        float y = translatedSquare[i][1];
        
        rotatedSquare[i][0] = x * cosTheta - y * sinTheta;
        rotatedSquare[i][1] = x * sinTheta + y * cosTheta;
    }
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // draw coordinate system
    drawCoordinateSystem();

    // apply transformations
    translateCoordinates();
    rotateCoordinates(55.0); // rotate by 55 degrees

    // draw original square
    drawFilledPolygon(originalSquare, 4, 0.0, 0.0, 1.0, 0.3); // blue with transparency
    drawPolygonOutline(originalSquare, 4, 0.0, 0.5, 1.0); // blue outline
    
    // draw translated square
    drawFilledPolygon(translatedSquare, 4, 0.0, 1.0, 0.0, 0.3); // green with transparency
    drawPolygonOutline(translatedSquare, 4, 0.0, 1.0, 0.5); // green outline
    
    // draw rotated square
    drawFilledPolygon(rotatedSquare, 4, 1.0, 0.0, 0.0, 0.3); // red with transparency
    drawPolygonOutline(rotatedSquare, 4, 1.0, 0.5, 0.5); // red outline

    // draw and label the vertices of the original square
    glColor3f(1.0, 1.0, 1.0);  // white text
    for(int i = 0; i < 4; i++) {
        drawPoint(originalSquare[i][0], originalSquare[i][1], 6.0, 1.0, 1.0, 0.0);  // yellow points
    }
    
    // label original vertices
    char label[20];
    sprintf(label, "A(%.1f, %.1f)", originalSquare[3][0], originalSquare[3][1]);
    drawText(label, originalSquare[3][0] - 0.5, originalSquare[3][1] + 0.5);
    
    sprintf(label, "B(%.1f, %.1f)", originalSquare[2][0], originalSquare[2][1]);
    drawText(label, originalSquare[2][0] + 0.5, originalSquare[2][1] + 0.5);
    
    sprintf(label, "C(%.1f, %.1f)", originalSquare[1][0], originalSquare[1][1]);
    drawText(label, originalSquare[1][0] + 0.5, originalSquare[1][1] - 0.5);
    
    sprintf(label, "D(%.1f, %.1f)", originalSquare[0][0], originalSquare[0][1]);
    drawText(label, originalSquare[0][0] - 0.5, originalSquare[0][1] - 0.5);

    // label translated vertices
    for(int i = 0; i < 4; i++) {
        drawPoint(translatedSquare[i][0], translatedSquare[i][1], 6.0, 0.0, 1.0, 0.0);  // green points
    }
    
    // label translated vertices
    char points[4] = {'D', 'C', 'B', 'A'};
    for(int i = 0; i < 4; i++) {
        sprintf(label, "%c'(%.1f, %.1f)", points[i], translatedSquare[i][0], translatedSquare[i][1]);
        float offsetX = (i == 1 || i == 2) ? 0.5 : -2.0;
        float offsetY = (i == 2 || i == 3) ? 0.5 : -0.5;
        drawText(label, translatedSquare[i][0] + offsetX, translatedSquare[i][1] + offsetY);
    }

    // label rotated vertices
    for(int i = 0; i < 4; i++) {
        drawPoint(rotatedSquare[i][0], rotatedSquare[i][1], 6.0, 1.0, 0.0, 0.0);  // red points
    }
    
    // label rotated vertices
    for(int i = 0; i < 4; i++) {
        sprintf(label, "%c''(%.1f, %.1f)", points[i], rotatedSquare[i][0], rotatedSquare[i][1]);
        float offsetX = (rotatedSquare[i][0] > 0) ? 0.5 : -2.5;
        float offsetY = (rotatedSquare[i][1] > 0) ? 0.5 : -0.5;
        drawText(label, rotatedSquare[i][0] + offsetX, rotatedSquare[i][1] + offsetY);
    }

    // legend/key
    glColor3f(0.0, 0.0, 1.0);
    drawText("Original Square", -9.5, 9.0);
    
    glColor3f(0.0, 1.0, 0.0);
    drawText("Translated Square (+2,+2)", -9.5, 8.0);
    
    glColor3f(1.0, 0.0, 0.0);
    drawText("Rotated Square (55 degrees)", -9.5, 7.0);

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
    glutCreateWindow("ICS2311 CAT Question 3 - Square Translation and Rotation");

    glewInit();
    init();

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}