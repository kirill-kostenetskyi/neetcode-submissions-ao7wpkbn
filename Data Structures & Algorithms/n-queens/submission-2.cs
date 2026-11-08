public class Solution {
    public List<List<string>> SolveNQueens(int n) {
        var res = new List<List<string>>();

        var hMap = new HashSet<int>();
        var vMap = new HashSet<int>();
        var d1Map = new HashSet<int>(); 
        var d2Map = new HashSet<int>(); 

        DFS(0, new HashSet<(int, int)>());

        return res;

        void DFS(int r, HashSet<(int r, int c)> QCurrent){
            if(r == n){
                res.Add(ConvertResults(QCurrent));
                return;
            }

            for(int c = 0; c < n; c++){
                if(!hMap.Contains(r) && !vMap.Contains(c) && !d1Map.Contains(r + c) && !d2Map.Contains(r - c)){
                    QCurrent.Add((r, c));
                    hMap.Add(r);
                    vMap.Add(c);
                    d1Map.Add(r + c);
                    d2Map.Add(r - c);

                    DFS(r + 1, QCurrent);

                    QCurrent.Remove((r, c));                    
                    hMap.Remove(r);
                    vMap.Remove(c);
                    d1Map.Remove(r + c);
                    d2Map.Remove(r - c);    
                }   
            }
        
        }

        List<string> ConvertResults(HashSet<(int r, int c)> Qs){
            var res = new List<string>();
            for(int r = 0; r < n; r++){
                var sb = new StringBuilder();
                for(int c = 0; c < n; c++){
                    if(Qs.Contains((r, c))){
                        sb.Append("Q");
                    } else {
                        sb.Append(".");
                    }
                }
                res.Add(sb.ToString());
            }
            return res;
        }
    }
}