public class Solution {
    public int NumDistinct(string s, string t) {
        // var cache = new Dictionary<(int, int), int>();
        // return DFS(0, 0);

        // // returns the number of distinct subsequences of s starting from i1 which equals t starting from i2. 
        // int DFS(int i1, int i2){
        //     if(i2 == t.Length){
        //         return 1;
        //     }
        //     if(i1 == s.Length){
        //         return 0;
        //     }

        //     if(cache.TryGetValue((i1, i2), out var res)){
        //         return res;
        //     }
        //     var result = 0;
        //     if(s[i1] == t[i2]){
        //         var result1 = DFS(i1 + 1, i2 + 1);
        //         result = result + result1;
        //     }
        //     var result2 = DFS(i1 + 1, i2);
        //     result = result + result2;
        //     cache[(i1, i2)] = result;
        //     return result;
        // }

        var dp = new int[s.Length + 1][];

        for(int r = 0; r < dp.Length; r++){
            var col = new int[t.Length + 1];
            col[^1] = 1;
            dp[r] = col;
        }

        for(int i1 = s.Length - 1; i1 >= 0; i1--){
            for(int i2 = t.Length - 1; i2 >= 0; i2--){
                var result = 0;
                if(s[i1] == t[i2]){
                    var result1 = dp[i1 + 1][i2 + 1];
                    result = result + result1;
                }
                var result2 = dp[i1 + 1][i2];
                result = result + result2;
                dp[i1][i2] = result;
            }
        }
        return dp[0][0];
    }
}