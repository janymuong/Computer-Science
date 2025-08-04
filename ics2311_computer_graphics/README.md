# OpenGL Setup - Windows

> ## works on windows 11 and 10  
> NOTE: this should be an easier setup in a shell and doestn require copying of files and modifying paths for `freeglut` and `glew` and/or moving **libraries** around.

opengl is already installeed in your system(windows): run the file provided by dr karanja mwangi: glinfo2.exe should show you opengl version 4.6 and then driver of your graphics card

I have listed out the steps below - steps to go about the setup:
1. read about mingw64 - https://www.mingw-w64.org/

2. download mingw64/msys2 and pacman - from https://www.msys2.org/ ie this file msys2-x86_64-20250221.exe

3. ### install freeglut and glew  
```sh
    pacman -S mingw-w64-x86_64-freeglut
    pacman -S mingw-w64-x86_64-glew
```
4. ### text editor or IDE: 
    if you dislike IDEs eg options of codeblocks, eclipse CDT, visual studio etc; you can use default nano etxt editor or vscode inside msys/the terminal of it:
    
    ```sh
    export PATH=$PATH:/c/Users/YourUsername/AppData/Local/Programs/Microsoft\ VS\ Code/bin
    # you can add the line above to `bashrc` afterwards if this works
    ```

    so you can open programs this way: 
    ```sh
    code filename.extension
    ``` 


4. TEST SETUP
you can use this file to ascertain the setup works:

```sh
code hello_line.c
```

```c
#include <GL/glut.h> 
void display() {
    glClear(GL_COLOR_BUFFER_BIT);
    
    glColor3f(1.0, 1.0, 1.0); // line color (white)
    glBegin(GL_LINES);
        glVertex2f(-0.5, 0.0);
        glVertex2f(0.5, 0.0);
    glEnd();
    
    glFlush(); // render the line
}

void init() {
    glClearColor(0.0, 0.0, 0.0, 1.0);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(-1, 1, -1, 1);
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(500, 500);
    glutCreateWindow("OpenGL Line");

    init(); 
    glutDisplayFunc(display);
    glutMainLoop(); 

    return 0;
}
```


compile and run executable:
```sh 
gcc hello_line.c -o hello_line -lfreeglut -lglew32 -lglu32 -lopengl32 -lgdi32

./hello_line.exe
```
you get a display window that has a white horizontal line.

gcc can be installed in msys2 using 

```sh
pacman -S mingw-w64-x86_64-gcc
gcc --version
```

 

disclaimer: 
you might run into errors having to do w/ your machine. plus I dont know how good this setup will be going forward keeping in mind I dont know what is ahead for the unit/workload or whether there is a better/ more efficient way - eg using the IDEs that we have just avoided with this setup.