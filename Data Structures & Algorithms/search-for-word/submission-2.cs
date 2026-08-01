public class Solution {
    public bool Exist(char[][] board, string word) {
        var visited = new HashSet<(int, int)>();
        for(int r = 0; r < board.Length; r++){
            for(int c = 0; c < board[0].Length; c++){
                if(word[0] == board[r][c]){
                    var res = DFS(r, c, 0);
                    if(res){
                        return true;
                    }
                }
            }
        }

        return false;

        bool DFS(int r, int c, int i){
            if(
                c < 0 ||
                r < 0 || 
                r > board.Length - 1 ||
                c > board[0].Length - 1|| 
                visited.Contains((r, c))
            ){
                return false;
            }
            if(i == word.Length - 1 && board[r][c] == word[word.Length - 1]){
                return true;
            }

            if(board[r][c] == word[i])
            {
                visited.Add((r, c));
                var res1 = DFS(r + 1, c, i + 1);
                var res2 = DFS(r, c + 1, i + 1);
                var res3 = DFS(r - 1, c, i + 1);
                var res4 = DFS(r, c - 1, i + 1);

                visited.Remove((r, c));
                
                if(res1 || res2 || res3 || res4){
                    return true;
                }
            }


            return false;
        }
    }
}