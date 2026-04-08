public class Solution {
    public int LongestConsecutive(int[] nums) {
        var hashSet = new HashSet<int>(nums);
        var longest = 0;

        foreach(var num in hashSet){
           if(!hashSet.Contains(num - 1)){
                //sequence start
                var l = 1;
                var start = num;
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
