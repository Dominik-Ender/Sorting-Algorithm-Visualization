using Events;

namespace Algorithms {

    class IntroSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);

            // int maximumdepth = (int)(2 * Math.Floor(Math.Log(n) / Math.Log(2)));
            int maximumdepth = (int)(2 * Math.Floor(Math.Log2(array.Length)));

            IntroSort(array, 0, array.Length - 1, maximumdepth);

            return eventList;
        }

        private void IntroSort(int[] array, int start, int end, int maximumDepth) {
            int length = end - start + 1;

            if (length <= 1) {
                return;
            } else if (length <= 16) {
                InsertionSort(array, start, end);
            } else if (maximumDepth == 0) {
                HeapsortRange(array, start, end);
            } else {
                int partitionPosition = Partition(array, start, end);

                IntroSort(array, start, partitionPosition - 1, maximumDepth - 1);
                IntroSort(array, partitionPosition + 1, end, maximumDepth - 1);
            }
        }

        private int Partition(int[] array, int start, int end) {
            int pivot = array[start];
            int left = start + 1;
            int right = end;

            while (true) {
                while (left <= right && array[left] <= pivot) {
                    left++;
                }

                while (left <= right && array[right] >= pivot) {
                    right--;
                }

                if (left > right) {
                    break;
                }

                Swap(array, left, right);
                CreateEvent(array, left);
            }
            Swap(array, start, right);
            CreateEvent(array, right);

            return right;
        }

        private void Swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private void InsertionSort(int[] array, int start, int end) {
            for (int i = start + 1; i <= end; i++) {
                int key = array[i];
                int j = i - 1;

                while (j >= start && array[j] > key) {
                    array[j + 1] = array[j];
                    CreateEvent(array, j + 1);
                    j--;
                }
                array[j + 1] = key;
                CreateEvent(array, j + 1);
            }
        }

        private void HeapsortRange(int[] array, int start, int end) {
            int heapSize = end - start + 1;

            for (int i = start + heapSize / 2 - 1; i >= start; i--) {
                HeapifyRange(array, start, heapSize, i);
            }

            for (int i = end; i > start; i--) {
                Swap(array, start, i);
                CreateEvent(array, i);
                heapSize--;
                HeapifyRange(array, start, heapSize, start);
            }
        }

        private void HeapifyRange(int[] array, int start, int heapSize, int rootIndex) {
            int largest = rootIndex;
            int left = 2 * (rootIndex - start) + 1 + start;
            int right = 2 * (rootIndex - start) + 2 + start;

            if (left < start + heapSize && array[left] > array[largest]) {
                largest = left;
            }

            if (right < start + heapSize && array[right] > array[largest]) {
                largest = right;
            }

            if (largest != rootIndex) {
                Swap(array, rootIndex, largest);
                CreateEvent(array, largest);
                HeapifyRange(array, start, heapSize, largest);
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}
