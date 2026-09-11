public class Solution {
    public int[] CountBits(int n) {
        // first approach

        // var dp = new int[n + 1];
        // dp[0] = 0;
        // var offset = 1;
        // for(int i = 1; i <=n; i++){  
        //     if(i == offset * 2){
        //         offset = offset * 2;
        //     }
        //     dp[i] = 1 + dp[i - offset];
        // }
        // return dp;

        //second approach
        var dp = new int[n + 1];
        for(int i = 0; i <= n; i++){
            var lastBit = i & 1;
            dp[i] = dp[i >>> 1] + lastBit;
        }
        return dp;
    }
}