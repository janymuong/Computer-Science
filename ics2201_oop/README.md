# Object-Oriented Programming (OOP)

> `Java`, ICS 2201
## Content

1. [Introduction](#introduction)
2. [Key Concepts](#key-concepts)
3. [Classes and Objects](#classes-and-objects)
4. [Inheritance](#inheritance)
5. [Polymorphism](#polymorphism)
6. [Encapsulation](#encapsulation)
7. [Abstraction](#abstraction)
8. [Usage](#usage)


## Introduction

This is directory for **Object-Oriented Programming** (OOP) in `Java`! It provides a comprehensive guide to understanding the fundamental principles and concepts of OOP using the Java programming language. 

## Key Concepts
> The Java programs, in here, demostrate usage of the following;

### Class

A class is a blueprint for creating objects. It defines the properties (attributes) and behaviors (methods) that an object of that class will have.

### Object

An object is an instance of a class. It represents a real-world entity and encapsulates the data and behavior defined by its class.

### Inheritance

Inheritance is a mechanism that allows a class (subclass/derived class) to inherit properties and behaviors from another class (superclass/base class). It promotes code reuse and establishes an `"is-a"` relationship between classes.

### Polymorphism

Polymorphism allows objects to be treated as instances of their parent class, enabling a single interface to represent different types. This can be achieved through method overloading and overriding.

### Encapsulation

Encapsulation is the concept of bundling data (attributes) and methods that operate on the data within a single unit (class). It restricts direct access to some of the object's components, promoting data hiding.

### Abstraction

Abstraction involves simplifying complex systems by modeling classes based on the essential properties and behaviors relevant to the problem. It hides the implementation details and focuses on what an object does rather than how it does it.

## Classes and Objects

In Java, classes are defined using the `class` keyword. Objects are created using the `new` keyword. Here's a simple example:

```java
public class Car {
    String make;
    String model;
    int year;

    // constructor
    public Car(String make, String model, int year) {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    public void start() {
        System.out.println("The car is starting.");
    }
}

// create an object of the Car class
Car myCar = new Car("Toyota", "Camry", 2023);
```

## Inheritance

Inheritance is implemented using the `extends` keyword in Java. Here's an example:

```java
public class ElectricCar extends Car {
    int batteryCapacity;

    // constructor;
    public ElectricCar(String make, String model, int year, int batteryCapacity) {
        super(make, model, year);
        this.batteryCapacity = batteryCapacity;
    }

    // additional method;
    public void charge() {
        System.out.println("The electric car is charging.");
    }
}

// createe an object of the ElectricCar class
ElectricCar myElectricCar = new ElectricCar("Tesla", "Model S", 2023, 100);
```

## Polymorphism

Polymorphism is demonstrated through method overriding. In the example below, the `start` method is overridden in the `ElectricCar` class:

```java
// In the ElectricCar class
@Override
public void start() {
    System.out.println("The electric car is starting quietly.");
}
```

## Encapsulation

Encapsulation ensures that the internal details of a class are hidden from the outside world. Access modifiers (`public`, `private`, `protected`) are used to control the visibility of attributes and methods. For example:

```java
public class Car {
    public String make;

    private String model;

    public void setModel(String model) {
        this.model = model;
    }
}
```

## Abstraction

Abstraction is achieved by defining abstract classes and interfaces. An abstract class cannot be instantiated, and it may contain abstract methods (methods without a body) that must be implemented by its subclasses. Interfaces provide a way to achieve multiple inheritances. Here's a brief example:

```java
public abstract class Shape {
    // abstract method
    public abstract double calculateArea();
}

// interface
public interface Drawable {
    void draw();
}
```

## Usage
> WRAPS - putting it together :)

```java
// Animal class (parent class)
public class Animal {
    void eat() {
        System.out.println("This animal eats.");
    }
}

// Dog class (subclass of Animal)
public class Dog extends Animal {
    void bark() {
        System.out.println("The dog barks.");
    }
}

public class Main {
    public static void main(String[] args) {
        Dog myDog = new Dog();
        myDog.eat();  
        myDog.bark();
    }
}
```

---
## Java Swing

> Java Swing is a set of GUI (Graphical User Interface) components for Java. It provides a rich set of features for building desktop applications with a graphical user interface. Swing components are lightweight, platform-independent, and highly customizable.  
> You will find a few Swing programs in here eg [BMI calculator](./Bmi_Calculator.java) and a few others. 

### Swing Components

Some common Swing components include:

- **JFrame:** A top-level container that represents the main window of an application.
- **JPanel:** A container that holds and organizes other components.
- **JButton:** A button that can trigger an action.
- **JTextField:** A text input field.
- **JLabel:** A non-editable text display.
- **JComboBox:** A dropdown list.
- **JCheckBox:** A checkbox for boolean selection.
- **JRadioButton:** A radio button for exclusive selection.

### Event Handling in Swing

Swing applications use event-driven programming. Events, such as button clicks or key presses, trigger actions in response. Event listeners are used to handle these events. Usage:

```java
// create a JButton and adding an ActionListener
JButton myButton = new JButton("Click me");
myButton.addActionListener(new ActionListener() {
    @Override
    public void actionPerformed(ActionEvent e) {
        // code to be executed when the button is clicked
        System.out.println("Button clicked!");
    }
});
```
