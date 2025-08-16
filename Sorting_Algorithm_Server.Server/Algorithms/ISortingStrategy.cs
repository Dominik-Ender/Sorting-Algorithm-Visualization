using System.Net.WebSockets;

interface ISortingStrategy {
    Task Sort(int[] arr, WebSocket webSocket);
}