using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

class SelectionSortAlgorithm : ISortingStrategy, IMessage {

    public async Task Sort(int[] array, WebSocket webSocket) {
        await SelectionSort(array, webSocket);
    }

    private async Task SelectionSort(int[] array, WebSocket webSocket) {
        int n = array.Length;
        for(int i = 0; i < n - 1; i++) {
            int min_idx = i;

            for(int j = i + 1; j < n; j++) {
                if (array[j] < array[min_idx]) {
                    min_idx = j;
                }
            }

            int temp = array[i];
            array[i] = array[min_idx];
            array[min_idx] = temp;

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