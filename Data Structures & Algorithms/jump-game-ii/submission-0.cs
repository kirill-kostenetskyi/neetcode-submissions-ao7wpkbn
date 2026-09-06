public class Solution {
    public int Jump(int[] nums) {
        var l = 0;
        var r = 0;
        var counter = 0;
        while(r < nums.Length - 1){
            var furthest = nums[l] + l;
            for(int i = l; i <= r; i++){
                if(i >= nums.Length){
                    break;
                }
                furthest = Math.Max(furthest, nums[i] + i);
            }
            l = r + 1;
            r = furthest;
            counter++;
        }

        return counter;
    }
}