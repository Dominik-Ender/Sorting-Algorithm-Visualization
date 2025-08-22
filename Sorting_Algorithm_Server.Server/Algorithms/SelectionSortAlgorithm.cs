using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {

    class SelectionSortAlgorithm {

        private const int ARRAY_SIZE = 232;
        List<Event> eventList = new List<Event>();

        public List<Event> Sort() {

            int[] array = GenerateRandomArray.GetRandomArray(ARRAY_SIZE);

            Event event1 = new Event(array);
            eventList.Add(event1);

            SelectionSort(array);

            return eventList;
        }

        private void SelectionSort(int[] array) {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++) {
                int min_idx = i;

                for (int j = i + 1; j < n; j++) {
                    if (array[j] < array[min_idx]) {
                        min_idx = j;
                    }
                }

                int temp = array[i];
                array[i] = array[min_idx];
                array[min_idx] = temp;

                Event event1 = new Event((int[])array.Clone());
                eventList.Add(event1);
            }
        }
    }
}