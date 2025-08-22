namespace Events {

    public class Event {

        public int[] array { get; set; }

        public Event(int[] array) {
            this.array = array;
        }

        public int[] getArray() {
            return array;
        }
    }
}