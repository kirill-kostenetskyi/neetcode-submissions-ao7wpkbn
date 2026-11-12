public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        (int dr, int dc)[] dirs = {(0, 1), (1, 0), (0, -1), (-1, 0)};
        var q = new Queue<(int r, int c)>();
        // atlantic
        int[][] atlanticGrid = new int[heights.Length][];
        for (int r = 0; r < heights.Length; r++) {
            atlanticGrid[r] = new int[heights[0].Length];
        }   
        for(int r = 0; r < heights.Length; r++){
            q.Enqueue((r, heights[0].Length - 1));
            atlanticGrid[r][heights[0].Length - 1] = 1;
        }
        for(int c = 0; c < heights[0].Length; c++){
            q.Enqueue((heights.Length - 1, c));
            atlanticGrid[heights.Length - 1][c] = 1;
        }

        while(q.Count > 0){
            (int r, int c) = q.Dequeue();
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;
                if(nr < 0 || nr >= heights.Length || nc < 0 || nc >= heights[0].Length || atlanticGrid[nr][nc] == 1 || heights[nr][nc] < heights[r][c]){
                    continue;
                }
                atlanticGrid[nr][nc] = 1;
                q.Enqueue((nr, nc));
            }
        }

        //pacific
        int[][] pacificGrid = new int[heights.Length][]; 
        for (int r = 0; r < heights.Length; r++) {
            pacificGrid[r] = new int[heights[0].Length];
        }   
        for(int r = 0; r < heights.Length; r++){
            q.Enqueue((r, 0));
            pacificGrid[r][0] = 1;
        }
        for(int c = 0; c < heights[0].Length; c++){
            q.Enqueue((0, c));
            pacificGrid[0][c] = 1;
        }
        while(q.Count > 0){
            (int r, int c) = q.Dequeue();
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;
                if(nr < 0 || nr >= heights.Length || nc < 0 || nc >= heights[0].Length || pacificGrid[nr][nc] == 1 || heights[nr][nc] < heights[r][c]){
                    continue;
                }
                pacificGrid[nr][nc] = 1;
                q.Enqueue((nr, nc));
            }
        }
        List<List<int>> res = new List<List<int>>();
        for(int r = 0; r < pacificGrid.Length; r++){
            for(int c = 0; c < pacificGrid[0].Length; c++){
                if(pacificGrid[r][c] == 1 && pacificGrid[r][c] == atlanticGrid[r][c]){
                    res.Add(new List<int>(){r, c});
                }
            }
        }
        return res;
    }
}