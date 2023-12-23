public class Inheritance {

    public static class Animal {
        String name;
        int legs;
        String color;

        Animal(String name, int legs, String color) {
            this.name = name;
            this.legs = legs;
            this.color = color;
        }

        // Print attribute;
        public void makeNat() {
            System.out.println(name);
        }
    }

    public static class Cat extends Animal {
        String sound;

        Cat(String sound, String name, int legs, String color) {
            super(name, legs, color);
            this.sound = sound;
        }

        // Print attribute;
        public void catSound() {
            System.out.println(sound);
        }

        // public static void main(String[] args) {
        //     Cat myCat = new Cat("Meow", "Cat3Po", 4, "BlackXYZ");
        //     myCat.catSound();
        // }
    }

    public static void main(String[] args) {
        // Create an instance of Cat
        Cat myCat = new Cat("Meow", "Cat3Po", 4, "BlackXYZ");

        // Access methods from the Cat class
        myCat.catSound();
        myCat.makeNat();
    }
}
