public class Solution {
    private string word;
    private char[][] board;
    private int rows;
    private int cols;
    private HashSet<(int, int)> hashSet = new HashSet<(int, int)>();
    public bool Exist(char[][] board, string word) {
        this.word = word;
        this.rows = board.Length;
        this.cols = board[0].Length;
        this.board = board;
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                var res = dfs(i, j, 0);
                if (res){
                    return true;
                }
            }
        }
        return false;
    }


    private bool dfs(int r, int c, int letterN){
        if(r < 0 || c < 0 || r > rows - 1 || c > cols - 1){
            return false;
        }
        
        if(board[r][c] != word[letterN]){
            return false;
        }

        if(hashSet.Contains((r,c))){
            return false;
        }

        if(letterN == word.Length - 1){
            return true;
        }

        hashSet.Add((r,c));
        letterN++;
        var anyContains = (
            // left
            dfs(r, c - 1, letterN) ||
            // top
            dfs(r - 1, c, letterN) ||
            // right
            dfs(r, c + 1, letterN) ||
            // bottom
            dfs(r + 1, c, letterN)
        );
        hashSet.Remove((r,c));
        return anyContains;
    }

}