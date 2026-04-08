public class Solution {
    private List<string> res = new List<string>();
    public List<string> GenerateParenthesis(int n) {
        Backtrack(0, 0, n, "");
        return res;
    }

    private void Backtrack(int openN, int closeN, int n, string current){
        if(openN == closeN && openN == n){
            res.Add(current);
            return;
        }
        if(openN < n) {
            Backtrack(openN + 1, closeN, n, current + "(");
        }
        if(closeN < openN){
            Backtrack(openN, closeN + 1, n, current + ")");
        }
    }
}