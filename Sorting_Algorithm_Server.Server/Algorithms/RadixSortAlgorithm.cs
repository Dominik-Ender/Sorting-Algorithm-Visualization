// https://code-maze.com/csharp-radix-sort/
using Events;

namespace Algorithms {

    class RadixSortAlgorithm : ISortingStrategy {

        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

            RadixSort(array);

            return eventList;
        }

        private void RadixSort(int[] array) {
            var max = GetMax(array);

            for(int exponent = 1; max / exponent > 0; exponent *= 10) {
                CountingSort(array, exponent);
            }
        }

        private int GetMax(int[] array) {
            var max = array[0];

            for(int i = 1; i < array.Length; i++) {
                if (array[i] > max) {
                    max = array[i];
                }
            }
            return max;
        }

        private void CountingSort(int[] array, int exponent) {
            var outputArray = new int[array.Length];
            var occurences = new int[10];

            for(int i = 0; i < 10; i++) {
                occurences[i] = 0;
            }

            for(int i = 0; i < array.Length; i++) {
                occurences[(array[i] / exponent) % 10]++;
            }

            for(int i = 1; i < 10; i++) {
                occurences[i] += occurences[i - 1];
            }

            for(int i = array.Length - 1; i >= 0; i--) {
                outputArray[occurences[(array[i] / exponent) % 10] - 1] = array[i];
                occurences[(array[i] / exponent) % 10]--;
            }

            for(int i = 0; i < array.Length; i++) {
                array[i] = outputArray[i];

                Event _event = new Event((int[])array.Clone(), 0);
                eventList.Add(_event);
            }
        }
    }
}





