public class Solution {
    public int MaxSubArray(int[] nums) {
        var maxRes = nums[0];
        var currentSum = 0;
        for(int i = 0; i < nums.Length; i++){
            currentSum += nums[i];
            maxRes = Math.Max(maxRes, currentSum);
            if(currentSum < 0){
                currentSum = 0;
            }
        }        
        return maxRes;
    }
}