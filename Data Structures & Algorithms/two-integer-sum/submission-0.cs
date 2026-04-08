public class Solution {
    public int[] TwoSum(int[] nums, int target) {
 // nums = [2, 7, 11, 15], target = 9
        var hashSet = new HashSet<int>();

        var result = new int[2];
        var firstTrigger = true;
        for(int i = 0; i < nums.Length; i ++){
            var prop = target - nums[i]; // 3 = 6 - 3

            hashSet = new HashSet<int>();
            for(int j = 0; j < nums.Length; j ++){
                if(j != i){
                    // avoid adding the current element
                    hashSet.Add(nums[j]);
                }
            }
            
            if(hashSet.Contains(prop)){
                if(firstTrigger){
                    result[0] = i; 
                    firstTrigger = false;
                }
                 else {
                    result[1] = i;
                }
            }
        }
        return result;
    }
}
