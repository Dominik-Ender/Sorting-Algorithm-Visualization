using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

class InsertionSortAlgorithm : ISortingStrategy, IMessage {

    public async Task Sort(int[] array, WebSocket webSocket) {
        await InsertionSort(array, webSocket);
    }

    private async Task InsertionSort(int[] array, WebSocket webSocket) {
        int n = array.Length;
        for(int i = 1; i < n; ++i) {
            int key = array[i];
            int j = i - 1;

            while(j >= 0 && array[j] > key) {
                array[j + 1] = array[j];
                j = j - 1;
            }

            array[j + 1] = key;

            await SendArray(array, webSocket);
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