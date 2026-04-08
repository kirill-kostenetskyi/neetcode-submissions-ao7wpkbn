public class Solution {
    private (int r, int c)[] dirs = new[]{
        (0, 1),
        (1, 0),
        (-1, 0),
        (0, -1),
    };

    public int MaxAreaOfIsland(int[][] grid) {
        var maxArea = 0;
         for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c < grid[0].Length; c++){
                if(grid[r][c] == 1){
                    var area = GetTheArea(r, c, grid);
                    maxArea = Math.Max(area, maxArea);
                }
            } 
        }
        return maxArea;
    }

    private int GetTheArea(int startR, int startC, int[][] grid){
        var q = new Queue<(int r, int c)>();
        q.Enqueue((startR, startC));
        grid[startR][startC] = 0;

        int area = 0;
        while(q.Count() > 0){
            var (r, c) = q.Dequeue();
            area = area + 1;

            foreach(var (dr, dc) in dirs){
                var nr = r + dr;
                var nc = c + dc;

                if(nr < 0 || nc < 0 || nr >= grid.Length || nc >= grid[0].Length || grid[nr][nc] == 0){
                    continue;
                }

                grid[nr][nc] = 0;

                q.Enqueue((nr, nc));
            }
        }

        return area;
    }
}