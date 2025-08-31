using Events;

namespace Algorithms {

    class PigeonholeSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            int[] array = GenerateRandomArray.GetRandomArray();

            CreateEvent(array, 0);
            PigeonholeSort(array);

            return eventList;
        }

        private void PigeonholeSort(int[] array) {
            int min = array[0];
            int max = array[0];
            int range, i, j, index;

            for (int a = 0; a < array.Length; a++) {
                if (array[a] > max) {
                    max = array[a];
                }

                if (array[a] < min) {
                    min = array[a];
                }
            }

            range = max - min + 1;
            int[] pigeonhole = new int[range];

            for (i = 0; i < array.Length; i++) {
                pigeonhole[i] = 0;
            }

            for (i = 0; i < array.Length; i++) {
                pigeonhole[array[i] - min]++;
            }

            index = 0;

            for (j = 0; j < range; j++) {
                while (pigeonhole[j]-- > 0) {
                    array[index++] = j + min;

                    CreateEvent(array, index);
                }
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}
