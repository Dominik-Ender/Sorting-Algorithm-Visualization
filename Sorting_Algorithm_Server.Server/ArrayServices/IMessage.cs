using System.Net.WebSockets;

interface IMessage {
    Task SendArray(int[] array, WebSocket webSocket);
}