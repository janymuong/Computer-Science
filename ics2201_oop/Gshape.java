/*
SCT211-0848/2018
Jany Muong

compile java file in commandline: javac Gshape.java
run the compiled program: java Gshape
*/
public class Gshape {
    abstract static class Shape {
        private String color;

        public Shape(String color) {
            this.color = color;
        }

        public String getColor() {
            return color;
        }

        public abstract void draw();
        public abstract double calculateArea();
    }

    public static class Circle extends Shape {
        private double radius;

        public Circle(String color, double radius) {
            super(color);
            this.radius = radius;
        }

        @Override
        public void draw() {
            System.out.println("Drawing a " + getColor() + " circle with radius " + radius);
        }

        @Override
        public double calculateArea() {
            return Math.PI * radius * radius;
        }
    }

    public static class Cylinder extends Shape {
        private double height;
        private double radius;

        public Cylinder(String color, double radius, double height) {
            super(color);
            this.radius = radius;
            this.height = height;
        }

        @Override
        public void draw() {
            System.out.println("Drawing a " + getColor() + " cylinder with radius " + radius + ", and height " + height);
        }

        @Override
        public double calculateArea() {
            double baseArea = Math.PI * radius * radius;
            double lateralArea = 2 * Math.PI * radius * height;
            return baseArea + 2 * lateralArea;
        }
    }


    public static void main(String[] args) {
        Shape circle = new Circle("purple", 7.0);
        circle.draw();
        System.out.println("Area of Circle: " + circle.calculateArea());

        Shape cylinder = new Cylinder("maroon", 3.5, 4.0);
        cylinder.draw();
        System.out.println("Area of Cylinder: " + cylinder.calculateArea());
    }
}
