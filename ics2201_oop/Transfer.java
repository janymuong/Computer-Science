/*
SCT211-0848/2018
Jany Muong

Assignment 1 and 2;
compile java file in commandline: javac Transfer.java
run the compiled program: java Transfer
*/

public class Transfer {
    public static void main(String[] args) {
        int[] myArray1 = {30, 70, 20, 60, 60, 15};
        int[] singleElementArray = {120};
        int[] combinedArray = new int[myArray1.length + 1];

        // copy elements from myArray1 to combinedArray
        // w/o arraycopy()
        for (int i = 0; i < myArray1.length; i++) {
            combinedArray[i] = myArray1[i];
        }

        combinedArray[myArray1.length] = singleElementArray[0];

        // find the max; calculate the sum of array elements;
        int maxElement = combinedArray[0];
        int sum = 0;

        for (int i = 0; i < combinedArray.length; i++) {
            int element = combinedArray[i];
            if (element > maxElement) {
                maxElement = element;
            }
            sum += element;
        }

        // for - each Loop/enhanced for loop;
        // for (int element : combinedArray) {
        //     if (element > maxElement) {
        //         maxElement = element;
        //     }
        //     sum += element;
        // }

        // print the combinedArray, maxElement, and sum to stdout;
        System.out.print("Combined Array: [");
        for (int i = 0; i < combinedArray.length; i++) {
            System.out.print(combinedArray[i]);
            if (i < combinedArray.length - 1) {
                System.out.print(", ");
            }
        }
        System.out.println("]");

        System.out.println("Maximum Element: " + maxElement);
        System.out.println("Sum of ARRAY Elements: " + sum);
    }
}



// ALT solution Using array.arrayscopy();

// public class Multidim {
//     public static void main(String[] args) {
//         int[] myarray = {30, 70, 40, 60, 60, 15};
//         int[] singleElementArray = {120};

//         // Append the single-element array to myarray
//         int[] combinedArray = new int[myarray.length + singleElementArray.length];
//         System.arraycopy(myarray, 0, combinedArray, 0, myarray.length);
//         System.arraycopy(singleElementArray, 0, combinedArray, myarray.length, singleElementArray.length);

//         // Find the maximum number in the combined array and calculate the sum of the elements
//         int maxNumber = combinedArray[0];
//         int sum = 0;

//         for (int i = 0; i < combinedArray.length; i++) {
//             if (combinedArray[i] > maxNumber) {
//                 maxNumber = combinedArray[i];
//             }
//             sum += combinedArray[i];
//         }

//         System.out.println("Combined Array: " + Arrays.toString(combinedArray));
//         System.out.println("Max Number: " + maxNumber);
//         System.out.println("Sum of Elements: " + sum);

//         // Create a new multidimensional array and find the sum of its elements
//         int[][] multidim = {
//             {10, 20, 30},
//             {40, 50, 60},
//             {70, 80, 90}
//         };

//         int multidimSum = 0;

//         for (int i = 0; i < multidim.length; i++) {
//             for (int j = 0; j < multidim[i].length; j++) {
//                 multidimSum += multidim[i][j];
//             }
//         }

//         System.out.println("Multidimensional Array: " + Arrays.deepToString(multidim));
//         System.out.println("Sum of Multidimensional Array Elements: " + multidimSum);
//     }
// }
