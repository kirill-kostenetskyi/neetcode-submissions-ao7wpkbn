public class Solution {
    HashSet<int> horizontal = new HashSet<int>();
    HashSet<int> vertical = new HashSet<int>();
    HashSet<int> diag1 = new HashSet<int>();
    HashSet<int> diag2 = new HashSet<int>();

    List<List<string>> results = new List<List<string>>();
    int boardSize = 0;
    public List<List<string>> SolveNQueens(int n) {
        boardSize = n;
        Logic(new List<string>(), 0, 0);
        return results;
    }

    private void Logic(List<string> currentStack, int col, int row){
        if(row == boardSize){
            results.Add(currentStack);
            return;
        }

        // interate current row
        for(int i_col = 0; i_col < boardSize; i_col++){
            if(!IsValidPosition(i_col, row)){
                continue;
            }
            var str = GetStrBaseOnX(i_col);
            currentStack.Add(str);
            SetOccupated(i_col, row, true);
            row = row + 1;
            
            Logic(currentStack.ToList(), i_col, row);         
           
            row = row - 1;
            currentStack.RemoveAt(currentStack.Count() - 1);
            SetOccupated(i_col, row, false);
        }
    }

    private string GetStrBaseOnX(int x){
        string result = "";
        for(int i = 0; i < boardSize; i++){
            if(i == x){
                result = result + "Q";
            } else {
                result = result + ".";
            }
        }
        return result;
    }

    private bool IsValidPosition(int col, int row){
        if(horizontal.Contains(row) || vertical.Contains(col) || diag1.Contains(col + row) || diag2.Contains(col - row)){
            return false;
        } 
        return true;
    }

    private void SetOccupated(int col, int row, bool setTrue){
        if(setTrue){
            horizontal.Add(row);
            vertical.Add(col);
            diag1.Add(col + row);
            diag2.Add(col - row);
        } else {
            horizontal.Remove(row);
            vertical.Remove(col);
            diag1.Remove(col + row);
            diag2.Remove(col - row);
        }
    }
}