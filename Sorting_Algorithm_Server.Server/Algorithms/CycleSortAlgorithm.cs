// https://www.geeksforgeeks.org/dsa/cycle-sort/
using Events;

namespace Algorithms {

    class CycleSortAlgorithm : ISortingStrategy {

        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

            CycleSort(array);

            return eventList;
        }

        private void CycleSort(int[] array) {
            int writes = 0;

            for (int cycle_start = 0; cycle_start <= array.Length - 2; cycle_start++) {
                int item = array[cycle_start];

                int pos = cycle_start;

                for (int i = cycle_start + 1; i < array.Length; i++) {
                    if (array[i] < item) {
                        pos++;
                    }
                }

                if (pos == cycle_start) {
                    continue;
                }

                while (item == array[pos]) {
                    pos += 1;
                }

                if (pos != cycle_start) {
                    int temp = item;
                    item = array[pos];
                    array[pos] = temp;
                    writes++;

                    Event _event = new Event((int[])array.Clone(), cycle_start);
                    eventList.Add(_event);
                }

                while (pos != cycle_start) {
                    pos = cycle_start;

                    for (int i = cycle_start + 1; i < array.Length; i++) {
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

                        Event _event = new Event((int[])array.Clone(), cycle_start);
                        eventList.Add(_event);
                    }
                }
            }
        }
    }
}
