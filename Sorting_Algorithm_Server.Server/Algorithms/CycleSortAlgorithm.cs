using Events;

namespace Algorithms {

    class CycleSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
            CycleSort(array);

            return eventList;
        }

        private void CycleSort(int[] array) {
            int writes = 0;

            for (int cycleStart = 0; cycleStart <= array.Length - 2; cycleStart++) {
                int item = array[cycleStart];
                int pos = cycleStart;

                for (int i = cycleStart + 1; i < array.Length; i++) {
                    if (array[i] < item) {
                        pos++;
                    }
                }

                if (pos == cycleStart) {
                    continue;
                }

                while (item == array[pos]) {
                    pos += 1;
                }

                if (pos != cycleStart) {
                    int temp = item;
                    item = array[pos];
                    array[pos] = temp;
                    writes++;

                    CreateEvent(array, cycleStart);
                }

                while (pos != cycleStart) {
                    pos = cycleStart;

                    for (int i = cycleStart + 1; i < array.Length; i++) {
                        if (array[i] < item) {
                            pos += 1;
                        }
                    }

                    while (item == array[pos]) {
                        pos += 1;
                    }

                    if (item != array[pos]) {
                        int temp = item;
                        item = array[pos];
                        array[pos] = temp;
                        writes++;

                        CreateEvent(array, cycleStart);
                    }
                }
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}
