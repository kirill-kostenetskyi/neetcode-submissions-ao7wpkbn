public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int globalCounter = 0;
        (int dr, int dc)[] dirs = {(-1, 0), (0, -1), (1, 0), (0, 1)};
        for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c < grid[0].Length; c++){
                if(grid[r][c] == 1){
                    DFS(r, c, new HashSet<(int, int)>());
                    return globalCounter;
                }
            }            
        }
        return 0;

        void DFS(int r, int c, HashSet<(int, int)> visited){
            var myWaterAround = 0;
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;

                if(nr < 0 || nc < 0 || nr >= grid.Length || nc >= grid[0].Length || grid[nr][nc] == 0){
                    myWaterAround++;
                }
            }
            visited.Add((r, c));
            globalCounter += myWaterAround;
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;

                if(nr >= 0 && nc >= 0 && nr < grid.Length && nc < grid[0].Length && grid[nr][nc] == 1 && !visited.Contains((nr, nc))){
                    DFS(nr, nc, visited);
                }
            }
        }
    }
}