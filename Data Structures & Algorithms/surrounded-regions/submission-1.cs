public class Solution {
    public void Solve(char[][] board) {
        (int dr, int dc)[] dirs = {(0, 1), (1, 0), (0, -1), (-1, 0)};
        var q = new Queue<(int r, int c)>();
        //left and right
        for(int r = 0; r < board.Length; r++) {
            if(board[r][0] == 'O'){
                q.Enqueue((r, 0));
                board[r][0] = 'A';
            }
            if(board[r][board[0].Length - 1] == 'O'){
                q.Enqueue((r, board[0].Length - 1));
                board[r][board[0].Length - 1] = 'A';
            }
        }   
        // top and bottom
        for(int c = 0; c < board[0].Length; c++){
            if(board[0][c] == 'O'){
                q.Enqueue((0, c));
                board[0][c] = 'A';
            }
            if(board[board.Length - 1][c] == 'O'){
                q.Enqueue((board.Length - 1, c));
                board[board.Length - 1][c] = 'A';
            }
        }

        while(q.Count > 0){
            (int r, int c) = q.Dequeue();
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;
                if(nr < 0 || nr >= board.Length || nc < 0 || nc >= board[0].Length || board[nr][nc] != 'O'){
                    continue;
                }
                board[nr][nc] = 'A';
                q.Enqueue((nr, nc));
            }
        }

        for(int r = 0; r < board.Length; r++){
            for(int c = 0; c < board[0].Length; c++){
                if(board[r][c] == 'O'){
                    board[r][c] = 'X';
                }
                if(board[r][c] == 'A'){
                    board[r][c] = 'O';
                }
            }
        }
    }
}