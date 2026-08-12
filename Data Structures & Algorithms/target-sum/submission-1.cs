public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        var cache = new Dictionary<(int, int), int>();
        return DFS(0, 0);
        // сколько способов сущесвует что бы ДОсобрать сумму до amount имея на руках монеты начиная с i + currentSum? 
        int DFS(int i, int currentSum){
            if(i == nums.Length && currentSum == target){
                return 1;
            }
            if(i == nums.Length && currentSum != target){
                return 0;
            }
            if(cache.ContainsKey((i, currentSum))){
                return cache[(i, currentSum)];
            }
            var left = DFS(i + 1, currentSum + nums[i]);
            var right = DFS(i + 1, currentSum - nums[i]);
            var res = left + right;
            cache.Add((i, currentSum), res);
            return res;
        }
    }
}