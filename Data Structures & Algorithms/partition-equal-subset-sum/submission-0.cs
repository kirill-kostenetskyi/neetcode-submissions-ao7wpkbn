public class Solution {
    public bool CanPartition(int[] nums) {
        var cache = new Dictionary<(int, int), bool>();
        if(nums.Sum() % 2 != 0){
            return false;
        }
        var target = nums.Sum() / 2;
        return DFS(0, 0);

        bool DFS(int i, int c){ 
            if(c == target){
                return true;
            }
            if(i >= nums.Length){
                return false;
            }
            if(cache.ContainsKey((i, c))){
                return cache[(i, c)];
            }
            var newCarry = nums[i] + c;

            bool leftRes = false;
            if(newCarry <= target){
                leftRes = DFS(i + 1, newCarry);
            }
            
            var rightRes = DFS(i + 1, c);

            if(leftRes || rightRes){
                cache.Add((i,c), true);
                return true;
            } else {
                cache.Add((i,c), false);
                return false;
            }
        }
    }
}