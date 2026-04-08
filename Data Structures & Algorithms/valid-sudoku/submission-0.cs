public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var column = new Dictionary<int, HashSet<char>>();
        var row = new Dictionary<int, HashSet<char>>();
        var square = new Dictionary<string, HashSet<char>>();

        for(int i = 0; i < 9; i++){
            for(int j = 0; j < 9; j++){
               
                if(board[i][j] == '.'){
                    continue;
                }

                var squareA = i / 3;
                var squareB = j / 3;
                var key = $"{squareA},{squareB}";
                
                if(!square.ContainsKey(key)){
                   square[key] = new HashSet<char>(); 
                } 
                
                var hashSet = square[key];
                if(hashSet.Contains(board[i][j])){
                    return false;
                } else {
                    hashSet.Add(board[i][j]);
                }

                if(!row.ContainsKey(i)){
                   row[i] = new HashSet<char>(); 
                }

                hashSet = row[i];
                if(hashSet.Contains(board[i][j])){
                    return false;
                } else {
                    hashSet.Add(board[i][j]);
                }

                if(!column.ContainsKey(j)){
                   column[j] = new HashSet<char>();    
                }

                hashSet = column[j];
                if(hashSet.Contains(board[i][j])){
                    return false;
                } else {
                    hashSet.Add(board[i][j]);
                }
            }
        }
        return true;
    }
}
