public class Solution {
    public List<List<int>> CombinationSum(int[] candidates, int target) {
        List<List<int>> res = new List<List<int>>();
        DFS(0, 0, new List<int>());
        return res;
        
        void DFS(int startFrom, int sum, List<int> c){
            if(sum == target){
                res.Add(c.ToList());
                return;
            }

            if(sum > target){
                return;
            }

            for(int i = startFrom; i < candidates.Length; i++){
                c.Add(candidates[i]);
                DFS(i, sum + candidates[i], c);
                c.RemoveAt(c.Count - 1);
            }
        }
    }
}