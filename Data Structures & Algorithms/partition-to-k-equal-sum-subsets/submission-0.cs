public class Solution {
    public bool CanPartitionKSubsets(int[] nums, int k) {
        Array.Sort(nums);
        Array.Reverse(nums);
        var sum = nums.Sum();
        if(sum % k > 0){
            return false;
        }
        var subsetTarget = sum / k;
        var buckets = new int[k];
        var res = DFS(0);

        return res;

        bool DFS(int i){
            if(i == nums.Length){
                return true;
            }
            var tried = new HashSet<int>();
            for(int j = 0; j < buckets.Length; j++){
                if(buckets[j] + nums[i] > subsetTarget)
                    continue;

                if(tried.Contains(buckets[j])){
                    continue;
                }
                tried.Add(buckets[j]);

                buckets[j] += nums[i];

                if(buckets[j] <= subsetTarget){
                    var r = DFS(i + 1);
                    if(r){
                        return true;
                    }
                }
                buckets[j] -= nums[i];
            }
            return false;
        }
    }
}