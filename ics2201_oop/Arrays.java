
/*
compile java file in commandline: javac Simplecalc.java
run the compiled program: java Simplecalc
*/
public class Arrays {
    public static void main(String[] args) {
        int [] myarray = {20, 30, 40, 50};
        int sumarray = 0;
        for (int i = 0; i < myarray.length; i++ ){
            sumarray += myarray[i];
            // System.out.println(sumarray);
        }
        System.out.println(sumarray);
        }
    }
