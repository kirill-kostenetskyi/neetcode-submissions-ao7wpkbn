public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adjList = new Dictionary<int, List<(int, int)>>();
        foreach(var node in times){
            var source = node[0];
            var target = node[1];
            var dest = node[2];
            if(adjList.TryGetValue(source, out var existing)){
                existing.Add((target, dest));
            } else {
                adjList.Add(source, new List<(int, int)>() { (target, dest) });
            }
        }

        var heap = new PriorityQueue<int, int>(); // node, priority
        var dict = new Dictionary<int, int>(); // node, distance_to_this_node
        dict.Add(k, 0);
        heap.Enqueue(k, 0);

        while(heap.Count > 0){
            heap.TryDequeue(out var node, out var priority);
            if(!adjList.ContainsKey(node)){
                continue;
            }
            if(priority > dict[node]){
                continue; // я долго не мог понять зачем это, но обьяснение такое:
                // если я уже дошел когда-то до этой ноды и значение там и так меньше
                // то я дальше буду делать дурную работу в цикле. 
            }
            foreach((int target, int distance) in adjList[node]){
                var newDistance = distance + priority;
                if(dict.TryGetValue(target, out var currentBestDistance)){
                    if(currentBestDistance > newDistance){
                        dict[target] = newDistance;
                        heap.Enqueue(target, newDistance);
                    }
                } else {
                    dict[target] = newDistance;
                    heap.Enqueue(target, newDistance);
                }
            }
        }
        
        if(dict.Count != n){
            return -1;
        }
        return dict.Values.Max();
    }
}