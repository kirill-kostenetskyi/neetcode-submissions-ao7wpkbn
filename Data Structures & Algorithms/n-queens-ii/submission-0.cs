public class Solution {
    public int TotalNQueens(int n) {
        var vSet = new HashSet<int>();
        var d1Set = new HashSet<int>();
        var d2Set = new HashSet<int>();
        int res = 0;

        DFS(0);

        return res;

        void DFS(int r){
            if(r == n){
                res++;
                return;
            }

            for(int c = 0; c < n; c++){
                if(vSet.Contains(c) || d1Set.Contains(c + r) || d2Set.Contains(c - r)){
                    continue;
                }
                

                vSet.Add(c);
                d1Set.Add(c + r);
                d2Set.Add(c - r);

                DFS(r + 1);

                vSet.Remove(c);
                d1Set.Remove(c + r);
                d2Set.Remove(c - r);
            }
        }
    }
}