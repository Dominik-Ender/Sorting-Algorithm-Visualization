using Events;

namespace Algorithms {

    class SelectionSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
            SelectionSort(array);

            return eventList;
        }

        private void SelectionSort(int[] array) {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++) {
                int min_idx = i;

                for (int j = i + 1; j < n; j++) {
                    if (array[j] < array[min_idx]) {
                        min_idx = j;
                    }
                }

                int temp = array[i];
                array[i] = array[min_idx];
                array[min_idx] = temp;

                CreateEvent(array, i);
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}