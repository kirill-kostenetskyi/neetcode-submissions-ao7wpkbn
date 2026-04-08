public class Solution {
    public int LongestConsecutive(int[] nums) {
        var hashSet = new HashSet<int>(nums);
        var sequences = new List<int>();
        for(int i = 0; i < nums.Length; i++){
           if(!hashSet.Contains(nums[i] - 1)){
                sequences.Add(nums[i]);
           }
        }

        var longest = 0;

        for (int s = 0; s < sequences.Count(); s++){
            var l = 1;
            var start = sequences[s];
            while(hashSet.Contains(start + 1)){
                start++;
                l++;
            }
            if(l > longest){
                longest = l;
            }
        }
        return longest;
    }
}
