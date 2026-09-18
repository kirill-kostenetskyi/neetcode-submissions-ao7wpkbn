public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dict = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            dict[nums[i]] = i;
        }

        for(int i = 0; i < nums.Length; i++){
            var n = nums[i];
            if(dict.ContainsKey(target - n) && dict[target - n] != i){
                return new int[2]{ i, dict[target - n] };
            }
        }
        return new int[2]{0, 0};
    }
}