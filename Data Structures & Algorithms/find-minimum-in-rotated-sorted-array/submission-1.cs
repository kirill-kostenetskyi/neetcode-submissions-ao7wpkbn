public class Solution {
    public int FindMin(int[] nums) {
        // почитай то что написано капсом в заметке если через минуту не вспомнил суть
        var L = 0;
        var R = nums.Length - 1;
        while(L <= R){
            var M = (L + R) / 2;
            if(L == R){
                return nums[L];
            }
            if(nums[M] > nums[R]){
                L = M + 1;
            } else if (nums[M] < nums[R]){
                R = M;
            }
        }
        return -1;
    }
}