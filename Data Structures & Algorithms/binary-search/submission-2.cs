public class Solution {
    public int Search(int[] nums, int target) {
        var L = 0;
        var R = nums.Length - 1;

        while(L <= R) {
            int middle = (L + R) / 2;

            if(nums[middle] > target){
                // shift left 
                R = middle - 1;
            } else if (nums[middle] < target){
                // shift right
                L = middle + 1;
            }
            else {
                // found
                return middle;
            }
        }

        return -1;
    }
}
