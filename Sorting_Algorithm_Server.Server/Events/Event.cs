namespace Events {

    public class Event {

        public int[] array { get; set; }
        public int index { get; set; }

        public Event(int[] array, int index) {
            this.array = array;
            this.index = index;
        }

        public int[] getArray() {
            return array;
        }
    }
}