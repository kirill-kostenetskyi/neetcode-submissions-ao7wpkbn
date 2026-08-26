public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        List<List<int>> results = new List<List<int>>();
        Array.Sort(nums);
        Backtrack(0, new List<int>());
        return results;

        void Backtrack(int start, List<int> subset){
            results.Add(subset.ToList());
            
            for(int i = start; i < nums.Length; i++){
                if(i > start && nums[i - 1] == nums[i])
                    continue;

                subset.Add(nums[i]);

                Backtrack(i + 1, subset);

                subset.RemoveAt(subset.Count - 1);
            }
        }
    }
}