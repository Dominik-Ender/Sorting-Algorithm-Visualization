using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

class BubbleSortAlgorithm : ISortingStrategy, IMessage {

    public async Task Sort(int[] array, WebSocket webSocket) {
        await BubbleSort(array, webSocket);
    }

    private async Task BubbleSort(int[] array, WebSocket webSocket) {
        int n = array.Length;
        
        for(int i = 0; i < n - 1; i++) {
            for(int j = 0; j < n - 1; j++) {
                if (array[j] > array[j + 1]) {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
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