public class Solution {
    public int NumIslands(char[][] grid) {
        var islandCnt = 0;
        for(int r = 0; r < grid.Length; r++){
            for(int c = 0; c <grid[0].Length; c++){
                if(grid[r][c] == '1'){
                    var anyMarked = markAsWater(r, c, grid);
                    if(anyMarked){
                        islandCnt++;
                    }
                }
            }
        }
        return islandCnt;
    }

    private bool markAsWater(int r, int c, char[][] grid) {
        int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];

        var q = new Queue<(int r, int c)>();
        q.Enqueue((r, c));
        bool atLeastOneIsland = false;
        while(q.Count() > 0){
            (int rc, int cc) = q.Dequeue();
            if(grid[rc][cc] == '1'){
                atLeastOneIsland = true;
                grid[rc][cc] = '0';
            } else {
                continue;
            }
            
            foreach(var dir in dirs){
                var rShift = dir[0];
                var cShift = dir[1];

                var newR = rc + rShift;
                var newC = cc + cShift;

                if(newR >= 0 && newC >=0 && newR < grid.Length && newC < grid[0].Length){
                    q.Enqueue((newR, newC));
                }
            }
        }

        return atLeastOneIsland;
    }
}