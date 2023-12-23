class Telephone {
    abstract static class Smarttelephone {
        public abstract void lift ();
        public abstract void disconnected ();

    }

    public static class Samsung extends Smarttelephone {
        public void lift () {
            System.out.println("Power on");
        };
        public void disconnected () {
            System.out.println("Power OFF");
        };
    }

    public static class iPhone extends Samsung {
        @Override
        public void lift () {
            System.out.println("Iphone On");
        };
        @Override
        public void disconnected () {
            System.out.println("Iphone OFF");
        };
    }
    public static void main (String[] args) {
        Smarttelephone myphone = new iPhone();
        myphone.disconnected();
    }
}