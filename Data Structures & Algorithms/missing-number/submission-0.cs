public class Solution {
    public int MissingNumber(int[] nums) {
        var res = 0;
        for(int i = 0; i < nums.Length; i++){
            res = res ^ nums[i];
        }        
        for(int i = 0; i <= nums.Length; i++){
            res = res ^ i;
        }
        // x ^ x = 0
        // 4 ^ 4 = 0
        // 1 ^ 0 = 1
        return res;
    }
}