public class Solution {
    public int OrangesRotting(int[][] grid) {
        (int dr, int dc)[] dirs = {(0, 1), (1, 0), (0, -1), (-1, 0)};
        var q = new Queue<(int r, int c, int d)>();
        for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c < grid[0].Length; c++){
                if(grid[r][c] == 2){
                    q.Enqueue((r, c, 0));
                }
            }
        }
        var lastT = 0;
        while(q.Count > 0){
            (int r, int c, int t) = q.Dequeue();
            lastT = t;
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;
                if(nr < 0 || nr >= grid.Length || nc < 0 || nc >= grid[0].Length || grid[nr][nc] == 2 || grid[nr][nc] == 0){
                    continue;
                }
                grid[nr][nc] = 2;
                q.Enqueue((nr, nc, t + 1));
            }
        }
        bool leftFresh = false;
        for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c < grid[0].Length; c++){
                if(grid[r][c] == 1){
                    leftFresh = true;
                }
            }
        }
        return leftFresh ? -1 : lastT;
    }
}