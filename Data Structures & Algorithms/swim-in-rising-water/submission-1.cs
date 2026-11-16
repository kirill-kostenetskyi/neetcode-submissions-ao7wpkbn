public class Solution {
    public int SwimInWater(int[][] grid) {
        (int dr, int dc)[] dirs = {(0, 1), (1, 0), (-1, 0), (0, -1)};
        var minHeap = new PriorityQueue<(int R, int C, int Time), int>();
        minHeap.Enqueue((0,0,grid[0][0]), grid[0][0]);
        var visited = new HashSet<(int, int)>();
        var globalTime = 0;
        while(minHeap.Count > 0) {
            (int R, int C, int Time) = minHeap.Dequeue();
            if(Time > globalTime){
                globalTime = Time;
            }
            if(R == grid.Length - 1 && C == grid[0].Length - 1){
                return globalTime;
            }
            if(visited.Contains((R, C))){
                continue;
            }
            visited.Add((R, C));

            foreach(var dir in dirs){
                var nr = R + dir.dr;
                var nc = C + dir.dc;
                if(nr >= 0 && nr < grid.Length && nc >= 0 && nc < grid[0].Length && visited.Contains((nr, nc)) == false){
                    minHeap.Enqueue((nr, nc, grid[nr][nc]), grid[nr][nc]);
                }
            }
        }
        return - 1;
    }
}