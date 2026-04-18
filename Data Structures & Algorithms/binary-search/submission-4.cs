public class Solution {
    public int Search(int[] nums, int target) {
        var L = 0;
        var R = nums.Length - 1;
        var i = nums.Length / 2;

        while(L <= R){
            if(nums[i] > target){
                R = i - 1;
            } else if (nums[i] < target){
                L = i + 1;
            } else {
                return i;
            }
            i = (R - L) / 2 + L;
        }
        return -1;
    }
}