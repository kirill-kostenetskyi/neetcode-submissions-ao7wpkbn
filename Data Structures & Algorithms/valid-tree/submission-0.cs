public class Solution {
    private int Unvisited = 0; 
    private int Visiting = 1; 
    private int Visited = 2; 

    Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>(); 
    Dictionary<int, int> states = new Dictionary<int, int>(); 

    public bool ValidTree(int n, int[][] edges) {
        // very basic check
        if(edges.Length != n - 1){
            return false;
        }

        for(int i = 0; i < n; i++){
            states[i] = Unvisited;
            adjList[i] = new HashSet<int>();
        }

         for(int i = 0; i < edges.Length; i++){
            var a = edges[i][0];
            var b = edges[i][1];

            adjList[a].Add(b);
            adjList[b].Add(a);
        }

        var res = DFS(0, -1);

        for(int i = 0; i < n; i++){
            if(states[i] != Visited){
                return false;
            }
        }
        return res;
    }

    private bool DFS(int i, int parent){
        if (states[i] == Visited) {
            return true;
        }
        if(states[i] == Visiting){
            return false; // cycle
        }

        states[i] = Visiting;

        foreach(var nei in adjList[i]) {
            if(nei == parent){
                continue;
            }
            var res = DFS(nei, i);
            if(!res){
                return false;
            }
        }

        states[i] = Visited;

        return true;
    }
}