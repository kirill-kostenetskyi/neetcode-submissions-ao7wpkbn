public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1){
            return nums[0];
        }
        var nums1 = nums[1..];
        var nums2 = nums[..^1];
        var res1 = HouseRobberI(nums1);
        var res2 = HouseRobberI(nums2);
        return Math.Max(res1, res2);
    }

    private int HouseRobberI(int[] nums){
        for(int i = 2; i < nums.Length; i++) {
            var max = Math.Max(nums[i] + GetOrZero(i - 2), nums[i] + GetOrZero(i - 3));
            nums[i] = max;
        }
        var last = nums[nums.Length - 1];
        var beforeLast = nums.Length > 1 ? nums[nums.Length - 2] : 0;

        return Math.Max(last, beforeLast);

        int GetOrZero(int i){
            if(i < 0){
                return 0;
            } else {
                return nums[i];
            }
        }
    }

    
}