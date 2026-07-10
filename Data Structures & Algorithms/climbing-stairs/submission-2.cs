public class Solution {
    public int ClimbStairs(int n) {
        var dp = new int[2]{ 1, 1 };
        var i = 1;
        while(i != n){
            var temp = dp[1];
            dp[1] = dp[1] + dp[0];
            dp[0] = temp;
            i++;
        }
        return dp[1];
    }
}