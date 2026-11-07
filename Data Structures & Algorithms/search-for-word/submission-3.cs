public class Solution {
    public bool Exist(char[][] board, string word) {
        var fm = new Dictionary<char, int>();
        for(int r = 0; r < board.Length; r++){
            for(int c = 0; c < board[0].Length; c++){
                if(fm.TryGetValue(board[r][c], out var count)){
                    fm[board[r][c]] = count + 1;
                } else {
                    fm[board[r][c]] = 1;
                }
            }
        }
        foreach(var c in word){
            if(fm.TryGetValue(c, out var count)){
                if(count <= 0){
                    return false;
                }
            } else {
                return false;
            }
        }

        for(int r = 0; r < board.Length; r++){
            for(int c = 0; c < board[0].Length; c++){
                if(board[r][c] == word[0]){
                    if(DFS(r, c, 0, new HashSet<(int, int)>())){
                        return true;
                    }
                }
            }
        }
        return false;

        bool DFS(int r, int c, int i, HashSet<(int, int)> visited){
            if(visited.Contains((r, c))){
                return false;
            }

            if(word[i] != board[r][c]){
                return false;
            }

            if(i == word.Length - 1){
                return true;
            }

            visited.Add((r, c));

            (int dr, int dc)[] dirs = {(-1, 0), (0, -1), (1, 0), (0, 1)};
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;
                if(nr >= 0 && nr < board.Length && nc >= 0 && nc < board[0].Length){
                    var res = DFS(nr, nc, i + 1, visited);
                    if(res){
                        return true;
                    }
                }
            }

            visited.Remove((r, c));

            return false;
        }
    }
}