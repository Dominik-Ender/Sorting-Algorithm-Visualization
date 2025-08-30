// https://www.geeksforgeeks.org/dsa/introsort-or-introspective-sort/
using Events;

namespace Algorithms {

    class IntroSortAlgorithm : ISortingStrategy {

        private int n = 0;
        private int[] array = GenerateRandomArray.GetRandomArray();
        List<Event> eventList = new List<Event>();
        private Event _event;

        public List<Event> GetEventList() {

            _event = new Event(array, 0);
            eventList.Add(_event);

            int maximumdepth = Convert.ToInt16(2 * Math.Log(array.Length));

            IntroSort(array, 0, array.Length - 1, maximumdepth);

            return eventList;
        }

        private void IntroSort(int[] array, int start, int end, int maxdepth) {
            int len = Length(array, start, end);

            if (len <= 1) {
                return;
            } else if (maxdepth == 0) {
                Heapsort(array);

            } else {
                int partitionpos = Partition(array, start, array.Length - 1);

                IntroSort(array, 0, partitionpos - 1, maxdepth - 1);

                IntroSort(array, partitionpos + 1, len, maxdepth - 1);
            }
        }

        private int Length(int[] array, int beginning, int ending) {
            int len = 0;

            if (beginning <= ending) {
                for (int i = beginning; i <= ending; i++) {
                    len++;
                }
            }
            return len;
        }

        private int Partition(int[] array, int start, int end) {
            int tem;
            int left = start; int right = end;
            int pivot = array[start];  

            while (left < right) {
                while (array[left] < pivot) {
                    left++;
                }

                while (array[right] > pivot) {
                    right--;
                }

                if (left < right) {
                    tem = array[left];
                    array[left] = array[right];
                    array[right] = tem;

                    _event = new Event((int[])array.Clone(), left);
                    eventList.Add(_event);

                    if (array[left] == array[right]) { 
                    left++;
                    }
                } else {
                    return right;
                }
            }
            return right;
        }

        private void Heapsort(int[] array) {
            int heapsize = array.Length; 

            for (int m = (heapsize / 2) - 1; m >= 0; m--) {
                Heapify(array, heapsize, m);
            }

            for (int n = array.Length - 1; n >= 0; n--) {
                int temp = array[n];
                array[n] = array[0];
                array[0] = temp;

                _event = new Event((int[])array.Clone(), temp);
                eventList.Add(_event);

                --heapsize;
                Heapify(array, heapsize, 0);
            }
        }

        private void Heapify(int[] array, int x, int y) {
            int max = 0;
            int r = (y + 1) * 2; 
            int l = ((y + 1) * 2) - 1;

            if (l < x && array[l] > array[y]) {
                max = l;
            } else {
                max = y;
            }
            if (r < x && array[r] > array[max]) {
                max = r;
            }
            if (max != y) {
                int temp;
                temp = array[y];
                array[y] = array[max];
                array[max] = temp;

                _event = new Event((int[])array.Clone(), max);
                eventList.Add(_event);

                Heapify(array, x, max);
            }
        }
    }
}
