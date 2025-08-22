using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {

    class QuickSortAlgorithm {

        private const int ARRAY_SIZE = 232;
        List<Event> eventList = new List<Event>();

        public List<Event> Sort() {

            int[] array = GenerateRandomArray.GetRandomArray(ARRAY_SIZE);

            Event event1 = new Event(array);
            eventList.Add(event1);

            QuickSort(array, 0, array.Length - 1);

            return eventList;
        }

        private static int Partition(int[] array, int low, int high) {
            int pivot = array[high];

            int i = low - 1;

            for (int j = low; j <= high - 1; j++) {
                if (array[j] < pivot) {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private void QuickSort(int[] array, int low, int high) {
            if (low < high) {
                int pi = Partition(array, low, high);

                Event event1 = new Event((int[])array.Clone());
                eventList.Add(event1);

                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }
    }
}