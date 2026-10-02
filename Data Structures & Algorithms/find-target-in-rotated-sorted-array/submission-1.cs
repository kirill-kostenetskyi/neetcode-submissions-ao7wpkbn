public class Solution {
    public int Search(int[] nums, int target) {
        var L = 0;
        var R = nums.Length - 1;

        while(L < R){
            var M = (R + L) / 2;
            if(nums[M] < nums[R]){
                R = M;
            } else {
                L = M + 1;
            }
        }

        var turnPoint = L;
        L = 0;
        R = nums.Length - 1;

        if(target <= nums[R]){
            L = turnPoint;
            R = R;
        } else {
            L = 0;
            R = turnPoint - 1;
        }

        while(L <= R){
            var M = (R + L) / 2;
            if(nums[M] > target){
                R = M - 1;
            } else if(nums[M] < target) {
                L = M + 1;
            } else if(nums[M] == target) {
                return M;
            }
        }

        return -1;

    }
}