public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dictionary = new Dictionary<int, int>();
        
        for(int i= 0; i < nums.Length; i++){
            dictionary[nums[i]] = i;
        }

        for(int i= 0; i < nums.Length; i++){
            var diff = target - nums[i]; //3
            if(dictionary.ContainsKey(diff)){
                var indexOfTargetDiff = dictionary[diff];
                // exclude current item from search
                if(indexOfTargetDiff != i) {
                    return new int[]{i, indexOfTargetDiff};
                }
            }
        }

        return new int[]{0};
    }
}