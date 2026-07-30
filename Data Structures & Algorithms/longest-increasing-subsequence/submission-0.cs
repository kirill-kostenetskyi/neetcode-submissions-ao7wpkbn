public class Solution {
    public int LengthOfLIS(int[] nums) {

        var dp = new int[nums.Length + 1]; // 9
        dp[dp.Length - 1] = 0; //dp[8] = 0
        dp[dp.Length - 2] = 1; //dp[7] = 1

        for(int i = dp.Length - 3; i >= 0; i--){
            dp[i] = 1;
            for(int j = i; j < nums.Length; j++){
                if(nums[i] < nums[j]){
                    dp[i] = Math.Max(dp[j] + 1, dp[i]);
                }
            }
        }

        var max = dp.Max();
        return max;
    }
}