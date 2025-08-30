using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {
    class InsertionSortAlgorithm : ISortingStrategy {

        private const int ARRAY_SIZE = 232;
        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

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

                Event _event = new Event((int[])array.Clone(), i);
                eventList.Add(_event);
            }
        }
    }
}