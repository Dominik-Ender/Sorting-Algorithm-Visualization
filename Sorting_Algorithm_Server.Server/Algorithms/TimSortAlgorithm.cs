// https://www.geeksforgeeks.org/dsa/timsort/
using Events;

namespace Algorithms {

    class TimSortAlgorithm {

        private const int ARRAY_SIZE = 232;
        private int RUN = 32;
        List<Event> eventList = new List<Event>();
        private Event _event;

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            _event = new Event(array, 0);
            eventList.Add(_event);

            TimSort(array);

            return eventList;
        }

        private void TimSort(int[] array) {
            for (int i = 0; i < array.Length; i += RUN) {
                InsertionSort(array, i, Math.Min((i + RUN - 1), (array.Length - 1)));
            }

            for (int size = RUN; size < array.Length; size = 2 * size) {
                for (int left = 0; left < array.Length; left += 2 * size) {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (array.Length - 1));

                    if (mid < right) {
                        Merge(array, left, mid, right);
                    }
                }
            }
        }

        private void InsertionSort(int[] array, int left, int right) {
            for(int i = left +1; i <= right; i++) {
                int temp = array[i];
                int j = i - 1;

                while(j >= left && array[j] > temp) {
                    array[j + 1] = array[j];
                    j--;

                    _event = new Event((int[])array.Clone(), temp);
                    eventList.Add(_event);
                }
                array[j + 1] = temp;
            }
        }

        private void Merge(int[] array, int l, int m, int r) {
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];

            for(int x = 0; x < len1; x++) {
                left[x] = array[l + x];
            }

            for(int x = 0; x < len2; x++) {
                right[x] = array[m + 1 + x];
            }

            int i = 0;
            int j = 0;
            int k = l;

            while(i < len1 && j < len2) {
                if (left[i] <= right[j]) {
                    array[k] = left[i];
                    i++;

                    _event = new Event((int[])array.Clone(), i);
                    eventList.Add(_event);
                } else {
                    array[k] = right[j];
                    j++;

                    _event = new Event((int[])array.Clone(), j);
                    eventList.Add(_event);
                }
                k++;
            }

            while(i <len1) {
                array[k] = left[i];
                k++;
                i++;

                _event = new Event((int[])array.Clone(), i);
                eventList.Add(_event);
            }

            while(j < len2) {
                array[k] = right[j];
                k++;
                j++;

                _event = new Event((int[])array.Clone(), j);
                eventList.Add(_event);
            }
        }
    }
}
