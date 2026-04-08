public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var d = new Dictionary<int, int>();
        foreach(var num in nums){
            if(!d.ContainsKey(num)){
                d[num] = 1;
            } else {
                d[num] = d[num] + 1;
            }
        }

        List<KeyValuePair<int, int>> pairs = d.OrderByDescending(x=>x.Value).ToList();
        return pairs.Select(x=>x.Key).Take(k).ToArray();
    }  
}