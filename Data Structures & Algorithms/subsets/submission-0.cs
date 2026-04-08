public class Solution {
    private List<List<int>> result = new List<List<int>>();

    public List<List<int>> Subsets(int[] nums) {
        SubsetsInternal(nums, new List<int>(), 0);
        return result;
    }

    private void SubsetsInternal(int[] nums, List<int> currentSet, int i){
        if(i > nums.Length - 1){
           result.Add(currentSet);
           return;
        }

        currentSet.Add(nums[i]);
        var nextEmelemnt = i+1;

        SubsetsInternal(nums, currentSet.ToList(), nextEmelemnt); // ToList creates a copy

        currentSet.RemoveAt(currentSet.Count() - 1);

        SubsetsInternal(nums, currentSet.ToList(), nextEmelemnt);
    }
}