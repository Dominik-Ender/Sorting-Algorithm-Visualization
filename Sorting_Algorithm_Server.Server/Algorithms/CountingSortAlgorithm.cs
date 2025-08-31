using Events;

namespace Algorithms {

    class CountingSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            int[] array = GenerateRandomArray.GetRandomArray();

            CreateEvent(array, 0);
            CountingSort(array);

            return eventList;
        }

        private void CountingSort(int[] array) {
            var size = array.Length;
            var maxElement = GetMax(array, size);
            var occurrences = new int[maxElement + 1];

            for (int i = 0; i < maxElement + 1; i++) {
                occurrences[i] = 0;
            }

            for (int i = 0; i < size; i++) {
                occurrences[array[i]]++;
            }

            for (int i = 0, j = 0; i <= maxElement; i++) {
                while (occurrences[i] > 0) {
                    array[j] = i;
                    j++;
                    occurrences[i]--;

                    CreateEvent(array, i);
                }
            }
        }

        private int GetMax(int[] array, int size) {
            var maxVal = array[0];

            for (int i = 1; i < size; i++) {
                if (array[i] > maxVal) {
                    maxVal = array[i];
                }
            }
            return maxVal;
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}