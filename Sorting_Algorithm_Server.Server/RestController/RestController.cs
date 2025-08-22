using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestControllers.Models;
using Events;
using Algorithms;

namespace RestControllers {

    [ApiController]
    [Route("api/test")]
    public class RestController : ControllerBase {

		[HttpGet("bubbleSort")]
		public ActionResult<IEnumerable<Event>> GetBubbleSortAlgorithm() {

			BubbleSortAlgorithm bubbleSort = new BubbleSortAlgorithm();
            
            List<Event> eventList = bubbleSort.Sort();

			return Ok(eventList);
		}

		[HttpGet("insertionSort")]
		public ActionResult<IEnumerable<Event>> GetInsertionSortAlgorithm() {

			InsertionSortAlgorithm insertionSortAlgorithm = new InsertionSortAlgorithm();

			List<Event> eventList = insertionSortAlgorithm.Sort();

			return Ok(eventList);
		}

		[HttpGet("mergeSort")]
		public ActionResult<IEnumerable<Event>> GetMergeSortAlgorithm() {

			MergeSortAlgorithm mergeSort = new MergeSortAlgorithm();

			List<Event> eventList = mergeSort.Sort();

			return Ok(eventList);
		}

		[HttpGet("quickSort")]
		public ActionResult<IEnumerable<Event>> GetQuickSortAlgorithm() {

			QuickSortAlgorithm quickSort = new QuickSortAlgorithm();

			List<Event> eventList = quickSort.Sort();

			return Ok(eventList);
		}

		[HttpGet("selectionSort")]
		public ActionResult<IEnumerable<Event>> GetSelectionSortAlgorithm() {

			SelectionSortAlgorithm selectionSort = new SelectionSortAlgorithm();

			List<Event> eventList = selectionSort.Sort();

			return Ok(eventList);
		}
    }
}