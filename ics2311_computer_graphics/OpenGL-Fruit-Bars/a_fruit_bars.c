// ICS2311 Group 7 - fruit preference bar chart
// a_fruit_bars.c - program to display a bar chart of youth fruit preferences in gachororo

// MEMBERS:
/*
* SCT211-0848/2018 - Jany Muong 
* SCT211-0079/2022 - Joram Kireki
* SCT211-0003/2022 - Josphat Waweru Thumi 
* SCT211-0535/2022 - Akech Atem 
*/

#include <GL/glew.h>
#include <GL/freeglut.h>
#include <stdio.h>
#include <math.h>
#include <string.h>

// structure to hold fruit data
typedef struct {
    char name[20];
    int count;
    float color[3]; // RGB values
} FruitData;

// global array of fruit data
FruitData fruits[] = {
    {"Avocado", 36, {0.34, 0.51, 0.01}}, // dark green
    {"Orange", 41, {1.00, 0.65, 0.00}}, // orange color
    {"Banana", 19, {0.89, 0.81, 0.34}}, // yellow
    {"Kiwifruit", 28, {0.62, 0.89, 0.31}}, // kiwi green
    {"Mangos", 30, {1.00, 0.78, 0.25}}, // mango orange
    {"Grapes", 16, {0.50, 0.19, 0.58}} // purple
};
const int numFruits = 6;
int windowWidth = 800, windowHeight = 600;

// reshape function to handle window resizing
void reshape(int width, int height) {
    windowWidth = width;
    windowHeight = height;
    glViewport(0, 0, width, height);
    glutPostRedisplay(); // trigger redraw when window is resized
}

// world coordinate reference system to use
void drawCoordinateSystem() {
    // draw y-axis (red)
    glColor3f(1.0, 0.0, 0.0);
    glLineWidth(2.0);
    glBegin(GL_LINES);
        glVertex2f(50.0, 50.0);
        glVertex2f(50.0, windowHeight - 50.0);
    glEnd();

    // draw x-axis (black)
    glColor3f(0.0, 0.0, 0.0);
    glBegin(GL_LINES);
        glVertex2f(50.0, 50.0);
        glVertex2f(windowWidth - 50.0, 50.0);
    glEnd();
}

// function to draw text in the scene
void drawText(const char* text, float x, float y, float r, float g, float b) {
    glColor3f(r, g, b);
    glRasterPos2f(x, y);
    for(const char* c = text; *c != '\0'; c++) {
        glutBitmapCharacter(GLUT_BITMAP_9_BY_15, *c);
    }
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // set up projection
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(0, windowWidth, 0, windowHeight);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();

    // draw coordinate system (just the axes)
    drawCoordinateSystem();

    // draw title
    drawText("Youth Fruit Preferences in Gachororo", windowWidth/2 - 180, windowHeight - 30, 0.0, 0.0, 0.0);
    drawText("Total Participants: 170", windowWidth/2 - 100, windowHeight - 60, 0.0, 0.0, 0.0);
    
    // draw axes labels
    drawText("Fruit Type", windowWidth/2 - 40, 20, 0.0, 0.0, 0.0); // black x-axis
    // drawText("Number of People", 10, windowHeight/2 - 80, 1.0, 0.0, 0.0); // red y-axis

    // calculate dimensions
    float barWidth = (windowWidth - 150) / numFruits * 0.7;
    float barSpacing = (windowWidth - 150) / numFruits * 0.3;
    float maxBarHeight = windowHeight - 150;
    float startX = 100.0;

    // draw bars
    for(int i = 0; i < numFruits; i++) {
        float barHeight = (float)fruits[i].count / 50 * maxBarHeight;
        
        // draw bar with fruit color
        glColor3fv(fruits[i].color);
        glBegin(GL_QUADS);
            glVertex2f(startX, 50.0);
            glVertex2f(startX + barWidth, 50.0);
            glVertex2f(startX + barWidth, 50.0 + barHeight);
            glVertex2f(startX, 50.0 + barHeight);
        glEnd();

        // draw value
        char label[10];
        sprintf(label, "%d", fruits[i].count);
        drawText(label, startX + barWidth/2 - 10, 60 + barHeight, 0.0, 0.0, 0.0);

        // draw fruit name
        glPushMatrix();
        glTranslatef(startX + barWidth/2, 30, 0);
        glRotatef(45, 0, 0, 1);
        drawText(fruits[i].name, 0, 0, 0.0, 0.0, 0.0);
        glPopMatrix();

        startX += barWidth + barSpacing;
    }

    // draw the fruit name below the bar in BLACK
    for(int i = 0; i <= 50; i += 10) {
        float y = 50 + (float)i / 50 * maxBarHeight;
        glColor3f(1.0, 0.0, 0.0);
        glBegin(GL_LINES);
            glVertex2f(45, y);
            glVertex2f(50, y);
        glEnd();
        char str[10];
        sprintf(str, "%d", i);
        drawText(str, 30, y - 5, 1.0, 0.0, 0.0);
    }

    glFlush();
}

void init() {
    glClearColor(1.0, 1.0, 1.0, 1.0);
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("ICS2311 Group 7: Fruit Preference Survey");
    
    glutReshapeFunc(reshape); // for proper scaling to all windo sizes
    init();
    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}