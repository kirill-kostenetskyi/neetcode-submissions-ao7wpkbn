public class Solution {
    public int SingleNumber(int[] nums) {
        var res = 0;
        for(int i = 0; i < nums.Length; i++){
            res = res ^ nums[i];
        }
        return res;
    }
}