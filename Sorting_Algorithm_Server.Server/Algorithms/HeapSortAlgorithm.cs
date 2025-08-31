using Events;

namespace Algorithms {

    class HeapSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
            HeapSort(array);

            return eventList;
        }

        private void HeapSort(int[] array) {
            if (array.Length <= 1) {
                return;
            }

            for (int i = array.Length / 2 - 1; i >= 0; i--) {
                Heapify(array, array.Length, i);
            }

            for (int i = array.Length - 1; i >= 0; i--) {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                CreateEvent(array, i);
                Heapify(array, i, 0);
            }
        }

        private void Heapify(int[] array, int size, int index) {
            int largestIndex = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < size && array[leftChild] > array[largestIndex]) {
                largestIndex = leftChild;
            }

            if (rightChild < size && array[rightChild] > array[largestIndex]) {
                largestIndex = rightChild;
            }

            if (largestIndex != index) {
                int temp = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = temp;

                CreateEvent(array, temp);
                Heapify(array, size, largestIndex);
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}