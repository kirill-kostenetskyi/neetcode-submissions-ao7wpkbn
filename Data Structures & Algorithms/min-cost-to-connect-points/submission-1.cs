public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int totalDistance = 0;
        var minHeap = new PriorityQueue<(int PointIndex, int DistanceFromLast), int>();
        var visited = new HashSet<int>();
        minHeap.Enqueue((0, 0), 0);

        while(minHeap.Count > 0){
            (int PointIndex, int DistanceFromLast) = minHeap.Dequeue();
            if(visited.Contains(PointIndex)){
                continue;
            }
            visited.Add(PointIndex);
            totalDistance += DistanceFromLast;
            for(int i = 0; i < points.Length; i++){
                if(visited.Contains(i)){
                    continue;
                }
                var currentXY = points[PointIndex];
                var distanceToNext = Math.Abs(currentXY[0] - points[i][0]) + Math.Abs(currentXY[1] - points[i][1]);
                minHeap.Enqueue((i, distanceToNext), distanceToNext);
            }
        }

        return totalDistance;
    }
}