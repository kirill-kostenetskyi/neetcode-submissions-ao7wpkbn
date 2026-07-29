public class Solution {
    public int MaxProduct(int[] nums) {
        var currentMinStreak = 1;
        var currentMaxStreak = 1;
        var result = nums.Max();
        for(int i = 0; i < nums.Length; i++){
            var current = nums[i];
            if(current == 0){
                currentMinStreak = 1;
                currentMaxStreak = 1;
                continue;
            }
            var multipliedSumMin = current * currentMinStreak;
            var multipliedSumMax = current * currentMaxStreak;

            currentMinStreak = Math.Min(Math.Min(current, multipliedSumMin), multipliedSumMax);
            currentMaxStreak = Math.Max(Math.Max(current, multipliedSumMax), multipliedSumMin);
            result = Math.Max(Math.Max(currentMinStreak, currentMaxStreak), result);
        }

        return result;
    }
}