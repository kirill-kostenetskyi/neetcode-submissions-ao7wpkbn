public class Solution {
    public int TotalFruit(int[] fruits) {
        var L = 0;
        var R = 0;
        var cache = new Dictionary<int, int>();
        var maxCount = 0;
        while(R < fruits.Length){
            if(cache.TryGetValue(fruits[R], out int count)){
                cache[fruits[R]] += 1;
            } else {
                cache[fruits[R]] = 1;
            }

            while(L < fruits.Length && cache.Count() > 2){
                if(cache.ContainsKey(fruits[L])){
                    cache[fruits[L]] -= 1;
                    if(cache[fruits[L]] == 0){
                        cache.Remove(fruits[L]);
                    }
                }
                L++;
            }
            maxCount = Math.Max(maxCount, GetTotalCountInBucket());
            R++;
        }

        return maxCount;

        int GetTotalCountInBucket(){
            var sum = 0;
            foreach(var kv in cache){
                sum += kv.Value;   
            }
            return sum;
        }
    }
}