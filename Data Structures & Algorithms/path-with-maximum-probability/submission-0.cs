public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
        var adj = new Dictionary<int, List<(int, double)>>();
        for(int r = 0; r < edges.Length; r++){
            var edge = edges[r];
            var source = edge[0];
            var target = edge[1];
            var weight = succProb[r];
            if(adj.TryGetValue(source, out var alreadySource)){
                alreadySource.Add((target, weight));
            } else {
                adj.Add(source, new List<(int, double)>{ (target, weight) });
            }
            if(adj.TryGetValue(target, out var alreadyTarget)){
                alreadyTarget.Add((source, weight));
            } else {
                adj.Add(target, new List<(int, double)>{ (source, weight) });
            }
        }

        var maxHeap = new PriorityQueue<int, double>(Comparer<double>.Create((x, y) => y.CompareTo(x)));
        maxHeap.Enqueue(start_node, 1);
        var dict = new Dictionary<int, double>();
        dict.Add(start_node, 1);

        while(maxHeap.Count > 0){
            maxHeap.TryDequeue(out var node, out var priority);
            if(priority < dict[node]){
                continue;
            }

            if(!adj.ContainsKey(node)){
                continue;
            }

            foreach((int target, double weight) in adj[node]){
                var newWeight = weight * priority;
                if(dict.TryGetValue(target, out var currentWeight)){
                    if(newWeight > currentWeight){
                        dict[target] = newWeight;
                        maxHeap.Enqueue(target, newWeight);
                    }
                } else {
                    dict[target] = newWeight;
                    maxHeap.Enqueue(target, newWeight);
                }
            }
        }

        if(dict.TryGetValue(end_node, out var bestDist)){
            return bestDist;
        } else {
            return 0;
        }
    }
}