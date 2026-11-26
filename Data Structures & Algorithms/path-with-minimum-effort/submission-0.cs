public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        var minHeap = new PriorityQueue<(int r, int c, int maxDiff), int>();
        minHeap.Enqueue((0, 0, 0), 0);
        var visited = new HashSet<(int, int)>();
        (int r, int c)[] dirs = {(-1, 0), (0, -1), (1, 0), (0, 1)};
        while(minHeap.Count > 0){
            var top = minHeap.Dequeue();
            var maxDiffSoFar = top.maxDiff;
            if(top.r == heights.Length - 1 && top.c == heights[0].Length - 1){
                return maxDiffSoFar;
            }
            if(visited.Contains((top.r, top.c))){
                continue;
            }
            visited.Add((top.r, top.c));

            foreach(var dir in dirs){
                var nr = dir.r + top.r;
                var nc = dir.c + top.c;
                if(nr >= 0 && nr < heights.Length && nc >= 0 && nc < heights[0].Length && !visited.Contains((nr, nc))){
                    var potentialDiff = Math.Abs(heights[top.r][top.c] - heights[nr][nc]);
                    var maxDiffOnThisPaht = Math.Max(potentialDiff, maxDiffSoFar);
                    minHeap.Enqueue((nr, nc, maxDiffOnThisPaht), maxDiffOnThisPaht);
                }
            }
        }
        return -1;
    }
}