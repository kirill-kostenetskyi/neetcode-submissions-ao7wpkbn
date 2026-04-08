public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;

        int L = 0;

        for(int R = 0; R < prices.Length; R++){
            if(prices[R] < prices[L]){
                L = R;
            }
            var currentProfit = prices[R] - prices[L];
            maxProfit = Math.Max(currentProfit, maxProfit);
        }

        return maxProfit;
    }
}