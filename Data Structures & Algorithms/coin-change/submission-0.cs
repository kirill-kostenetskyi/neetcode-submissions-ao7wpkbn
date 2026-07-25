public class Solution {
    public int CoinChange(int[] coins, int amount) {
        var hash = new Dictionary<int, int>();
        return DFS(amount); 

        // возвращает сколько шагов до 0 мне надо от текущего лефтовера
        int DFS(int leftOver){
            if(leftOver == 0){
                return 0;
            }
            
            if(hash.ContainsKey(leftOver)){
                return hash[leftOver];
            }

            var shortest = int.MaxValue;
            foreach(var coin in coins){
                if(leftOver - coin >= 0){
                    var res = DFS(leftOver - coin); 
                    if(res != -1){
                        shortest = Math.Min(shortest, res);
                    }
                }
            }
            var finalRes = shortest == int.MaxValue ? -1 : shortest + 1;
            hash.Add(leftOver, finalRes);
            return finalRes;
        }
    }
}