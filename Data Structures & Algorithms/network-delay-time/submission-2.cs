public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adjList = new Dictionary<int, List<(int Dest, int Time)>>();
        for(int i = 1; i <= n; i++){
            adjList[i] = new List<(int, int)>(){};
        }
        foreach(var t in times){
            var source = t[0];
            var dest = t[1];
            var time = t[2];
            adjList[source].Add((dest, time));
        }

        var minHeap = new PriorityQueue<(int Node, int Time), int>();
        minHeap.Enqueue((k, 0), 0);
        var visited = new HashSet<int>();

        while(minHeap.Count > 0){
            (int Node, int Time) = minHeap.Dequeue();
            if(visited.Contains(Node)){
                continue;
            }
            visited.Add(Node);
            if(visited.Count == n){
                return Time;
            }

            var neis = adjList[Node];
            foreach(var nei in neis){
                var newTime = nei.Time + Time;
                minHeap.Enqueue((nei.Dest, newTime), newTime);
            }
        }
        return -1;
    }
}