/*
SCT211-0848/2018
Jany Muong

compile java file in commandline: javac ShapeDemo.java
run the compiled program: java ShapeDemo
*/
class ShapeDemo {
    public static class Shape {
        void draw() {
            System.out.println("Drawing a generic shape");
        }

        double calculateArea() {
            System.out.println("Calculating area of a generic shape");
            return 0.0;
        }
    }

    static class Circle extends Shape {
        private double radius;

        Circle(double radius) {
            this.radius = radius;
        }

        double getRadius() {
            return radius;
        }

        @Override
        void draw() {
            System.out.println("Drawing a circle");
        }

        @Override
        double calculateArea() {
            System.out.println("Calculating area of a circle");
            return Math.PI * radius * radius;
        }
    }

    static class Cylinder extends Circle {
        private double height;

        Cylinder(double radius, double height) {
            super(radius);
            this.height = height;
        }

        @Override
        void draw() {
            System.out.println("Drawing a cylinder");
        }
        // double getRadius() {
        //     return radius;
        // }

        @Override
        double calculateArea() {
            System.out.println("Calculating surface area of a cylinder");
            // Surface area of a cylinder: 2πr^2 + 2πrh
            return 2 * super.calculateArea() + 2 * Math.PI * getRadius() * height;
        }
    }

    public static void main(String[] args) {
        Shape genericShape = new Shape();
        Circle circle = new Circle(5.0);
        Cylinder cylinder = new Cylinder(3.0, 7.0);

        // Demonstrate draw() and calculateArea() for each shape
        System.out.println("Generic Shape:");
        genericShape.draw();
        System.out.println("Area: " + genericShape.calculateArea());
        System.out.println();

        System.out.println("Circle:");
        circle.draw();
        System.out.println("Area: " + circle.calculateArea());
        System.out.println();

        System.out.println("Cylinder:");
        cylinder.draw();
        System.out.println("Surface Area: " + cylinder.calculateArea());
    }
}
