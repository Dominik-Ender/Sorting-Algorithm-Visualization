using Events;

namespace Algorithms {

    class CombSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            CreateEvent(array, 0);
            CombSort(array);

            return eventList;
        }

        private void CombSort(int[] array) {
            int n = array.Length;

            int gap = n;

            bool swapped = true;

            while (gap != 1 || swapped == true) {
                gap = GetNextGap(gap);

                swapped = false;

                for (int i = 0; i < n - gap; i++) {
                    if (array[i] > array[i + gap]) {
                        int temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;

                        swapped = true;

                        CreateEvent(array, i);
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

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}