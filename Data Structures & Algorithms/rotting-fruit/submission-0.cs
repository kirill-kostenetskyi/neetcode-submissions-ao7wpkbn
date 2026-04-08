public class Solution {
    private List<(int r, int c)> dirs= new List<(int, int)>(){
        (0, 1),
        (1, 0),
        (-1, 0),
        (0, -1),
    };

    private int minMinutes = -1;

    public int OrangesRotting(int[][] grid) {
        var q = new Queue<(int r, int c, int minutes)>();
        var visited = new HashSet<(int, int)>();
        bool hasFresh = false;
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 2){
                    // rotten start point
                    q.Enqueue((i, j, -1));
                }
                if(grid[i][j] == 1){
                    hasFresh = true;
                }
            }            
        }
        if(!hasFresh){
            return 0;
        }

        while(q.Count() > 0){
            var (r, c, minutes) = q.Dequeue();

            if(visited.Contains((r,c))){
                continue;
            }

            visited.Add((r,c));
            grid[r][c] = 2;
            minutes++;

            minMinutes = Math.Max(minutes, minMinutes);

            foreach(var dir in dirs){
                var nr = r + dir.r;
                var nc = c + dir.c;

                if(nr < 0 || nc < 0 || nr >=grid.Length || nc >= grid[0].Length || grid[nr][nc] != 1){
                    continue;
                }

                q.Enqueue((nr, nc, minutes));
            }
        }

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 1){
                    return -1;
                }
            }            
        }

        return minMinutes;
    }
}