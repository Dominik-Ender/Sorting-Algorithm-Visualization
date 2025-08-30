// https://code-maze.com/csharp-heap-sort/
using Events;

namespace Algorithms {

    class HeapSortAlgorithm : ISortingStrategy {

        private Event _event;
        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            _event = new Event(array, 0);
            eventList.Add(_event);

            HeapSort(array);

            return eventList;
        }

        private void HeapSort(int[] array) {
            if(array.Length <= 1) {
                return;
            }

            for(int i = array.Length / 2 - 1; i >= 0; i--) {
                Heapify(array, array.Length, i);
            }

            for(int i = array.Length - 1; i >= 0; i--) {
                var temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                _event = new Event((int[])array.Clone(), i);
                eventList.Add(_event);

                Heapify(array, i, 0);
            }
        }

        private void Heapify(int[] array, int size, int index) {
            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;

            if (leftChild < size && array[leftChild] > array[largestIndex]) {
                largestIndex = leftChild;
            }

            if(rightChild < size && array[rightChild] > array[largestIndex]) {
                largestIndex = rightChild;
            }

            if(largestIndex != index) {
                var temp = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = temp;

                //_event = new Event((int[])array.Clone(), index);
                //eventList.Add(_event);

                Heapify(array, size, largestIndex);
            }

            //_event = new Event((int[])array.Clone(), index);
            //eventList.Add(_event);
        }
    }
}