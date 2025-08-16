using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

class QuickSortAlgorithm : ISortingStrategy, IMessage {

    public async Task Sort(int[] array, WebSocket webSocket) {
        await QuickSort(array, 0, array.Length - 1, webSocket);
    }

    private static int Partition(int[] array, int low, int high) {
        int pivot = array[high];

        int i = low - 1;

        for(int j = low; j <= high - 1; j++) {
            if (array[j] < pivot) {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;   
    }

    private static void Swap(int[] array, int i, int j) {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    private async Task QuickSort(int[] array, int low, int high, WebSocket webSocket) {
        if(low < high) {
            int pi = Partition(array, low, high);

            await SendArray(array, webSocket);

            await QuickSort(array, low, pi - 1, webSocket);
            await QuickSort(array, pi + 1, high, webSocket);
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

        await Task.Delay(50);
    }
}