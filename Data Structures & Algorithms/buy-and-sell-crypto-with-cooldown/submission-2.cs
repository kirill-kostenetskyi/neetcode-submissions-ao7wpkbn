public class Solution {
    // public int MaxProfit(int[] prices) {
        // var cache = new Dictionary<(int, bool), int>();
        // return DFS(0, true);

        // // return profit for the current operation
        // int DFS(int i, bool allowedToBuy){
        //     if(i >= prices.Length){
        //         return 0;
        //     }
        //     if(cache.ContainsKey((i, allowedToBuy))){
        //         return cache[(i, allowedToBuy)];
        //     }
        //     var maxRes = 0;
        //     if(allowedToBuy){
        //         var buy = -1 * prices[i] + DFS(i + 1, false);
        //         var cooldown1 = DFS(i + 1, true);
        //         maxRes = Math.Max(buy, cooldown1);
        //     } else {
        //         var sell = prices[i] + DFS(i + 2, true);
        //         var cooldown2 = DFS(i + 1, false);
        //         maxRes = Math.Max(sell, cooldown2);
        //     }
        //     cache.Add((i, allowedToBuy), maxRes);
        //     return
        // }
    // }

     public int MaxProfit(int[] prices) {
        var sellDp = new int[prices.Length + 2];
        var buyDp = new int[prices.Length + 2];
        sellDp[^1] = 0; // not neccessary but I leave it for clarity
        sellDp[^2] = 0;
        buyDp[^1] = 0;
        buyDp[^2] = 0;

        for(int i = prices.Length - 1; i >=0; i--){
            var buy1 =  -1 * prices[i] + sellDp[i + 1];
            var buy2 =  buyDp[i + 1];
            var sell1 =  prices[i] + buyDp[i + 2];
            var sell2 =  sellDp[i + 1];
            buyDp[i] = Math.Max(buy1, buy2);
            sellDp[i] = Math.Max(sell1, sell2);
        }
        return buyDp[0];
    }
}