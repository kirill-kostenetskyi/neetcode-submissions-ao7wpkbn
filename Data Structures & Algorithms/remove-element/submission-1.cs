public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var p = 0;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] != val){
                nums[p] = nums[i];
                p++;
            }
        }

        return p;
    }
}