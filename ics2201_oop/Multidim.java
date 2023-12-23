/*
SCT211-0848/2018
Jany Muong

Assignment 3;
compile java file in commandline: javac Multidim.java
run the compiled program: java Multidim
*/

public class Multidim {
    public static void main(String[] args) {
        /* initialize a base mutltidimensional array
            2D in this case;
        */
        int[][] multidim = {{47, 73, 70}, {40, 50, 60}, {20, 80, 100}};

        int sum = 0;

        // iterate through the inner and outer arrays;
        for (int i = 0; i < multidim.length; i++) {
            for (int j = 0; j < multidim[i].length; j++) {
                // add the current element(element sub[i][j]) to the sum 
                sum += multidim[i][j];
            }
        }

        // print to stdout;
        System.out.println("Multidim -2D Array:");
        for (int i = 0; i < multidim.length; i++) {
            for (int j = 0; j < multidim[i].length; j++) {
                // printout = multidim[i][j] + " ")
                System.out.print(multidim[i][j] + " ");
            }
            System.out.println();
        }

        System.out.println("Sum 2D Array Elements: " + sum);
    }
}
