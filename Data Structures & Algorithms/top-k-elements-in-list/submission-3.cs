public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var dict = new Dictionary<int, int>();
        foreach(var n in nums){
            dict[n] = 0;
        }
        foreach(var n in nums){
            dict[n]++;
        }

        var buckets = new List<int>[nums.Length + 1];
        for(int i = 0; i < buckets.Length; i++){
            buckets[i] = new List<int>();
        }

        foreach(var kv in dict){
            var currentBucketItems = buckets[kv.Value];
            currentBucketItems.Add(kv.Key);
        }

        var result = new List<int>();
        for(int i = buckets.Length - 1; i >=0; i--){
            if(buckets[i].Count > 0){
                foreach(var n in buckets[i]){
                    if(k == 0){
                        break;
                    }
                    result.Add(n);
                    k--;
                }
            }
        }

        return result.ToArray();
    }
}