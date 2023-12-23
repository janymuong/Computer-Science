/*
SCT211-0848/2018
Jany Muong

compile java file in commandline: javac Animal.java
run the compiled program: java Animal
*/
public class Xcode {

    public static class Area {
        int width;
        int length;

        Area(int width, int length) {
            this.width = width;
            this.length = length;
        }

        // Calculate area;
        public int calcArea() {
            return width * length;
        }
    }

    public static class Rectangle extends Area {
        Rectangle(int width, int length) {
            super(width, length);
        }
    }

    public static class Square extends Area {
        int side;

        Square(int side) {
            super(side, side);
            this.side = side;
        }

        // Get area attribute;
        @Override
        public int calcArea() {
            return side * side;
        }

        public static void main(String[] args) {
            Square mySquare = new Square(7);
            Rectangle myRect = new Rectangle(4, 7);

            int squareArea = mySquare.calcArea();
            int rectArea = myRect.calcArea();

            System.out.println("Area of the Square: " + squareArea);
            System.out.println("Area of the Rectangle: " + rectArea);
        }
    }
}
