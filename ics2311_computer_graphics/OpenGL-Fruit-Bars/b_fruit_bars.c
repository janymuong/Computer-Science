// ICS2311 Group 7 - fruit preference bar chart starting at point (5,5)
// b_fruit_bars.c - program to display a bar chart of youth fruit preferences in gachororo

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

// global array of fruit data - using the same colors as part A
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

// offset for the chart (starting point at (5,5))
const float xOffset = 5.0;
const float yOffset = 5.0;

// reshape function to handle window resizing
void reshape(int width, int height) {
    windowWidth = width;
    windowHeight = height;
    glViewport(0, 0, width, height);
    glutPostRedisplay(); // trigger redraw when window is resized
}

// function to draw text in the scene
void drawText(const char* text, float x, float y, float r, float g, float b) {
    glColor3f(r, g, b);
    glRasterPos2f(x, y);
    for(const char* c = text; *c != '\0'; c++) {
        glutBitmapCharacter(GLUT_BITMAP_9_BY_15, *c);
    }
}

// display coordinate system to show where (5,5) is located
void drawBaseCoordinateSystem() {
    // draw main world axes
    glColor3f(0.5, 0.5, 0.5);  // gray color for base axes
    glLineWidth(1.0);
    glBegin(GL_LINES);
        glVertex2f(0.0, 0.0); glVertex2f(12.0, 0.0); // x-axis
        glVertex2f(0.0, 0.0); glVertex2f(0.0, 12.0); // y-axis
    glEnd();
    
    // label the axes of the base coordinate system
    drawText("0", -0.3, -0.3, 0.5, 0.5, 0.5);  // Origin
    drawText("X", 12.2, 0.0, 0.5, 0.5, 0.5);   // X-axis
    drawText("Y", 0.0, 12.2, 0.5, 0.5, 0.5);   // Y-axis
    drawText("World Coordinate System", 2.0, 11.5, 0.5, 0.5, 0.5); // title

    // grid lines (lighter)
    glColor3f(0.3, 0.3, 0.3);
    glLineWidth(0.5);
    glBegin(GL_LINES);
    for (int i = 1; i <= 12; i++) {
        // only draw grid lines within our view
        if (i <= 12) {
            glVertex2f(i, 0.0); glVertex2f(i, 12.0); // vertical
            glVertex2f(0.0, i); glVertex2f(12.0, i); // horizontal
        }
    }
    glEnd();
    
    // label key grid points
    for (int i = 1; i <= 12; i += 1) {
        if (i % 2 == 0 || i == 5) { // only label even numbers and 5
            char num[5];
            sprintf(num, "%d", i);
            drawText(num, i - 0.1, -0.3, 0.5, 0.5, 0.5);  // x-axis labels
            drawText(num, -0.3, i - 0.1, 0.5, 0.5, 0.5);  // y-axis labels
        }
    }

    // highlight the starting point (5,5) with a red dot
    glColor3f(1.0, 0.0, 0.0);
    glPointSize(8.0);
    glBegin(GL_POINTS);
        glVertex2f(xOffset, yOffset);
    glEnd();
    
    // label for (5,5) point with arrow
    // drawText("(5,5)", xOffset + 0.2, yOffset + 0.2, 1.0, 0.0, 0.0);
    
    // draw arrow pointing to (5,5)
    glColor3f(1.0, 0.0, 0.0);
    glLineWidth(1.5);
    glBegin(GL_LINES);
        glVertex2f(xOffset + 0.1, yOffset + 0.1);
        glVertex2f(xOffset + 0.2, yOffset + 0.2);
    glEnd();
}

