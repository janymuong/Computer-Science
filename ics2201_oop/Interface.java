
class Interface {
    // Define an interface
    interface Shape {
        double calculateArea(); // Abstract method
    }
    
    // Implement the interface in a class
    static class Circle implements Shape {
        private double radius;
    
        // Constructor
        public Circle(double radius) {
            this.radius = radius;
        }
    
        // Implement the abstract method from the interface
        @Override
        public double calculateArea() {
            return Math.PI * radius * radius;
        }
    }
    
    static class Rectangle implements Shape {
        private double length;
        private double width;
    
        // Constructor
        public Rectangle(double length, double width) {
            this.length = length;
            this.width = width;
        }
    
        // Implement the abstract method from the interface
        @Override
        public double calculateArea() {
            return length * width;
        }
    }
    public static void main(String[] args) {
        // Create objects of classes that implement the Shape interface
        Circle circle = new Circle(5.0);
        Rectangle rectangle = new Rectangle(4.0, 6.0);

        // Use the objects and call the calculateArea method
        System.out.println("Circle Area: " + circle.calculateArea());
        System.out.println("Rectangle Area: " + rectangle.calculateArea());
    }
}
