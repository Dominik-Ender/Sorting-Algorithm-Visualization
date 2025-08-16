using System.Net.WebSockets;

class SortingContext {

    private ISortingStrategy sortingStrategy;

    public SortingContext(ISortingStrategy sortingStrategy) {
        this.sortingStrategy = sortingStrategy;
    }

    public async Task PerformSort(int[] array, WebSocket webSocket) {
        await sortingStrategy.Sort(array, webSocket);
    }
}