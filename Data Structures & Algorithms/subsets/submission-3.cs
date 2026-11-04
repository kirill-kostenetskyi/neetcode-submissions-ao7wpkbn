public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> res = new List<List<int>>();
        DFS(0, new List<int>());
        return res;

        void DFS(int i, List<int> current){
            if(i == nums.Length){
                res.Add(current);
                return;
            }

            current.Add(nums[i]);
            DFS(i + 1, current.ToList());
            current.RemoveAt(current.Count - 1);
            DFS(i + 1, current.ToList());
        }
    }
}