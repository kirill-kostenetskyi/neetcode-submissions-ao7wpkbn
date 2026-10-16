public class Solution {
    public int FindDuplicate(int[] nums) {
        var slow = 0;
        var fast = 0;

        do{
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while(slow != fast);

        var p1 = slow;
        var p2 = 0;

        while(p1 != p2){
            p1 = nums[p1];
            p2 = nums[p2];
        }

        return p1;
    }
}