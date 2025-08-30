using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {

    class SelectionSortAlgorithm {

        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

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

                Event _event = new Event((int[])array.Clone(), i);
                eventList.Add(_event);
            }
        }
    }
}