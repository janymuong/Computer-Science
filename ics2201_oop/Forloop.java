
/*
compile java file in commandline: javac Simplecalc.java
run the compiled program: java Simplecalc
*/
public class Forloop {
    public static void main(String[] args) {
        for (int k=0; k < 10; k++) {
            System.out.println(k);
            if (k >= 5) {
                break;
            }

        }
    }
}
