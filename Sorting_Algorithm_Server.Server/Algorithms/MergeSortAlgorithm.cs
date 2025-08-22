using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {

    class MergeSortAlgorithm {

        private const int ARRAY_SIZE = 232;
        List<Event> eventList = new List<Event>();

        public List<Event> Sort() {

            int[] array = GenerateRandomArray.GetRandomArray(ARRAY_SIZE);

            Event event1 = new Event(array);
            eventList.Add(event1);

            MergeSort(array, 0, array.Length - 1);

            return eventList;
        }

        private void MergeSort(int[] array, int left, int right) {
            if (left < right) {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);

                Event event1 = new Event(array);
                eventList.Add(event1);
            }
        }

        private void Merge(int[] array, int left, int middle, int right) {
            int[] temp = new int[array.Length];

            for (int i = left; i <= right; i++) {
                temp[i] = array[i];
            }

            int j = left;
            int k = middle + 1;
            int l = left;

            while (j <= middle && k <= right) {
                if (temp[j] <= temp[k]) {
                    array[l] = temp[j];
                    j++;
                } else {
                    array[l] = temp[k];
                    k++;
                }
                l++;
            }

            while (j <= middle) {
                array[l] = temp[j];
                l++;
                j++;
            }
        }
    }
}