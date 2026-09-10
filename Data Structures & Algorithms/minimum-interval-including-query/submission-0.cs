public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        var sortedQueries = queries.OrderBy(x => x).ToArray();
        var res = new Dictionary<int, int>();
        var minHeap = new PriorityQueue<(int Size, int End), int>(); // (size, end), size
        var i = 0;
        foreach(var q in sortedQueries){

            while(i < intervals.Length && intervals[i][0] <= q){
                var start = intervals[i][0];
                var end = intervals[i][1];
                var size = end - start + 1;
                minHeap.Enqueue((size, end), size);
                i++;
            }

            while(minHeap.Count > 0 && minHeap.Peek().End < q){
                minHeap.Dequeue();
            }

            if(minHeap.Count > 0){
                res[q] = minHeap.Peek().Size;
            } else {
                res[q] = -1;
            }
        }
        
        for(int j = 0; j < queries.Length; j++){
            queries[j] = res[queries[j]];
        }

        return queries;
    }
}