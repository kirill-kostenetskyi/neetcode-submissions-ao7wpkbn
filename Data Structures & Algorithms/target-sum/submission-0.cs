public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        var cache = new Dictionary<(int, int), int>();
        return DFS(0, 0);

        int DFS(int i, int currentSum){
            if(i == nums.Length && currentSum == target){
                return 1;
            }
            if(i == nums.Length && currentSum != target){
                return int.MaxValue;
            }
            if(cache.ContainsKey((i, currentSum))){
                return cache[(i, currentSum)];
            }
            var left = DFS(i + 1, currentSum + nums[i]);
            var right = DFS(i + 1, currentSum - nums[i]);
            if(left == int.MaxValue){
                left = 0;
            }
            if(right == int.MaxValue){
                right = 0;
            }
            var res = left + right;
            cache.Add((i, currentSum), res);
            return res;
        }
    }
}