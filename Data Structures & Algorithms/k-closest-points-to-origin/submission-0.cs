public class Solution {
    private PriorityQueue<(int x, int y), double> pq = new PriorityQueue<(int x, int y), double>();
    public int[][] KClosest(int[][] points, int k) {
        foreach(var point in points){
            var x = point[0];
            var y = point[1];
            var dis = Math.Pow(x, 2) + Math.Pow(y, 2);
            pq.Enqueue((x, y),-dis);
        }

        while(pq.Count > k){
            pq.Dequeue();
        }
        var result = new List<int[]>();
        
        while(pq.Count > 0){
            var (x, y) = pq.Dequeue();
            result.Add(new int[2]{
                x, y
            });
        }

        return result.ToArray();
    }
}