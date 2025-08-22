using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {
    class InsertionSortAlgorithm {

        private const int ARRAY_SIZE = 232;
        List<Event> eventList = new List<Event>();

        public List<Event> Sort() {

            int[] array = GenerateRandomArray.GetRandomArray(ARRAY_SIZE);

            Event event1 = new Event(array);
            eventList.Add(event1);

            InsertionSort(array);

            return eventList;
        }

        private void InsertionSort(int[] array) {
            int n = array.Length;
            for (int i = 1; i < n; ++i) {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key) {
                    array[j + 1] = array[j];
                    j = j - 1;
                }

                array[j + 1] = key;

                Event event1 = new Event((int[])array.Clone());
                eventList.Add(event1);
            }
        }
    }
}