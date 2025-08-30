// https://code-maze.com/bucket-sort-csharp/
using Events;

namespace Algorithms {

    class BucketSortAlgorithm : ISortingStrategy {

        List<Event> eventList = new List<Event>();

        public List<Event> GetEventList() {

            int[] array = GenerateRandomArray.GetRandomArray();

            Event _event = new Event(array, 0);
            eventList.Add(_event);

            BucketSort(array);
            
            return eventList;
        }

        public void BucketSort(int[] array) {
            if(array == null || array.Length <= 1) {
                return;
            }

            int maxValue = array[0];
            int minValue = array[0];

            for(int i = 1; i < array.Length; i++) {
                if (array[i] > maxValue) {
                    maxValue = array[i];
                }

                if (array[i] < minValue) {
                    minValue = array[i];
                }
            }

            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            for(int i = 0; i < array.Length; i++) {
                if (bucket[array[i] - minValue] == null) {
                    bucket[array[i] - minValue] = new LinkedList<int>();
                }

                bucket[array[i] - minValue].AddLast(array[i]);
            }

            var index = 0;

            for(int i = 0; i < bucket.Length; i++) {
                if (bucket[i] != null) {
                    LinkedListNode<int> node = bucket[i].First;

                    while(node != null) {
                        array[index] = node.Value;
                        node = node.Next;
                        index++;

                        Event _event = new Event((int[])array.Clone(), index);
                        eventList.Add(_event);
                    }
                }
            }
        }
    }
}