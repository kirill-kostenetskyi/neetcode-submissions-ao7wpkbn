public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var adjList = new Dictionary<int, List<(int To, int Cost)>>();
        for(int i = 0; i < n; i++){
            adjList[i] = new List<(int, int)>();
        }
        foreach(var f in flights){
            var from = f[0];
            var to = f[1];
            var cost = f[2];
            if(adjList.TryGetValue(from, out var list)){
                list.Add((to, cost));
            }
        }
        var cache = new Dictionary<(int City, int K), int>();
        return DFS(src, 0);

        int DFS(int city, int kUsed){// сколько минимум мне нужно денег что бы добраться до destination из текущего
            if(city == dst){
                return 0;
            }
            if(kUsed == k + 1){
                return -1;
            }
            if(cache.ContainsKey((city, kUsed))){
                return cache[(city, kUsed)];
            }
            var bestPrice = int.MaxValue;
            foreach(var next in adjList[city]){
                var res = DFS(next.To, kUsed + 1);
                if(res == -1){
                    continue;
                }
                var totalCost = next.Cost + res;
                bestPrice = Math.Min(totalCost, bestPrice);
            }
            var costRes = 0;
            if(bestPrice != int.MaxValue){
                costRes = bestPrice;
            } else {
                costRes = -1;
            }
            cache[(city, kUsed)] = costRes;
            return costRes;
        }
    }
}