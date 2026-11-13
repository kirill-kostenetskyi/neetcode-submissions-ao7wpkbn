public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var visited = 0;
        var unvisited = 1;
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

        var count = 0;
        for(int i = 0; i < n; i++){
            if(states[i] == unvisited){
                DFS(i);
                count++;
            }
        }
        return count;

        void DFS(int edge) {
            states[edge] = visited;
            foreach(var a in adjList[edge]){
                if(states[a] == visited){
                    continue;
                }
                DFS(a);
            }
        }
    }
}