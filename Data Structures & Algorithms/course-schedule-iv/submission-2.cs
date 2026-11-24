public class Solution {
    public List<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var adjList = new Dictionary<int, HashSet<int>>();
        var cache = new Dictionary<int, HashSet<int>>();
        var negativeCache = new HashSet<(int, int)>();
        for(int i = 0; i < numCourses; i++){
            adjList[i] = new HashSet<int>();
            cache[i] = new HashSet<int>();
        }

        foreach(var p in prerequisites){
            adjList[p[0]].Add(p[1]);
            cache[p[0]].Add(p[1]);
        }

        List<bool> r = new List<bool>();
        HashSet<int> visited = new HashSet<int>();
        foreach(var q in queries){
            r.Add(DFS(q[0], q[1]));
        }
        return r;
        
        bool DFS(int current, int lookingFor){
            foreach(var v in visited){
                cache[v].UnionWith(cache[current]);
            }

            if(cache[current].Contains(lookingFor)){
                return true;
            }
            if(negativeCache.Contains((current, lookingFor))){
                return false;
            }
            if(current == lookingFor){
                return true;
            }

            visited.Add(current);
            var finalRes = false;
            foreach(var nei in adjList[current]){
                var res = DFS(nei, lookingFor);
                if(res){
                    finalRes = true;
                    break;
                }
            }
            if(finalRes == false){
                negativeCache.Add((current, lookingFor));
            }
            visited.Remove(current);
            return finalRes;
        }
    }
}