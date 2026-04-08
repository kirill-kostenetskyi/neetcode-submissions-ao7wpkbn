public class Solution {
    public int LongestConsecutive(int[] nums) {
        var hashSet = new HashSet<int>(nums);
        var longest = 0;

        for(int i = 0; i < nums.Length; i++){
           if(!hashSet.Contains(nums[i] - 1)){
                var l = 1;
                var start = nums[i];
                while(hashSet.Contains(start + 1)){
                    start++;
                    l++;
                }
                if(l > longest){
                    longest = l;
                }
           }
        }
        return longest;
    }
}
