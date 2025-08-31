using Events;

namespace Algorithms {

    class BubbleSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
            BubbleSort(array);

            return eventList;
        }

        private void BubbleSort(int[] array) {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - 1; j++) {
                    if (array[j] > array[j + 1]) {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
                CreateEvent(array, i);
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}