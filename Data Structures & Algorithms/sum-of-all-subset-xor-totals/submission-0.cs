public class Solution {
    public int SubsetXORSum(int[] nums) {
        var res = 0;
        DFS(0, 0);
        return res;

        void DFS(int i, int current){
            if(i == nums.Length){
                res += current;
                return;
            }

            var newXOR = current ^ nums[i];
            DFS(i + 1, newXOR);
            DFS(i + 1, current);
        }
    }
}