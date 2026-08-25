public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adjList = new Dictionary<int, List<(int neighbor, int weight)>>();
        foreach(var ver in times){
            var currentNode = ver[0];
            var targetNode = ver[1];
            var weight = ver[2];
            if(!adjList.TryGetValue(currentNode, out var neighbors)){
                neighbors = new();
                adjList[currentNode] = neighbors;
            }
            neighbors.Add((targetNode, weight));

        }

        var allResults = new Dictionary<int, int>();
        var minHeap = new PriorityQueue<int, int>(); // item, priority
        minHeap.Enqueue(k, 0);

        while(minHeap.Count > 0) {
            minHeap.TryDequeue(out int node, out int currentDistance);
                            
            if(allResults.ContainsKey(node)){
                continue;
            }

            allResults.Add(node, currentDistance);

            if(!adjList.TryGetValue(node, out var neighbors)){
                continue;
            }
            foreach(var nei in neighbors){
                var nextNei = nei.neighbor;
                var nextWeight = nei.weight;

                minHeap.Enqueue(nextNei, nextWeight + currentDistance);
            }
        }

        if(allResults.Count == n){
            return allResults.Values.Max();
        }

        return -1;
    }
} 