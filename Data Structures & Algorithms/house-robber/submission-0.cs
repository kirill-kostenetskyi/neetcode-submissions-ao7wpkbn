public class Solution {
    public int Rob(int[] nums) {
        for(int i = nums.Length - 1; i >= 0; i--){
            var maxMoney = Math.Max(nums[i] + GetVal(i + 2), nums[i] + GetVal(i + 3));
            nums[i] = maxMoney;
        }

        return Math.Max(GetVal(0), GetVal(1));

        int GetVal(int i){
            if(i >= nums.Length){
                return 0;
            } else {
                return nums[i];
            }
        }
    }
}