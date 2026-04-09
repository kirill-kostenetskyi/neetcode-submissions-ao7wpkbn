public class Solution {
    public void SortColors(int[] nums) {
        
        var L = 0;
        var R = nums.Length - 1;
        var i = 0;

        while(i <= R){
            if(nums[i] == 2){
                Swap(i, R, nums);

                if(nums[R] == 2) {
                    i--;
                }

                R--;
            } else if(nums[i] == 0){
                Swap(i, L, nums);
                L++;
            }

            i++;
        }
    }

    private void Swap(int i, int j, int[] nums){
        var tempI = nums[i];
        nums[i] = nums[j];
        nums[j] = tempI;

    }
}