// draw the actual chart axes starting at (5,5)
void drawChartAxes() {
    // draw y-axis (red) - same as part A
    glColor3f(1.0, 0.0, 0.0);
    glLineWidth(2.0);
    glBegin(GL_LINES);
        glVertex2f(xOffset, yOffset);
        glVertex2f(xOffset, yOffset + 5.0);
    glEnd();

    // draw x-axis (black) - same as part A
    glColor3f(0.0, 0.0, 0.0);
    glBegin(GL_LINES);
        glVertex2f(xOffset, yOffset);
        glVertex2f(xOffset + 8.0, yOffset);
    glEnd();
    
    // Label the axes of the chart coordinate system
    drawText("Chart X-Axis", xOffset + 8.2, yOffset, 0.0, 0.0, 0.0);
    drawText("Chart Y-Axis", xOffset - 0.5, yOffset + 5.2, 1.0, 0.0, 0.0);
    
    // Add y-axis ticks and labels (red)
    glColor3f(1.0, 0.0, 0.0);
    for (int i = 0; i <= 50; i += 10) {
        float y = yOffset + ((float)i / 50.0) * 5.0;
        glBegin(GL_LINES);
            glVertex2f(xOffset - 0.1, y);
            glVertex2f(xOffset, y);
        glEnd();
        
        char str[10];
        sprintf(str, "%d", i);
        glRasterPos2f(xOffset - 0.5, y - 0.1);
        for (char* c = str; *c != '\0'; c++)
            glutBitmapCharacter(GLUT_BITMAP_9_BY_15, *c);
    }
}

void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    // draw the base coordinate system to show where (5,5) is
    drawBaseCoordinateSystem();
    
    // draw the chart axes starting at (5,5)
    drawChartAxes();

    // draw title
    drawText("Youth Fruit Preferences in Gachororo (Starting at 5,5)", 2.0, 11.0, 1.0, 1.0, 1.0);
    drawText("Total Participants: 170", 2.0, 10.5, 1.0, 1.0, 1.0);
    
    // draw axes labels
    drawText("Fruit Type", xOffset + 4.0, yOffset - 0.5, 0.0, 0.0, 0.0); // black x-axis
    
    // calculate dimensions for the bars
    float barWidth = 0.8;
    float barSpacing = 0.4;
    float maxBarHeight = 5.0;  // maximum height based on y-axis scale
    float startX = xOffset + 0.5;

    // draw bars - ensure they're all visible within our viewport
    for(int i = 0; i < numFruits; i++) {
        // calculate bar height proportional to the max value (50)
        float barHeight = (float)fruits[i].count / 50.0 * maxBarHeight;
        
        // ensure minimum height for visibility
        if(barHeight < 0.1) barHeight = 0.1;
        
        // draw bar with fruit color
        glColor3fv(fruits[i].color);
        glBegin(GL_QUADS);
            glVertex2f(startX, yOffset);
            glVertex2f(startX + barWidth, yOffset);
            glVertex2f(startX + barWidth, yOffset + barHeight);
            glVertex2f(startX, yOffset + barHeight);
        glEnd();

        // draw outline around bar for better visibility
        glColor3f(0.8, 0.8, 0.8);
        glLineWidth(1.0);
        glBegin(GL_LINE_LOOP);
            glVertex2f(startX, yOffset);
            glVertex2f(startX + barWidth, yOffset);
            glVertex2f(startX + barWidth, yOffset + barHeight);
            glVertex2f(startX, yOffset + barHeight);
        glEnd();

        // draw value at top of bar
        char label[10];
        sprintf(label, "%d", fruits[i].count);
        drawText(label, startX + barWidth/2 - 0.2, yOffset + barHeight + 0.2, 0.0, 0.0, 0.0);

        // draw fruit name below bar (rotated like in part A)
        glPushMatrix();
        glTranslatef(startX + barWidth/2, yOffset - 0.2, 0);
        glRotatef(-45, 0, 0, 1);
        drawText(fruits[i].name, 0, 0, 1.0, 1.0, 1.0);
        glPopMatrix();

        startX += barWidth + barSpacing;
    }

    glFlush();
}

void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0); // black background
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    // extended viewport to ensure all bars are visible
    // (so that transformation does not affect visibility of bars)
    gluOrtho2D(-1, 14, -1, 14); 
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(windowWidth, windowHeight);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("ICS2311 Group 7: Fruit Preference Survey (Starting at 5,5)");
    
    glewInit();
    init();
    glutDisplayFunc(display);
    glutReshapeFunc(reshape);
    glutMainLoop();
    return (0);
}