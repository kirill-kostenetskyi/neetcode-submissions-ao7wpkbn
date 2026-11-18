public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        var adjList = new Dictionary<string, List<string>>();
        foreach(var t in tickets){
            var from = t[0];
            var to = t[1];
            if(adjList.TryGetValue(from, out var list)){
                list.Add(to);
            } else {
                adjList[from] = new List<string>(){ to };
            }
        }
        foreach(var kv in adjList){
            kv.Value.Sort();
            kv.Value.Reverse();
        }
        
        var res = new List<string>();
        DFS("JFK");
        res.Reverse();
        return res;

        void DFS(string airport){
            while(adjList.ContainsKey(airport) && adjList[airport].Count > 0){
                var list = adjList[airport];
                var last = list.LastOrDefault();
                list.RemoveAt(list.Count - 1);
                DFS(last);
            }
            res.Add(airport);
        }
    }
}
