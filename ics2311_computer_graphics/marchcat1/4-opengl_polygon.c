// SCT211-0848/2018 - Jany Muong
// 4-opengl_polygon.c - OpenGL program to draw a filled polygon, scale it, and fill with asterisks

#include <GL/glew.h>
#include <GL/freeglut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <stdlib.h>
#include <time.h>


// intitial/original polygon coordinates
float originalPolygon[6][2] = {
    {8.0, 4.0},
    {2.0, 4.0},
    {0.0, 8.0},
    {3.0, 12.0},
    {7.0, 12.0},
    {10.0, 8.0}
};

// scaled polygon coordinates matrix
float scaledPolygon[6][2];

// prototypes
void drawCoordinateSystem();
void drawText(const char* text, float x, float y);
void drawPolygonOutline(float vertices[][2], int numVertices, float r, float g, float b);
void drawFilledPolygon(float vertices[][2], int numVertices, float r, float g, float b, float alpha);
void drawPoint(float x, float y, float size, float r, float g, float b);
void scalePolygon(float sx, float sy);
void fillPolygonWithAsterisks(float vertices[][2], int numVertices);
int isPointInPolygon(float vertices[][2], int numVertices, float x, float y);


void drawCoordinateSystem() {
    // draw main axes
    glColor3f(0.5, 0.5, 0.5);  // gray color for axes
    glLineWidth(2.0);
    glBegin(GL_LINES);
        // x-axis
        glVertex2f(-2.0, 0.0);
        glVertex2f(20.0, 0.0);
        // y-axis
        glVertex2f(0.0, -2.0);
        glVertex2f(0.0, 20.0);
    glEnd();

    // draw grid lines
    glLineWidth(1.0);
    glColor3f(0.2, 0.2, 0.2);  // grid color
    glBegin(GL_LINES);
    for(int i = -2; i <= 20; i += 2) {
        if(i == 0) continue; // skip the axes
        // vertical lines
        glVertex2f(i, -2.0);
        glVertex2f(i, 20.0);
        // horizontal lines
        glVertex2f(-2.0, i);
        glVertex2f(20.0, i);
    }
    glEnd();

    // draw tick marks and numbers
    glColor3f(1.0, 1.0, 1.0);  // white color for numbers
    for(int i = -2; i <= 20; i += 2) {
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
        glRasterPos2f(i - 0.3, -0.6);
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

// function to draw a filled polygon with transparency (i)
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

// scale polygon by sx in x direction and sy in y direction (ii)
void scalePolygon(float sx, float sy) {
    for(int i = 0; i < 6; i++) {
        scaledPolygon[i][0] = originalPolygon[i][0] * sx;
        scaledPolygon[i][1] = originalPolygon[i][1] * sy;
    }
}

// check if a point is inside a polygon - used for asterisk filling
int isPointInPolygon(float vertices[][2], int numVertices, float x, float y) {
    int i, j, c = 0;
    for (i = 0, j = numVertices-1; i < numVertices; j = i++) {
        if (((vertices[i][1] > y) != (vertices[j][1] > y)) &&
            (x < (vertices[j][0] - vertices[i][0]) * (y - vertices[i][1]) / 
             (vertices[j][1] - vertices[i][1]) + vertices[i][0]))
            c = !c;
    }
    return c;
}

// function to draw an asterisk at a given position
void drawAsterisk(float x, float y, float size, float g) {
    float halfSize = size / 2.0;
    
    glColor3f(0.0, g, 0.0);  // shade of green
    glLineWidth(1.0);
    
    glBegin(GL_LINES);
        // horizontal line
        glVertex2f(x - halfSize, y);
        glVertex2f(x + halfSize, y);
        
        // vertical line
        glVertex2f(x, y - halfSize);
        glVertex2f(x, y + halfSize);
        
        // diagonal lines
        glVertex2f(x - halfSize * 0.7, y - halfSize * 0.7);
        glVertex2f(x + halfSize * 0.7, y + halfSize * 0.7);
        
        glVertex2f(x - halfSize * 0.7, y + halfSize * 0.7);
        glVertex2f(x + halfSize * 0.7, y - halfSize * 0.7);
    glEnd();
}

// fill polygon with green asterisks (iii)
void fillPolygonWithAsterisks(float vertices[][2], int numVertices) {
    // find the bounds/box of the polygon
    float minX = vertices[0][0], maxX = vertices[0][0];
    float minY = vertices[0][1], maxY = vertices[0][1];
    
    for(int i = 1; i < numVertices; i++) {
        if(vertices[i][0] < minX) minX = vertices[i][0];
        if(vertices[i][0] > maxX) maxX = vertices[i][0];
        if(vertices[i][1] < minY) minY = vertices[i][1];
        if(vertices[i][1] > maxY) maxY = vertices[i][1];
    }
    
    // step size for the grid of points
    float stepX = 0.5;
    float stepY = 0.5;
    
    // place asterisks inside the polygon
    srand(time(NULL));  // random seed
    
    for(float x = minX; x <= maxX; x += stepX) {
        for(float y = minY; y <= maxY; y += stepY) {
            if(isPointInPolygon(vertices, numVertices, x, y)) {
                // use a random shade of green
                float greenShade = 0.3 + (rand() % 70) / 100.0;  // range [0.3, 1.0]
                drawAsterisk(x, y, 0.3, greenShade);
            }
        }
    }
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // draw coordinate system
    drawCoordinateSystem();

    // apply scaling
    scalePolygon(2.0, 2.0);  // scale by a factor of 2

    // part (i) draw original polygon filled with red
    drawFilledPolygon(originalPolygon, 6, 1.0, 0.0, 0.0, 0.7);  // Red with transparency
    drawPolygonOutline(originalPolygon, 6, 1.0, 0.5, 0.5);      // Light red outline
    
    // part (iii) fill the original polygon with green asterisks(given polygon)
    fillPolygonWithAsterisks(originalPolygon, 6);
    
    // part (ii) draw scaled polygon
    drawPolygonOutline(scaledPolygon, 6, 0.0, 0.0, 1.0);  // Blue outline for scaled polygon
    
    // label the vertices of the original polygon
    glColor3f(1.0, 1.0, 1.0);  // white text
    char label[20];
    for(int i = 0; i < 6; i++) {
        drawPoint(originalPolygon[i][0], originalPolygon[i][1], 6.0, 1.0, 1.0, 0.0);  // yellow points
        sprintf(label, "(%.1f, %.1f)", originalPolygon[i][0], originalPolygon[i][1]);
        drawText(label, originalPolygon[i][0] + 0.3, originalPolygon[i][1] + 0.3);
    }
    
    // label the vertices of the scaled polygon
    for(int i = 0; i < 6; i++) {
        drawPoint(scaledPolygon[i][0], scaledPolygon[i][1], 6.0, 0.0, 0.7, 1.0);  // light blue points
        sprintf(label, "(%.1f, %.1f)", scaledPolygon[i][0], scaledPolygon[i][1]);
        drawText(label, scaledPolygon[i][0] + 0.3, scaledPolygon[i][1] + 0.3);
    }

    // legend/key
    glColor3f(1.0, 0.0, 0.0);
    drawText("Original Polygon (Red)", 12.0, 18.0);
    
    glColor3f(0.0, 0.5, 0.0);
    drawText("Green Asterisks Filling", 12.0, 17.0);
    
    glColor3f(0.0, 0.0, 1.0);
    drawText("Scaled Polygon (x2)", 12.0, 16.0);

    glFlush();
}

void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0);  // black background
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(-2, 20, -2, 20);  // coordinate system
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(800, 800);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("ICS2311 CAT - Polygon, Scaling and Interior Filling :) ");

    glewInit();
    init();

    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}
