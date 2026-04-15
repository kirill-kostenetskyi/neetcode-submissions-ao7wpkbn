public class Solution {
    private Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>(); 
    private List<bool> visited;

    public int CountComponents(int n, int[][] edges) {
        visited = new List<bool>(n);
        for(int i = 0; i < n; i++){
            adjList[i] = new List<int>();
            visited.Add(false);
        }

        for(int i = 0; i < edges.Length; i++){
            var a = edges[i][0];
            var b = edges[i][1];

            adjList[a].Add(b);
            adjList[b].Add(a);
        }

        var result = 0;
        
        for(int i = 0; i < n; i++){
            if(visited[i] == false){
                DFS(i);
                result++;
            }
           
        }

        return result;
    }

    private void DFS(int current){
        if(visited[current] == true){
            return;
        }

        visited[current] = true;

        foreach(var nei in adjList[current]){
            DFS(nei);
        }

        return;
    }
}