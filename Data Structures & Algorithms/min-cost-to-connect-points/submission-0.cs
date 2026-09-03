public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        var adj = new Dictionary<int, List<(int, int)>>(); // source, target, distance
        for(int i = 0; i < points.Length; i++){
            var x = points[i][0];
            var y = points[i][1];
            adj[i] = new List<(int, int)>();

            for(int j = 0; j < points.Length; j++){
                if(i == j){
                    continue;
                }
                var x1 = points[j][0];
                var y1 = points[j][1];

                var distance = Math.Abs(x - x1) + Math.Abs(y - y1);
                adj[i].Add((j, distance));
            }
        }
        var totalCost = 0;
        var minHeap = new PriorityQueue<(int, int), int>(); // source, target, distance
        var visited = new HashSet<int>();

        foreach(var nei in adj[0]){
            var target = nei.Item1;
            var distance = nei.Item2;
            minHeap.Enqueue((0, target), distance);
        }
        visited.Add(0);
        while(minHeap.Count > 0){
            minHeap.TryDequeue(out var top, out var priority);
            var source = top.Item1;
            var target = top.Item2;
            var distance = priority;

            if(visited.Contains(target)){
                continue;
            }

            visited.Add(target);
            totalCost += distance;

            foreach((int nextTarget, int nextDistance) in adj[target]){
                minHeap.Enqueue((target, nextTarget), nextDistance);
            }
        }
        return totalCost;
    }
}