public class Solution {
    public int ShortestBridge(int[][] grid) {
        // DFS to find first island
        var found = false;
        for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c < grid[0].Length; c++){
                if(grid[r][c] == 1 && found == false){
                    DFS(r, c);
                    found = true;
                }
                
            }
        }

        var queue = new Queue<(int r, int c, int distance)>();
        var visited = new HashSet<(int, int)>();

        for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c < grid[0].Length; c++){
                if(grid[r][c] == -1){
                    queue.Enqueue((r, c, 0));
                    visited.Add((r, c));
                }
            }
        }
          
        (int dr, int dc)[] dirs = {(1, 0), (0, 1), (-1, 0), (0, -1)};
        while(queue.Count > 0){
            var top = queue.Dequeue();

            foreach(var (dr, dc) in dirs){
                var nr = dr + top.r;
                var nc = dc + top.c;

                if(nr < 0 || nr >= grid.Length || nc < 0 || nc >= grid[0].Length || visited.Contains((nr,nc)) || grid[nr][nc] == -1){
                    continue;
                }
                if(grid[nr][nc] == 1){
                    return top.distance;
                }

                visited.Add((nr, nc));
                queue.Enqueue((nr, nc, top.distance + 1));
            }
        }

        return 0;

        void DFS(int r, int c){
            if(r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] != 1){
                return;
            }
            
            grid[r][c] = -1;
            DFS(r + 1, c);
            DFS(r - 1, c);
            DFS(r, c + 1);
            DFS(r, c - 1);
        }

    }
}