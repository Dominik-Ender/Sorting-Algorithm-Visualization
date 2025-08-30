using Events;

namespace Algorithms {

    class CountingSortAlgorithm : ISortingStrategy {

        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

            CountingSort(array);

            return eventList;
        }

        private void CountingSort(int[] array) {
            var size = array.Length;
            var maxElement = GetMax(array, size);
            var occurrences = new int[maxElement + 1];

            for(int i = 0; i < maxElement + 1; i++) {
                occurrences[i] = 0;
            }

            for(int i = 0; i < size; i++) {
                occurrences[array[i]]++;
            }

            for (int i = 0, j = 0; i <= maxElement; i++) {
                while (occurrences[i] > 0) {
                    array[j] = i;
                    j++;
                    occurrences[i]--;

                    Event _event = new Event((int[])array.Clone(), i);
                    eventList.Add(_event);
                }
            }
        }

        private int GetMax(int[] array, int size) {
            var maxVal = array[0];

            for(int i = 1; i < size; i++) {
                if (array[i] > maxVal) {
                    maxVal = array[i];
                }
            }
            return maxVal;
        }
    }
}