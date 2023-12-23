/*
SCT211-0848/2018
Jany Muong

compile java file in commandline: javac Furniture.java
run the compiled program: java Furniture
*/

public class Furniture {
    String name;
    int legs;
    String color;

    Furniture(String name, int legs, String color){
        this.name = name;
        this.legs = legs;
        this.color = color;
    }
    public static void main(String[] args) {
        Furniture chair = new Furniture("chair", 4, "Blue");
        // chair.name = "Chair";
        Furniture stool = new Furniture("Stool", 3, "Maroon");
        Furniture bed = new Furniture("Master Bed", 8, "Maroon");
        
        
        System.out.println("Original Name: " + chair.getName());
        // System.out.println("Should be same as above: " + chair.getName());

        // use the setter to change the name of the chair - proof the setter works
        chair.setName("ChairXYZ");
        System.out.println("Updated Chair Name: " + chair.getName());
        System.out.println(bed.getColor());
        System.out.println(stool.getName());
        System.out.println("Stool LEGS x4: " + stool.product());
        System.out.println("Chair LEGS x4: " + chair.product());

    }

    // getter name;
    public String getName() {
        return name;
    }
    public String getColor() {
        return color;
    }
    // product for legs;
    public int product() {
        return (legs * 4);
    }

    // setter for name attribute;
    public void setName(String newName) {
        this.name = newName;
    }

}
