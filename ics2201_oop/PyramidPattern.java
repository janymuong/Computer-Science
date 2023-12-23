public class PyramidPattern {
    public static void main(String[] args) {
        int n = 4; // Number of rows in the pyramid

        int currentNumber = 1;

        for (int i = 1; i <= n; i++) {
            // Print spaces for alignment
            for (int j = 1; j <= n - i; j++) {
                System.out.print("  ");
            }

            // Print numbers in the pyramid pattern
            for (int k = 1; k <= i; k++) {
                System.out.print(currentNumber + " ");
                currentNumber++;
            }

            // Move to the next line after each row
            System.out.println();
        }
    }
}
