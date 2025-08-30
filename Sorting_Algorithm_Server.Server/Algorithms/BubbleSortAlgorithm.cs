using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {

    class BubbleSortAlgorithm {

        private const int ARRAY_SIZE = 232;
        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event event1 = new Event(array, 0);
            eventList.Add(event1);

            BubbleSort(array);

            return eventList;
        }

        private void BubbleSort(int[] array) {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - 1; j++) {
                    if (array[j] > array[j + 1]) {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }

                Event _event = new Event((int[])array.Clone(), i);
                eventList.Add(_event);
            }
        }
    }
}