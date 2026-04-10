public class Solution {
    public void Solve(char[][] board) {
        int rows = board.Length;
        int cols = board[0].Length;
        var q = new Queue<(int r, int c)>();
        var dirs = new List<(int r, int c)>(){
            (0, 1),
            (1, 0),
            (-1, 0),
            (0, -1),
        };
        var visited = new HashSet<(int r, int c)>();

        var needToBeAvoided = new HashSet<(int r, int c)>();

        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(board[r][c] == 'O'&& (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)){
                    q.Enqueue((r, c));  
                    visited.Add((r, c));
                }
            }
        }

        while(q.Count > 0){
            (int r, int c) = q.Dequeue();
            needToBeAvoided.Add((r,c));
            
            foreach(var dir in dirs){
                var nr = dir.r + r;
                var nc = dir.c + c;

                if(nr < 0 || nc < 0 || nr >= board.Length || nc >= board[0].Length || visited.Contains((nr, nc)) || board[nr][nc] == 'X'){
                    continue;
                } 
                visited.Add((r, c));
                q.Enqueue((nr, nc));
            }
        }
        
        
        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(board[r][c] == 'O' && !needToBeAvoided.Contains((r, c))){
                    board[r][c] = 'X';
                }
            }
        }
    }
}