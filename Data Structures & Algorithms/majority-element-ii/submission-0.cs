public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        var map = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++){
            if(map.TryGetValue(nums[i], out int current)){
                map[nums[i]] = current + 1;
            } else {
                map[nums[i]] = 1;
            }

            if(map.Count == 3){
                foreach(var kv in map){
                    map[kv.Key] -= 1;
                    if(map[kv.Key] == 0){
                        map.Remove(kv.Key);
                    }
                }
            }
        }

        var res = new List<int>();
        var freqMap = new Dictionary<int, int>();
        
        foreach(var n in nums){
            if(!map.ContainsKey(n)){
                continue;
            }
            if(freqMap.TryGetValue(n, out int current)){
                freqMap[n] = current + 1;
            } else {
                freqMap[n] = 1;
            }
        }
        
        var atLeastCount = nums.Length / 3 + 1;
        foreach(var kv in freqMap){
            if(kv.Value >= atLeastCount){
                res.Add(kv.Key);
            }
        }
        return res;
    }
}