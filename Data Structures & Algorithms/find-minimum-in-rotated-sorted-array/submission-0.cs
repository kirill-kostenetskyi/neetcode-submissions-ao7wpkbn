public class Solution {
    public int FindMin(int[] nums) {
        var isRotated = nums[0] > nums[^1];

        var l = 0;
        var r = nums.Length - 1;
        if(isRotated){
            var m = l + (r - l) / 2;
            while(nums[m] < nums[m + 1]){
                m = l + (r - l) / 2;
                if(nums[m] > nums[l]){
                    l = m;
                } else {
                    r = m;
                }
            }
            return nums[m+1];
            
        } else {
            return nums[0];
        }
        
    } 
}
