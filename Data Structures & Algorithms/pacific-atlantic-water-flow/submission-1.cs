public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int rows = heights.Length;
        int cols = heights[0].Length;
        var pacificVisited = new HashSet<(int r, int c)>();
        var atlanticVisited = new HashSet<(int r, int c)>();

        var bfsStartPacific = new List<(int r, int c)>();
        var bfsStartAtlantic = new List<(int r, int c)>();

        for (int r = 0; r < rows; r++) {
            bfsStartPacific.Add((r, 0));
            bfsStartAtlantic.Add((r, cols - 1));
        }
        for (int c = 0; c < cols; c++) {
            bfsStartPacific.Add((0, c));
            bfsStartAtlantic.Add((rows - 1, c));
        }
        
        FillCells(bfsStartPacific, pacificVisited, heights);
        FillCells(bfsStartAtlantic, atlanticVisited, heights);
        var pacificList = pacificVisited.ToArray();
        var atlanticList = atlanticVisited.ToArray();

        var result = new List<List<int>>();
        for(int r = 0; r < heights.Length; r++){
            for(int c = 0; c < heights[0].Length; c++){
                var isInPacific = pacificVisited.Contains((r, c));
                var isInAtlantic = atlanticVisited.Contains((r, c));
                if(isInPacific && isInAtlantic){
                    result.Add(new List<int>(){r, c});
                }
            }
        }
        return result;
    }

    private void FillCells(List<(int r, int c)> bfsStarts, HashSet<(int r, int c)> visited, int[][] heights){
        var q = new Queue<(int r, int c)>();
        var dirs = new List<(int r, int c)>(){
            (0, 1),
            (1, 0),
            (-1, 0),
            (0, -1),
        };
        for(int i = 0; i < bfsStarts.Count; i++){
            q.Enqueue((bfsStarts[i].r, bfsStarts[i].c));
            visited.Add((bfsStarts[i].r, bfsStarts[i].c));
        }

        while(q.Count() > 0){
            (int r, int c) = q.Dequeue();
            visited.Add((r, c));
            
            foreach(var dir in dirs){
                var nr = dir.r + r;
                var nc = dir.c + c;

                if(nr < 0 || nc < 0 || nr >= heights.Length || nc >= heights[0].Length || visited.Contains((nr, nc)) || heights[nr][nc] < heights[r][c]){
                    continue;
                }
                q.Enqueue((nr, nc));

            }

        }
    }
}