class Abstractdemo {
    abstract static class Sounds {
        public abstract void animalSounds ();
        public abstract void sleepingSound ();

    }

    public static class Animal extends Sounds {
        @Override
        public void animalSounds () {
            System.out.println("Bark");
        };
        @Override
        public void sleepingSound () {
            System.out.println("ZZZZ");
        };
    }
    public static void main (String[] args) {
        Sounds myanimal = new Animal();
        myanimal.animalSounds();
    }
}