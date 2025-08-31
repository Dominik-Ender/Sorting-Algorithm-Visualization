using Events;

namespace Algorithms {
    class ShellSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
            ShellSort(array);

            return eventList;
        }

        private void ShellSort(int[] array) {
            for (int interval = array.Length / 2; interval > 0; interval /= 2) {
                for (int i = interval; i < array.Length; i++) {
                    int currentKey = array[i];
                    int k = i;

                    while (k >= interval && array[k - interval] > currentKey) {
                        array[k] = array[k - interval];
                        k -= interval;
                    }
                    array[k] = currentKey;

                    CreateEvent(array, i);
                }
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}