public class Solution {
    public int[] GetConcatenation(int[] nums) {
        int[] ans = new int[nums.Length * 2];
        for (int i = 0; i < ans.Length; i++){
            if (i < nums.Length){
                ans[i] = nums[i];
            } else {
                ans[i] = nums[i - nums.Length];
            }
        }
        return ans;
   }
}