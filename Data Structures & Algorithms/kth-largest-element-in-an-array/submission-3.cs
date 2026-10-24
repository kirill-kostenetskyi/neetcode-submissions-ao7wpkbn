public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        k = nums.Length - k;
        // return Sort(0, nums.Length - 1);
        Array.Sort(nums);
        return nums[k];

        int Sort(int L, int R){            
            var pivot = nums[R];
            var p = L;
            
            var originalL = L;
            while(L < R){
                if(nums[L] <= pivot){
                    var temp = nums[p];
                    nums[p] = nums[L];
                    nums[L] = temp;
                    p++;
                }
                L++;
            }
            
            var temp2 = nums[p];
            nums[p] = nums[R];
            nums[R] = temp2;

            if(p == k){
                return nums[p];
            }
            if(p < k){
                return Sort(p + 1, R);
            } 
            if(p > k){
                return Sort(originalL, p - 1);
            }

            return nums[originalL];
        }
    }
}