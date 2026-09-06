public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        var bestMin = nums[0];
        var bestMax = nums[0];
        var currentMin = 0;
        var currentMax = 0;
        var totalSum = nums.Sum();
        var allNegative = nums.Length == nums.Where(x => x < 0).Count();

        for(int i = 0; i < nums.Length; i++){
            currentMax += nums[i];
            bestMax = Math.Max(currentMax, bestMax);
            if(currentMax < 0){
                currentMax = 0;
            }

            currentMin += nums[i];
            bestMin = Math.Min(currentMin, bestMin);
            if(currentMin > 0){
                currentMin = 0;
            }

        }
        if(allNegative){
            return bestMax;
        }
        var res = Math.Max(bestMax, totalSum - bestMin);
        return res;
    }
}