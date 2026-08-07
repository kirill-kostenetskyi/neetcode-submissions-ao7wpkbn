public class Solution {
    public int MaxProfit(int[] prices) {
        var L = 0;
        var R = 0;
        var maxProfit = 0;
        while(R < prices.Length){
            if(prices[L] > prices[R]){
                L = R;
            }
            maxProfit = Math.Max(maxProfit, prices[R] - prices[L]);
            R++;
        }
        return maxProfit;
    }
}