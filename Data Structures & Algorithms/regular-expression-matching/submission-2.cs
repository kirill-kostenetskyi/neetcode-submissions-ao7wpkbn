public class Solution {
    public bool IsMatch(string s, string p) {
        var cache = new Dictionary<(int, int), bool>();
        return DFS(0, 0);

        bool DFS(int i, int j){
            if(i >= s.Length && j >= p.Length){
                return true;
            }
            if(j >= p.Length && i < s.Length){
                return false;
            }
            if(cache.TryGetValue((i, j), out bool cachedRes)){
                return cachedRes;
            }
            var isNextStar = j < p.Length - 1 && p[j + 1] == '*';
            var res = false;
            if(isNextStar){
                var res1 = false;
                if(i < s.Length && (s[i] == p[j] || p[j] == '.')){
                    res1 = DFS(i + 1, j);
                }
                var res2 = DFS(i, j + 2);
                res = res1 || res2;
            } else {
                if(i < s.Length && (s[i] == p[j] || p[j] == '.')){
                    res = DFS(i + 1, j + 1);
                    return res;
                }
            }
            cache[(i, j)] = res;
            return res;
        }
    }
}