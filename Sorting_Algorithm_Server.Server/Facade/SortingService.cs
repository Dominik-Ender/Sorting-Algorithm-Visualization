using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

class SortingService : IMessage {

    private static readonly ConcurrentDictionary<WebSocket, SemaphoreSlim> semaphores = new ();

    private const int ARRAY_SIZE = 232;
    private const string MERGE_SORT = "mergeSort";
    private const string QUICK_SORT = "quickSort";
    private const string BUBBLE_SORT = "bubbleSort";
    private const string SELECTION_SORT = "selectionSort";
    private const string INSERTION_SORT = "insertionSort";
    private const string UNKNOWN_ARGUMENT_EXCEPTION = "Unknown Sorting Algorith";

    public SortingService(WebSocket webSocket, string message) {
        int[]array = GenerateRandomArray.GetRandomArray(ARRAY_SIZE);
        ChooseAlgorithm(array, webSocket, message);
    }

    private async void ChooseAlgorithm(int[] array, WebSocket webSocket, string message) {

        var semaphore = semaphores.GetOrAdd(webSocket, _ => new SemaphoreSlim(1, 1));

        if(!await semaphore.WaitAsync(0)) {
            return;
        }

        try {
            ISortingStrategy strategy = message switch {
                MERGE_SORT => new MergeSortAlgorithm(),
                QUICK_SORT => new QuickSortAlgorithm(),
                BUBBLE_SORT => new BubbleSortAlgorithm(),
                SELECTION_SORT => new SelectionSortAlgorithm(),
                INSERTION_SORT => new InsertionSortAlgorithm(),
                _ => throw new ArgumentException(UNKNOWN_ARGUMENT_EXCEPTION)
            };
            await SendArray(array, webSocket);

            var context = new SortingContext(strategy);
            await context.PerformSort(array, webSocket);

        } finally {
            semaphore.Release();
        }
    }

    public async Task SendArray(int[] array, WebSocket webSocket) {
        string message = JsonSerializer.Serialize(array);
        byte[] sendMessage = Encoding.UTF8.GetBytes(message);

        await webSocket.SendAsync(
            new ArraySegment<byte>(sendMessage, 0, sendMessage.Length),
            WebSocketMessageType.Text,
            true,
            CancellationToken.None);

        await Task.Delay(2000);
    }
}