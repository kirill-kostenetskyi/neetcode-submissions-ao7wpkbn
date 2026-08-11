public class Solution {
    public int Change(int amount, int[] coins) {
        // var cache = new Dictionary<(int, int), int>();
        // return DFS(0, 0);
        // // Сколько существует способов завершить текущую сумму до amount, используя монеты начиная с i?
        // int DFS(int i, int currentAmount){
        //     if(amount == currentAmount){
        //         return 1;
        //     }
        //     if(currentAmount > amount || i >= coins.Length){
        //         return 0;
        //     }
        //     if(cache.ContainsKey((i, currentAmount))){
        //         return cache[(i, currentAmount)];
        //     }
        //     var left = DFS(i, currentAmount + coins[i]);
        //     var right = DFS(i + 1, currentAmount);
            
        //     var res = 0;
        //     if(left >= 1){
        //         res = res + left;
        //     } 
        //     if(right >= 1){
        //         res = res + right;
        //     }
        //     cache[(i, currentAmount)] = res;
        //     return res;
        // }

        var dp = new long[coins.Length + 1][];
        
        for(long i = 0; i < dp.Length; i++){
            dp[i] = new long[amount + 1];
            // Почему 1? Потому что если target уже достигнут, существует ровно один способ завершить решение: ничего больше не брать
            dp[i][^1] = 1;
        }

        Array.Fill(dp[^1], 0);
        // amount == currentAmount base case побеждает для углового значения
        dp[^1][^1] = 1;

        for(long r = dp.Length - 2; r >=0; r--){
            for(long c = dp[0].Length - 2; c >= 0; c--){
                var leftColumn = c + coins[r];
                long left = 0;
                if(leftColumn < dp[0].Length){
                    left = dp[r][leftColumn];
                }
                var right = dp[r + 1][c];
                
                long res = 0;
                if(left >= 1){
                    res = res + left;
                } 
                if(right >= 1){
                    res = res + right;
                }
                dp[r][c] = res;
            }
        }
        return (int) dp[0][0];
    }
}