using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Events;
using Algorithms;
// using Actions;

namespace RestControllers {

    [ApiController]
    [Route(Actions.SORTING)]
    public class RestController : ControllerBase {

		[HttpGet(Actions.BUBBLESORT)]
		public ActionResult<IEnumerable<Event>> GetBubbleSortAlgorithm() {

			BubbleSortAlgorithm bubbleSort = new BubbleSortAlgorithm();
            
            List<Event> eventList = bubbleSort.GetEventList();

			return Ok(eventList);
		}

        [HttpGet(Actions.BUCKETSORT)]
        public ActionResult<IEnumerable<Event>> GetBucketSortAlgorithm() {

            BucketSortAlgorithm bucketSort = new BucketSortAlgorithm();

            List<Event> eventList = bucketSort.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.COMBSORT)]
        public ActionResult<IEnumerable<Event>> GetCombSortAlgorithm() {

            CombSortAlgorithm combSortAlgorithm = new CombSortAlgorithm();

            List<Event> eventList = combSortAlgorithm.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.COUNTINGSORT)]
        public ActionResult<IEnumerable<Event>> GetCountingSortAlgorithm() {

            CountingSortAlgorithm countingSort = new CountingSortAlgorithm();

            List<Event> eventList = countingSort.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.CYCLESORT)]
        public ActionResult<IEnumerable<Event>> GetCycleSortAlgorithm() {

            CycleSortAlgorithm cycleSort = new CycleSortAlgorithm();

            List<Event> eventList = cycleSort.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.HEAPSORT)]
        public ActionResult<IEnumerable<Event>> GetHeapSortAlgorithm() {

            HeapSortAlgorithm heapSort = new HeapSortAlgorithm();

            List<Event> eventList = heapSort.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.INSERTIONSORT)]
		public ActionResult<IEnumerable<Event>> GetInsertionSortAlgorithm() {

			InsertionSortAlgorithm insertionSortAlgorithm = new InsertionSortAlgorithm();

			List<Event> eventList = insertionSortAlgorithm.GetEventList();

			return Ok(eventList);
		}

        [HttpGet(Actions.INTROSORT)]
        public ActionResult<IEnumerable<Event>> GetIntroSortAlgorithm() {

            IntroSortAlgorithm introSort = new IntroSortAlgorithm();

            List<Event> eventList = introSort.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.MERGESORT)]
		public ActionResult<IEnumerable<Event>> GetMergeSortAlgorithm() {

			MergeSortAlgorithm mergeSort = new MergeSortAlgorithm();

			List<Event> eventList = mergeSort.GetEventList();

			return Ok(eventList);
		}

        [HttpGet(Actions.PIGEONHOLESORT)]
        public ActionResult<IEnumerable<Event>> GetPigeonholeSortAlgorithm() {

            PigeonholeSortAlgorithm pigeonholeSort = new PigeonholeSortAlgorithm();

            List<Event> eventList = pigeonholeSort.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.QUICKSORT)]
		public ActionResult<IEnumerable<Event>> GetQuickSortAlgorithm() {

			QuickSortAlgorithm quickSort = new QuickSortAlgorithm();

			List<Event> eventList = quickSort.GetEventList();

			return Ok(eventList);
		}

        [HttpGet(Actions.RADIXSORT)]
        public ActionResult<IEnumerable<Event>> GetRadixSortAlgorithm() {

            RadixSortAlgorithm radixSortAlgorithm = new RadixSortAlgorithm();

            List<Event> eventList = radixSortAlgorithm.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.SELECTIONSORT)]
		public ActionResult<IEnumerable<Event>> GetSelectionSortAlgorithm() {

			SelectionSortAlgorithm selectionSort = new SelectionSortAlgorithm();

			List<Event> eventList = selectionSort.GetEventList();

			return Ok(eventList);
		}

        [HttpGet(Actions.SHELLSORT)]
        public ActionResult<IEnumerable<Event>> GetShellSortAlgorithm() {

            ShellSortAlgorithm shellSort = new ShellSortAlgorithm();

            List<Event> eventList = shellSort.GetEventList();

            return Ok(eventList);
        }

        [HttpGet(Actions.TIMSORT)]
        public ActionResult<IEnumerable<Event>> GetTimSortAlgorithm() {

            TimSortAlgorithm timSort = new TimSortAlgorithm();

            List<Event> eventList = timSort.GetEventList();

            return Ok(eventList);
        }
    }
}