using Events;

namespace Algorithms {
    class ShellSortAlgorithm {

        private const int ARRAY_SIZE = 232;
        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

            ShellSort(array);

            return eventList;
        }

        private void ShellSort(int[] array) {
            for(int interval = array.Length / 2; interval > 0; interval /= 2) {
                for(int i = interval; i < array.Length; i++) {
                    var currentKey = array[i];
                    var k = i;

                    while(k >= interval && array[k - interval] > currentKey) {
                        array[k] = array[k - interval];
                        k -= interval;
                    }

                    array[k] = currentKey;

                    Event _event = new Event((int[])array.Clone(), i);
                    eventList.Add(_event);
                }
            }
        }
    }
}