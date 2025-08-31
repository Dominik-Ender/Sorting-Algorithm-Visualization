using Events;

namespace Algorithms {

    class RadixSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
            RadixSort(array);

            return eventList;
        }

        private void RadixSort(int[] array) {
            int max = GetMax(array);

            for(int exponent = 1; max / exponent > 0; exponent *= 10) {
                CountingSort(array, exponent);
            }
        }

        private int GetMax(int[] array) {
            int max = array[0];

            for (int i = 1; i < array.Length; i++) {
                if (array[i] > max) {
                    max = array[i];
                }
            }
            return max;
        }

        private void CountingSort(int[] array, int exponent) {
            int[] outputArray = new int[array.Length];
            int[] occurences = new int[10];

            for (int i = 0; i < 10; i++) {
                occurences[i] = 0;
            }

            for (int i = 0; i < array.Length; i++) {
                occurences[(array[i] / exponent) % 10]++;
            }

            for (int i = 1; i < 10; i++) {
                occurences[i] += occurences[i - 1];
            }

            for (int i = array.Length - 1; i >= 0; i--) {
                outputArray[occurences[(array[i] / exponent) % 10] - 1] = array[i];
                occurences[(array[i] / exponent) % 10]--;
            }

            for (int i = 0; i < array.Length; i++) {
                array[i] = outputArray[i];

                CreateEvent(array, i);
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}
