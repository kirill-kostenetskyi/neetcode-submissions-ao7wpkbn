public class Solution {

    private HashSet<int> visited = new HashSet<int>();
    private Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>();

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        for(int i = 0; i < prerequisites.Length; i++){
            var a = prerequisites[i][0];
            var b = prerequisites[i][1];
            
            adjList[a] = new HashSet<int>();
            adjList[b] = new HashSet<int>();
        }

        for(int i = 0; i < prerequisites.Length; i++){
            var a = prerequisites[i][0];
            var b = prerequisites[i][1];

            if(adjList.ContainsKey(a)){
                var currentSet = adjList[a];
                currentSet.Add(b);
                adjList[a] = currentSet;
            } else {
                adjList[a] = new HashSet<int>(){ b };
            }
        }

        foreach(var a in adjList){
            var res = dfs(a.Key, prerequisites);
            if(res == false){
                return false;
            }
        }
        return true;
    }

    private bool dfs(int vertex, int[][] prerequisites){
        if(visited.Contains(vertex)){
            return false;
        }
        if(adjList[vertex].Count == 0){
            return true;
        }

        visited.Add(vertex);

        foreach(var neis in adjList[vertex]){
            var isValid = dfs(neis, prerequisites);
            if(isValid == false){
                return false;
            }
            adjList[vertex].Remove(neis);
        }

        visited.Remove(vertex);

        return true;
    }
}