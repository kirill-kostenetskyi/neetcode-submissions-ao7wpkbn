public class Solution {
    public int MaxProfit(int[] prices) {
        var cache = new Dictionary<(int, bool), int>();
        return DFS(0, true);
        // какую макс прибыть я могу получить начиная с дня i 
        int DFS(int i, bool allowedToBuy){
            if(i >= prices.Length){
                return 0; // ??
            }
            if(cache.ContainsKey((i, allowedToBuy))){
                return cache[(i, allowedToBuy)];
            }
            int maxRes;
            if(allowedToBuy){
                // buy
                var buy = -1 * prices[i] + DFS(i + 1, false);
                // skip buying
                var skip = DFS(i + 1, true);
                maxRes = Math.Max(buy, skip);
            } else {
                // sell THEN jump over the next cooldown
                var sell = prices[i] + DFS(i + 2, true);
                var hold = DFS(i + 1, false);
                maxRes = Math.Max(sell, hold);
            }
            cache.Add((i, allowedToBuy), maxRes);
            return maxRes;
        }
    }

}