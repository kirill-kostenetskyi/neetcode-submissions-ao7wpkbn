public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var adj = new Dictionary<int, List<int>>();

        var visited = new HashSet<int>();
        var pathVisited = new HashSet<int>();

        for(int i = 0; i < numCourses; i++){
            adj[i] = new List<int>(){ };
        }

        foreach(var p in prerequisites){
            var source = p[0];
            var target = p[1];
            adj.TryGetValue(source, out var list);
            list.Add(target);
        }

        var result = new List<int>();
        foreach(var c in adj.Keys) {

            var success = DFS(c);

            if(!success){
                return new int[0];
            }
        }

        return result.ToArray();

        bool DFS(int course){
            if(pathVisited.Contains(course)){
                return false;
            }
            if(visited.Contains(course)){
                return true;
            }

            pathVisited.Add(course);

            foreach(var nei in adj[course]){
                var localRes = DFS(nei);
                if(!localRes){
                    return false;
                }
            }
            
            visited.Add(course);
            result.Add(course);
            pathVisited.Remove(course);

            return true;
        }
    }
}