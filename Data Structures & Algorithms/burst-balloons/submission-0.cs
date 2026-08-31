public class Solution {
    public int MaxCoins(int[] nums) {
        var cache = new int[nums.Length + 1, nums.Length + 1];
        var visited = new bool[nums.Length + 1, nums.Length + 1];
        var numsList = new List<int>();
        numsList.Add(1);
        numsList.AddRange(nums);
        numsList.Add(1);
        nums = numsList.ToArray();
        return DFS(1, numsList.Count - 2);

        // what is the best sum in the subset? 
        int DFS(int l, int r){
            if(l > r){
                return 0;
            }
            if(visited[l, r] == true){
                return cache[l, r];
            }
            var maxRes = 0;
            for(int i = l; i <= r; i++){
                // what if I remove at index i last? I will have two subsets to consider before this removal:
                var left = DFS(l, i - 1);
                var right = DFS(i + 1, r);
                var currentI = nums[l - 1] * nums[i] * nums[r + 1];
                var sum = left + right + currentI;
                maxRes = Math.Max(maxRes, sum);
            }
            cache[l, r] = maxRes;
            visited[l, r] = true;
            return maxRes;
        }
    }
}