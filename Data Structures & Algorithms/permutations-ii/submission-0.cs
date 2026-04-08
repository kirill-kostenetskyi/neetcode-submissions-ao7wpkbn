public class Solution {
    private List<List<int>> results = new List<List<int>>();
    public List<List<int>> PermuteUnique(int[] nums) {
        var leftovers = new Dictionary<int, int>();

        for(int i = 0; i < nums.Count(); i++){
            if(leftovers.ContainsKey(nums[i])){
                leftovers[nums[i]] = leftovers[nums[i]] + 1; 
            } else {
                leftovers[nums[i]] = 1; 
            }
        }

        Logic(nums, leftovers, new List<int>(), nums.Count());
        return results;
    }

    private void Logic(int[] nums, Dictionary<int,int> leftovers, List<int> current, int totalUsed){
        if(current.Count() == nums.Count()){
            results.Add(current.ToList());
            return;
        }
        if(totalUsed == 0){
            return;
        }
        var keys = leftovers.Keys;
        foreach(var key in keys){
            var localLeftovers = leftovers.ToDictionary();
            localLeftovers[key] = localLeftovers[key] - 1;
            if(localLeftovers[key] < 0){
                continue;
            }
            current.Add(key);
            totalUsed = totalUsed - 1;
            Logic(nums, localLeftovers, current, totalUsed);

            current.RemoveAt(current.Count() - 1);
            totalUsed = totalUsed + 1;
        }
    }
}