public class Solution {
    public int FindDuplicate(int[] nums) {
        // Floyd algorithm
        var slow = nums[0];
        var fast = nums[0];

        do {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        var p1 = nums[0];
        var p2 = slow;

        while(p1 != p2){
            p1 = nums[p1];
            p2 = nums[p2];
        }

        return p1;
    }
}