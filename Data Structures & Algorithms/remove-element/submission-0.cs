public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var L = 0;
        int R = 0;
        for(int i = nums.Length - 1; i >=0; i--){
            if(nums[i] != val){
                R = i;
                break;
            }
        }

        while (L < R){
            if(nums[L] == val){
                var tempR = nums[R];
                nums[R] = nums[L];
                nums[L] = tempR;
                L++;
                while(nums[R] == val){
                    R--;
                }
            } else {
                L++;
            }
        }

        return nums.Count(x => x != val);
    }
}