public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        var cache = new Dictionary<(int, int), bool>();
        if(s1.Length + s2.Length != s3.Length){
            return false;
        }
        return DFS(0, 0);

        bool DFS(int i1, int i2){
            if(i1 + i2 == s1.Length + s2.Length){
                return true;
            }
            if(cache.TryGetValue((i1, i2), out bool resVal)){
                return resVal;
            }
            
            var res1 = false;
            var res2 = false;

            if(i1 < s1.Length && s1[i1] == s3[i1 + i2]){
                res1 = DFS(i1 + 1, i2);
            }
            if(i2 < s2.Length && s2[i2] == s3[i1 + i2]){
                res2 = DFS(i1, i2 + 1);
            }
            
            var res = res1 || res2;

            cache.Add((i1, i2), res);
            return res;
        }
    }
}