public class Solution {
    public List<string> GenerateParenthesis(int n) {
        var res = new List<string>();
        DFS(n, n, "");
        return res;

        void DFS(int openLeft, int openRight, string c){
            if(openLeft == 0 && openRight == 0){
                res.Add(c);
                return;
            }
            if(openLeft > 0){
                DFS(openLeft - 1, openRight, c +"(");
            }
            if(openLeft < openRight){
                DFS(openLeft, openRight - 1, c + ")");
            }
        }
    }
}