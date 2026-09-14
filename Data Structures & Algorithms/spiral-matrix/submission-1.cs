public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        var visitedPlaceholder = 200;
        (int dr, int dc)[] dirs = {(0, 1), (1, 0), (0, -1), (-1, 0)};
        var res = new List<int>();
        DFS(0, 0 , false);
        return res;

        void DFS(int r, int c, bool up){
            res.Add(matrix[r][c]);
            matrix[r][c] = visitedPlaceholder;
            if(up){
                var nr = r - 1;
                var nc = c;
                if(nr >= matrix.Length || nr < 0 || nc >= matrix[0].Length || nc < 0 || matrix[nr][nc] == visitedPlaceholder){
                    // do nothing and go by default path below
                } else {
                    DFS(nr, nc, true);
                    return;
                }
            }
            
            foreach((int dr, int dc) in dirs){
                var nr = r + dr;
                var nc = c + dc;
                if(nr >= matrix.Length || nr < 0 || nc >= matrix[0].Length || nc < 0 || matrix[nr][nc] == visitedPlaceholder){
                    continue;
                }
                if(dr == -1 && dc == 0){
                    DFS(nr, nc, true);
                } else {
                    DFS(nr, nc, false);
                }
            }
        }
    }
}