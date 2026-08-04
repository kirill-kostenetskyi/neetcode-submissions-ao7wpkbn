public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        if(obstacleGrid[^1][^1] == 1){
            return 0;
        }
        var rows = obstacleGrid.Length;
        var cols = obstacleGrid[0].Length;

        for(int r = rows - 1; r >=0; r--){
            for(int c = cols - 1; c >= 0; c--){
                if(r == rows - 1 && c == cols - 1){
                    obstacleGrid[r][c] = 1;
                    continue;
                }
                if(obstacleGrid[r][c] == 1){
                    obstacleGrid[r][c] = 0;
                    continue;
                }

                var down = r + 1 > rows - 1? 0 : obstacleGrid[r + 1][c];
                var right = c + 1 > cols - 1? 0 : obstacleGrid[r][c + 1];
                obstacleGrid[r][c] = down + right;
                
            }
        }

        return obstacleGrid[0][0];
    }
}