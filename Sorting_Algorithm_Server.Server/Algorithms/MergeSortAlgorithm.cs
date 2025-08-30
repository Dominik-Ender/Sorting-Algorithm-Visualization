using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Events;

namespace Algorithms {

    class MergeSortAlgorithm : ISortingStrategy {

        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

            MergeSort(array, 0, array.Length - 1);

            return eventList;
        }

        private void MergeSort(int[] array, int left, int right) {
            if (left < right) {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);

                Event _event = new Event((int[])array.Clone(), middle);
                eventList.Add(_event);
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