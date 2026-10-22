public class Solution {
    public int MajorityElement(int[] nums) {
        var res = 0;
        var count = 0;
        for(int i = 0; i < nums.Length; i++){
            if(count == 0){
                res = nums[i];
            }
            if(res == nums[i]){
                count++;
            } else {
                count--;
            }
        }
        return res;
    }
}