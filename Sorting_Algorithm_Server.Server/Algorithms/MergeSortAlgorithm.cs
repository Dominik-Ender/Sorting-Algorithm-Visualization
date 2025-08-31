using Events;

namespace Algorithms {

    class MergeSortAlgorithm : ISortingStrategy, IEventCreate {

        private Event _event;
        private List<Event> eventList = new List<Event>();
        private int[] array = GenerateRandomArray.GetRandomArray();

        public List<Event> GetEventList() {
            int[] array = GenerateRandomArray.GetRandomArray();

            CreateEvent(array, 0);
            MergeSort(array, 0, array.Length - 1);

            return eventList;
        }

        private void MergeSort(int[] array, int left, int right) {
            if (left < right) {
                int middle = (left + right) / 2;

                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                Merge(array, left, middle, right);
                CreateEvent(array, middle);
            }
        }

        private void Merge(int[] array, int left, int middle, int right) {
            int[] temp = new int[array.Length];

            for (int i = left; i <= right; i++) {
                temp[i] = array[i];
            }

            int j = left;
            int k = middle + 1;
            int l = left;

            while (j <= middle && k <= right) {
                if (temp[j] <= temp[k]) {
                    array[l] = temp[j];
                    j++;
                } else {
                    array[l] = temp[k];
                    k++;
                }
                l++;
            }

            while (j <= middle) {
                array[l] = temp[j];
                l++;
                j++;
            }
        }

        public void CreateEvent(int[] array, int index) {
            _event = new Event((int[])array.Clone(), index);
            eventList.Add(_event);
        }
    }
}