public class Solution {
    private List<List<int>> result = new List<List<int>>();
    public List<List<int>> SubsetsWithDup(int[] nums) {
        nums = nums.ToList().OrderBy(x=>x).ToArray();
        Logic(nums, new List<int>(), 0);
        return result;
    }

    private void Logic(int[] nums, List<int> currentSet, int i){
        if(i > nums.Length - 1){
            result.Add(currentSet);
            return;
        }
        currentSet.Add(nums[i]);
        i++;
        Logic(nums, currentSet.ToList(), i);
        currentSet.RemoveAt(currentSet.Count() - 1);
        
// [1, 2, 2]; lenght = 3; i = 2// end; 
        while(i < nums.Length && nums[i] == nums[i-1]){
            i++;
        }
        Logic(nums, currentSet.ToList(), i);
    }
}