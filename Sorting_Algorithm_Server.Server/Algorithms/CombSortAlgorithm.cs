// https://www.geeksforgeeks.org/dsa/comb-sort/
using Events;

namespace Algorithms {

    class CombSortAlgorithm : ISortingStrategy {

        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

            CombSort(array);

            return eventList;
        }

        private void CombSort(int[] array) {
            int n = array.Length;

            int gap = n;

            bool swapped = true;

            while(gap != 1 || swapped == true) {
                gap = GetNextGap(gap);

                swapped = false;

                for(int i = 0; i < n - gap; i++) {
                    if (array[i] > array[i + gap]) {
                        int temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;

                        swapped = true;

                        Event _event = new Event((int[])array.Clone(), i);
                        eventList.Add(_event);
                    }
                }
            }
        }

        private int GetNextGap(int gap) {
            gap = (gap * 10) / 13;

            if (gap < 1) {
                return 1;
            }
            return gap;
        }
    }
}