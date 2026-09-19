public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var countFreq = new Dictionary<int, int>(); // value, freq

        foreach(var n in nums){
            if(countFreq.TryGetValue(n, out var count)){
                countFreq[n] = count + 1;
            } else {
                countFreq[n] = 1;
            }
        }

        var buckets = new List<int>[nums.Length + 1];
        foreach(var kv in countFreq){
            var value = kv.Key;
            var frequence = kv.Value;
            if(buckets[frequence] == null){
                buckets[frequence] = new List<int>(){ value };
            } else {
                buckets[frequence].Add(value);
            }
        }

        var result = new List<int>();
        for(int i = buckets.Length - 1; i >= 0; i--){
            if(k == 0){
                return result.ToArray();
            }
            if(buckets[i] == null){
                continue;
            }
            foreach(var internalVal in buckets[i]){
                result.Add(internalVal);
                k--;
            }
        }
        return result.ToArray();
    }
}