public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freq = new Dictionary<int, int>();

        foreach(var n in nums){
            var current = freq.GetValueOrDefault(n) + 1;
            freq[n] = current;
        }

        var bucketArray = new List<int>[nums.Length + 1];
        for (int i = 0; i < bucketArray.Length; i++)
        {
            bucketArray[i] = new List<int>();
        }

        foreach(var mt in freq){
            var num = mt.Key;
            var freqCurrent = mt.Value;
            bucketArray[freqCurrent].Add(num);
        }

        var result = new List<int>();
        for(int i = bucketArray.Length - 1; i >= 0; i--){
            if(bucketArray[i].Count > 0){
                foreach(var c in bucketArray[i]){
                    result.Add(c);
                    if(result.Count == k){
                        return result.ToArray();
                    }
                }               
            }
        }

        return result.ToArray();        
    }
}