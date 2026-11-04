public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var dict = new Dictionary<int, int>();
        dict.Add(0, 1);
        var prefixSum = 0;
        var res = 0;
        for(int i = 0; i < nums.Length; i++) {
            prefixSum += nums[i];
            // сначала ищем среди прошлых префиксов
            var searchReq = prefixSum - k;
            if(dict.TryGetValue(searchReq, out var existingCount)){
                res += existingCount;
            }
            
            // только потом сохрнаяем текущий префикс
            if(dict.TryGetValue(prefixSum, out var current)){
                dict[prefixSum] = current + 1;
            } else {
                dict[prefixSum] = 1;
            }
        }   
        return res;     
    }
}