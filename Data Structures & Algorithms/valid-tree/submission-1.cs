public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        var visited = 0;
        var visiting = 1;
        var unvisited = 2;
        var adjList = new Dictionary<int, List<int>>();
        var states = new Dictionary<int, int>();

        for(int i = 0; i < n; i++){
            adjList[i] = new List<int>();
            states[i] = unvisited;
        }

        for(int i = 0; i < edges.Length; i++){
            adjList[edges[i][0]].Add(edges[i][1]);
            adjList[edges[i][1]].Add(edges[i][0]);
        }

        var res = IsValid(0, -1);
        if(res){
            if(states.Values.Count(x => x == visited) == n){
                return true;
            }
        }
        return false;

        bool IsValid(int edge, int parentEdge){
            if(states[edge] == visited){
                return true;
            }

            if(states[edge] == visiting){
                return false;
            }

            states[edge] = visiting;

            foreach(var a in adjList[edge]){
                if(a == parentEdge){
                    continue;
                }
                var res = IsValid(a, edge);
                if(res == false){
                    return false;
                }
            }

            states[edge] = visited;

            return true;
        }
    }
}