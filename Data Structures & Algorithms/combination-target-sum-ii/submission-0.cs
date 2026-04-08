public class Solution {
    List<List<int>> results = new List<List<int>>();
    List<int> candidates = new List<int>();
    int target = 0;
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        this.candidates = candidates.OrderBy(x=>x).ToList();
        this.target = target;
        Logic(new List<int>(), 0, 0);
        return results;
    }

    private void Logic(List<int> current, int currentSum, int i) {
        if(target == currentSum){
            results.Add(current);
            return; 
        }
        
        if(currentSum > target){
            return;
        }
        
        if(i >= candidates.Count()){
            return;
        }
        currentSum = currentSum + candidates[i];
        current.Add(candidates[i]);
        i = i + 1;

        Logic(current.ToList(), currentSum, i);

        currentSum = currentSum - candidates[i - 1];
        current.RemoveAt(current.Count() - 1);


        while(i < candidates.Count() && candidates[i] == candidates[i - 1]){
            i++;
        }
        Logic(current.ToList(), currentSum, i);
    }
}