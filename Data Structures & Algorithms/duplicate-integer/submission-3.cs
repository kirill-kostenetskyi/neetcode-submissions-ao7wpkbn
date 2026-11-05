public class Solution {
    public bool hasDuplicate(int[] nums) {
       var hashSet  = new HashSet<int>();
        for(int i = 0; i< nums.Length; i++){
            hashSet.Add(nums[i]);
        }
        if(hashSet.Count != nums.Length){
            return true;
        }
        return false;  
    }
}