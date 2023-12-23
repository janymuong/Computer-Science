class Hello {
    interface Sounds {
        public void animalSounds ();
        public void sleepingSound ();

    }

    public static class Animal implements Sounds {
        public void animalSounds () {
            System.out.println("Bark");
        };
        public void sleepingSound () {
            System.out.println("ZZZZ");
        };
    }
    public static void main (String[] args) {
        Animal myanimal = new Animal();
        myanimal.animalSounds();
        myanimal.sleepingSound();
    }
}