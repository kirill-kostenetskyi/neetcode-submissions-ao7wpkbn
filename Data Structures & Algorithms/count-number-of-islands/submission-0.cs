public class Solution {

    private int[][] dirs =[
        [1, 0], [0, 1], [-1, 0], [0, -1]
    ];

    public int NumIslands(char[][] grid) {
        int count = 0;
        for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c < grid[0].Length; c++){
                var res = MarkIsland(r, c, grid);
                if(res){
                    count++;
                }
            } 
        }
        return count;
    }

    private bool MarkIsland(int startR, int startC, char[][] grid){
        var q = new Queue<(int r, int c)>();
        q.Enqueue((startR, startC));

        bool anyIsland = false;
        while(q.Count() > 0) {
            var (r, c) = q.Dequeue();
            
            if(grid[r][c] == '1'){
                anyIsland = true;
                grid[r][c] = '0';
            } else {
                continue;
            }

            foreach(var dir in dirs){
                var dr = dir[0];
                var dc = dir[1];

                var nr = r + dr;
                var nc = c + dc;
                if(Math.Min(nr, nc) < 0 || nr >= grid.Length || nc >= grid[0].Length || grid[nr][nc] == '0'){
                    continue;
                }

                q.Enqueue((nr, nc));
            }

        }

        return anyIsland;
    }
}