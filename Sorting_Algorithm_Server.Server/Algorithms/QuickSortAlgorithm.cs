using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {

    class QuickSortAlgorithm : ISortingStrategy {

        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

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

                Event _event = new Event((int[])array.Clone(), pi);
                eventList.Add(_event);

                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }
    }
}