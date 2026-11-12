public class Solution {
    public int NumIslands(char[][] grid) {
        (int dr, int dc)[] dirs = {(0, 1), (1, 0), (0, -1), (-1, 0)};
        int res = 0;
        for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c < grid[0].Length; c++){
                if(grid[r][c] == '1'){
                    DFS(r, c);
                    res++;
                }
            }
        }
        return res; 

        void DFS(int r, int c){
            grid[r][c] = '0';
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;
                if(nr < 0 || nr >= grid.Length || nc < 0 || nc >= grid[0].Length || grid[nr][nc] == '0'){
                    continue;
                }
                DFS(nr, nc);
            }
        }
    }
}