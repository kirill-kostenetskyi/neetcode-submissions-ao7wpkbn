public class Solution {
    public int UniquePaths(int m, int n) {
        var cache = new Dictionary<(int, int), int>();
        var rows = m;
        var cols = n;
        return DFS(0, 0);

        int DFS(int m, int n){
            if(m > rows || n > cols){
                return 0;
            }
            if(cache.ContainsKey((m, n))){
                return cache[(m, n)];
            }
            
            if(m == rows - 1 && n == cols - 1){
                return 1;
            }

            var rightCount = DFS(m, n + 1);
            var bottomCount = DFS(m + 1, n);

            var res = rightCount + bottomCount;
            cache.Add((m, n), res);
            return res;
        }
    }

}