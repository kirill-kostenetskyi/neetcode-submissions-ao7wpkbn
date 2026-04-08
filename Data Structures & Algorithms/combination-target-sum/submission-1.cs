public class Solution {
    private List<List<int>> result = new List<List<int>>();
    private List<int> candidates = new List<int>();

    public List<List<int>> CombinationSum(int[] nums, int target) {
        this.candidates = nums.ToList();
        Logic(new List<int>(), 0, target, 0);
        return result;
    }

    private void Logic(List<int> currentCandidates, int i, int target, int currentSum){
        if(currentSum == target){
            result.Add(currentCandidates);
            return;
        }
        if(i >= candidates.Count() || currentSum > target){
            return;
        }
        
        var current = candidates[i];
        currentCandidates.Add(current);
        currentSum = currentSum + current;
        Logic(currentCandidates.ToList(), i, target, currentSum);

        i = i + 1;
        currentCandidates.RemoveAt(currentCandidates.Count() - 1);
        currentSum = currentSum - current;

        Logic(currentCandidates.ToList(), i, target, currentSum);
        return;
    }
}