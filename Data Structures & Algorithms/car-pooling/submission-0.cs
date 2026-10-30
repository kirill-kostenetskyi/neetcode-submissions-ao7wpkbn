public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        var startMap = new Dictionary<int, List<(int Count, int End)>>();
        var endPoint = 0;
        foreach(var t in trips){
            var count = t[0];
            var start = t[1];
            var end = t[2];
            if(startMap.TryGetValue(start, out var list)){
                list.Add((count, end));
            } else {
                startMap[start] = new List<(int, int)>(){ (count, end) };
            }
            endPoint = Math.Max(endPoint, end);
        }

        var minHeap = new PriorityQueue<(int Count, int End), int>();
        var total = 0;
        for(int t = 0; t <= endPoint; t++){
            if(startMap.ContainsKey(t)){
                // try to fit people
                foreach(var car in startMap[t]){
                    total += car.Count;
                    minHeap.Enqueue((car.Count, car.End), car.End);  
                }
            }
            // maybe someone left?
            while(minHeap.Count > 0 && t >= minHeap.Peek().End){
                var topHeap = minHeap.Dequeue();
                total -= topHeap.Count;
            }
            if(total > capacity){
                return false;
            }
        }
        return true;
    }
}