public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        int[][] dp = new int[matrix.Length][];

        for(int r = 0; r < matrix.Length; r++){
            var size = matrix[0].Length;
            dp[r] = new int[size];
        }

        for(int r = 0; r < matrix.Length; r++){
            for(int c = 0; c < matrix[0].Length; c++){
                var res = DFS(r, c);
            }
        }
        return dp.SelectMany(x=> x).Max();

        //return longest increasing count
        int DFS(int r, int c){
            if(dp[r][c] != 0){
                return dp[r][c];
            }
            (int nr, int nc)[] dirs = {(1, 0), (-1, 0), (0, 1), (0, -1)};
            var best = 0;
            foreach((int nr, int nc) in dirs){
                var dr = nr + r;
                var dc = nc + c;

                if(dr < 0 || dr >= matrix.Length || dc < 0 || dc >= matrix[0].Length
                || matrix[dr][dc] <= matrix[r][c])
                {
                    continue;
                }
                var res = DFS(dr, dc);
                best = Math.Max(best, res);
            }
            best = best + 1;
            dp[r][c] = best;
            return best;
        }
    }
}