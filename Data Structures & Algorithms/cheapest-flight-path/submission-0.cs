public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var adj = new Dictionary<int, List<(int, int)>>(); // source, target, cost
        var cache = new Dictionary<(int, int), int>();

        for(int i = 0; i < flights.Length; i++){
            var source = flights[i][0];
            var target = flights[i][1];
            var cost = flights[i][2];
            if(adj.TryGetValue(source, out var existing)){
                existing.Add((target, cost));
            } else {
                adj[source] = new List<(int, int)>(){ (target, cost) };
            }
        }

        return DFS(src, k); // 1, 3

        // Returns the cheapest price from city to dst
        // using no more than k remaining stops
        int DFS(int city, int k){
            if(city == dst){
                return 0;
            }
            if(k < 0){
                return -1;
            }
            if(!adj.ContainsKey(city)){
                return -1;
            }
            if(cache.TryGetValue((city, k), out var existing)){
                return existing;
            }

            var minRes = int.MaxValue;
            foreach((int target, int cost) in adj[city]){
                var res = DFS(target, k - 1);
                if(res == -1){
                    continue;
                } else {
                    minRes = Math.Min(res + cost, minRes);
                }
            }
            if(minRes == int.MaxValue){
                minRes = -1;
            }
            cache.Add((city, k), minRes);
            return minRes;
        }
        
    }
}