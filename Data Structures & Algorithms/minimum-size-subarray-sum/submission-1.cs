public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        var minLen = int.MaxValue;
        var L = 0;
        var currentSum = 0;
        
        for(int R = 0; R < nums.Length; R ++){
            currentSum += nums[R];

            while(currentSum >= target){
                var currentLen = R - L + 1;
                minLen = Math.Min(minLen, currentLen);
                currentSum -= nums[L];
                L++;
            }
        }
        if(minLen == int.MaxValue){
            return 0;
        } else {
            return minLen;
        }
    }
}