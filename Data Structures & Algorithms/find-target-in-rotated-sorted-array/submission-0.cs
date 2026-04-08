public class Solution {
    public int Search(int[] nums, int target) {
        var isRotated = nums[0] > nums[^1];

        var sL = 0;
        var sR = nums.Length - 1;
        var pivot = 0;
        if(isRotated){
            var l = 0;
            var r = nums.Length - 1;

            var m = l + (r - l) / 2;
            while(nums[m] < nums[m + 1]){
                 m = l + (r - l) / 2;
                if(nums[m] > nums[l]){
                    l = m;
                } else {
                    r = m;
                }
            }

            pivot = m + 1;
            
            if(target <= nums[^1]){
                // it's between pivot annd right end
                sL = pivot;
            } else if(target > nums[^1]){
                // left range 
                sR = pivot;
            }
        }

        while (sL <= sR){
            var m = sL + (sR - sL) / 2;
            if(nums[m] > target) {
                sR = m - 1;
            } else if (nums[m] < target){
                sL = m + 1;
            } else {
                return m;
            }
        }
    
        return -1;
    }
}