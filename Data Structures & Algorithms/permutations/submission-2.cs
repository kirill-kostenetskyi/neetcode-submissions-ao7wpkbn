public class Solution {
    private List<List<int>> result =  new List<List<int>>();

    public List<List<int>> Permute(int[] nums) {
        var numsUsage = nums.Select(x=> false).ToArray();
        BackTrack(new List<int>(){}, nums, numsUsage);
        return result;
    }

    private void BackTrack(List<int> current, int[] nums, bool[] numsUsage){
        if(current.Count() == nums.Count()){
            result.Add(current.ToList());
            return;
        }

        for(int i = 0; i < nums.Count(); i++){
            if(numsUsage[i] == true){
                continue;
            }

            current.Add(nums[i]);
            numsUsage[i] = true;
            BackTrack(current, nums, numsUsage);
            
            current.RemoveAt(current.Count() - 1);
            numsUsage[i] = false;
        }
        
    }
}