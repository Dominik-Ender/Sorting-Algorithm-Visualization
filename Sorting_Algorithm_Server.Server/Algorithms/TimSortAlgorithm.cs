using Events;

namespace Algorithms {

    class TimSortAlgorithm : ISortingStrategy, IEventCreate {

        private int RUN = 32;
        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
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
            for (int i = left +1; i <= right; i++) {
                int temp = array[i];
                int j = i - 1;

                while (j >= left && array[j] > temp) {
                    array[j + 1] = array[j];
                    j--;

                    CreateEvent(array, temp);
                }
                array[j + 1] = temp;
            }
        }

        private void Merge(int[] array, int left, int middle, int right) {
            int length1 = middle - left + 1, length2 = right - middle;
            int[] leftArray = new int[length1];
            int[] rightArray = new int[length2];

            for (int x = 0; x < length1; x++) {
                leftArray[x] = array[left + x];
            }

            for (int x = 0; x < length2; x++) {
                rightArray[x] = array[middle + 1 + x];
            }

            int i = 0;
            int j = 0;
            int k = left;

            while (i < length1 && j < length2) {
                if (leftArray[i] <= rightArray[j]) {
                    array[k] = leftArray[i];
                    i++;

                    CreateEvent(array, i);
                } else {
                    array[k] = rightArray[j];
                    j++;

                    CreateEvent(array, j);
                }
                k++;
            }

            while (i < length1) {
                array[k] = leftArray[i];
                k++;
                i++;

                CreateEvent(array, i);
            }

            while (j < length2) {
                array[k] = rightArray[j];
                k++;
                j++;

                CreateEvent(array, j);
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}
