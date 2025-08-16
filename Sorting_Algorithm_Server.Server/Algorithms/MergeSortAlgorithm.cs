using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

class MergeSortAlgorithm : ISortingStrategy, IMessage {

    public async Task Sort(int[] array, WebSocket webSocket) {
        await MergeSort(array, 0, array.Length - 1, webSocket);
    }

    private async Task MergeSort(int[] array, int left, int right, WebSocket webSocket) {
        if(left < right) {
            int middle = (left + right) / 2;
            await MergeSort(array, left, middle, webSocket);
            await MergeSort(array, middle + 1, right, webSocket);
            Merge(array, left, middle, right);

            await SendArray(array, webSocket);
        }
    }

    private void Merge(int[] array, int left, int middle, int right) {
        int[] temp = new int[array.Length];
        
        for(int i = left; i <= right; i++) {
            temp[i] = array[i];
        }

        int j = left;
        int k = middle + 1;
        int l = left;

        while(j <= middle && k <= right) {
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