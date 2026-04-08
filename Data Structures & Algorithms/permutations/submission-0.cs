public class Solution {
    private IList<IList<int>> results = new List<IList<int>>(); 

    public List<List<int>> Permute(int[] nums) {
        return NoRecursionLogic(nums);

        // var results2 = Logic(nums, -1);
        // return results2;
    }

    private List<List<int>> NoRecursionLogic(int[] nums){
        List<List<int>> results = new List<List<int>>(){new List<int>()}; 
        for(int i = 0; i < nums.Count(); i++){
            List<List<int>> newResults = new List<List<int>>();
            for(int r = 0; r < results.Count(); r++){
                for(var ct = 0; ct <= results[r].Count(); ct++){
                    var listCopy = results[r].ToList();
                    listCopy.Insert(ct, nums[i]);
                    newResults.Add(listCopy);
                }
            }
            results = newResults.ToList();
        }
        return results;
    }
    
    private List<IList<int>> Logic(int[] nums, int i){
        if(i + 1 == nums.Count()){
            return new List<IList<int>>(){new List<int>(){}};
        }
        i = i + 1;
        var results = Logic(nums, i);
        List<IList<int>> updatedResults = new List<IList<int>>();
        for(int j = 0; j < results.Count(); j++){
            for(int k = 0; k <= results[j].Count(); k++){
                var listCopy = results[j].ToList();
                listCopy.Insert(k, nums[i]);
                updatedResults.Add(listCopy);
            }
        }
        return updatedResults;
    }
}; 