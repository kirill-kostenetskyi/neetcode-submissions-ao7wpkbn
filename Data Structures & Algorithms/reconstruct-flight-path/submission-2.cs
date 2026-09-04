public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        var adj = new Dictionary<string, List<string>>();
        foreach(var ticket in tickets){
            var source = ticket[0];
            var dest = ticket[1];
            adj[source] = new List<string>();
            adj[dest] = new List<string>();
        }

        foreach(var ticket in tickets){
            var source = ticket[0];
            var dest = ticket[1];
            adj[source].Add(dest);
        }

        foreach(var keyVal in adj){
            adj[keyVal.Key].Sort();
            adj[keyVal.Key].Reverse();
        }

        var result = new List<string>();

        DFS("JFK");

        void DFS(string city){
            while(adj[city].Count > 0){
                var nextCity = adj[city][^1];
                adj[city].RemoveAt(adj[city].Count - 1); // remove last
                DFS(nextCity);
            }
            result.Add(city);
        }
        result.Reverse();
        return result;
    }
}