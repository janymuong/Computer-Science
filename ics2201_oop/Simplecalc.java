/*
compile java file in commandline: javac Simplecalc.java
run the compiled program: java Simplecalc
*/
public class Simplecalc {
    public static void main(String[] args) {
        double num1 = 5.5;
        double num2 = 3.0;

        // sum && product
        double sum = num1 + num2;
        double product = num1 * num2;

        // print to stdout;
        System.out.println("Sum: " + sum);
        System.out.println("Product: " + product);
    }
}
