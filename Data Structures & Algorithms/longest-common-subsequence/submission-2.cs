public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        // var cache = new Dictionary<(int, int), int>();
        // return DFS(0, 0);

        // int DFS(int i1, int i2){
        //     if(i1 > text1.Length - 1){
        //         return 0;
        //     }
        //     if(i2 > text2.Length - 1){
        //         return 0;
        //     }
        //     if(cache.TryGetValue((i1, i2), out var getRes)){
        //         return getRes;
        //     }

        //     int res = 0;
        //     if(text1[i1] == text2[i2]){
        //         res = 1 + DFS(i1 + 1 , i2 + 1);
        //     } else {
        //         var res1 = DFS(i1 + 1, i2);
        //         var res2 = DFS(i1, i2 + 1);
        //         res = Math.Max(res1, res2);
        //     }
        //     cache[(i1, i2)] = res;
        //     return res;
        // }

        var dp = new int[text1.Length + 1, text2.Length + 1];
        
        for(int i1 = text1.Length - 1; i1 >= 0; i1--){
            for(int i2 = text2.Length - 1; i2 >= 0; i2--){
                int res = 0;
                if(text1[i1] == text2[i2]){
                    res = 1 + dp[i1 + 1 , i2 + 1];
                } else {
                    var res1 = dp[i1 + 1, i2];
                    var res2 = dp[i1, i2 + 1];
                    res = Math.Max(res1, res2);
                }
                dp[i1, i2] = res;
            }        
        }
        return dp[0,0];
    }
}