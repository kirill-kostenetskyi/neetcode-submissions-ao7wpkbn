public class Solution {
    public List<List<int>> Permute(int[] nums) {
        List<List<int>> res = new List<List<int>>();
        DFS(new HashSet<int>(), new List<int>());
        return res;
        
        void DFS(HashSet<int> visited, List<int> current){
            if(visited.Count == nums.Length){
                res.Add(current.ToList());
                return;
            }

            for(int i = 0; i < nums.Length; i++){
                if(visited.Contains(i) == false){
                    visited.Add(i);
                    current.Add(nums[i]);

                    DFS(visited, current);

                    visited.Remove(i);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
    }
}