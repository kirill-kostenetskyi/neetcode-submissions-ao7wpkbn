public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dict = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++){
            var diff = target - nums[i];

            if(dict.ContainsKey(diff)){
                return new int[2]{dict[diff] , i};
            } else {
                if(!dict.ContainsKey(nums[i])){
                    dict.Add(nums[i], i);
                }
            }
        }

        return new int[2];
    }
}
