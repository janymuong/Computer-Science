class Basicaniaml {
    interface Monkey {
        public void jump ();
        public void bite ();

    }

    public static class Human implements Monkey {
        public void jump () {
            System.out.println("READY, I am Jumping");
        };
        public void bite () {
            System.out.println("Will Bite You");
        };
    }
    public static void main (String[] args) {
        Human myhuman = new Human();
        myhuman.jump();
        myhuman.bite();
    }
}