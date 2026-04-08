public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        var minLen = int.MaxValue;
        var R = 0;
        var L = 0;
        var currentSum = nums[0];
        
        while(R <= nums.Length - 1){
            if(currentSum >= target){
                while(currentSum >= target && L <= R){ // 10 >= 7
                    var curLen = R - L + 1; // 4 - 0 = 4
                    minLen = Math.Min(curLen, minLen); // 4
                    currentSum = currentSum - nums[L]; // 7
                    L++; // 2
                }
            } else {
                if(R < nums.Length - 1){
                    R++;
                    currentSum = currentSum + nums[R];
                } else {
                    break;
                }
            }
        }

        if(minLen == int.MaxValue){
            return 0;
        } else {
            return minLen;
        }
    }
}