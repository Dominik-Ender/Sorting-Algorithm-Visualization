using Events;

namespace Algorithms {

    class QuickSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
            QuickSort(array, 0, array.Length - 1);

            return eventList;
        }

        private int Partition(int[] array, int low, int high) {
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

        private void Swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            CreateEvent(array, temp);
        }

        private void QuickSort(int[] array, int low, int high) {
            if (low < high) {
                int pi = Partition(array, low, high);

                CreateEvent(array, pi);

                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}