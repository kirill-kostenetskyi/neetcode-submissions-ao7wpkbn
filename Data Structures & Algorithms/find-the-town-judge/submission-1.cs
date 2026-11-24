public class Solution {
    public int FindJudge(int n, int[][] trust) {
        var indegree = new Dictionary<int, int>();
        var outdegree = new Dictionary<int, int>();
        
        for(int i = 1; i <= n; i++){
            indegree[i] = 0;
            outdegree[i] = 0;
        }

        foreach(var t in trust){
            var a = t[0];
            var b = t[1];
            indegree[b]++;
            outdegree[a]++;
        }

        for(int i = 1; i <= n; i++){
            if(indegree[i] == n - 1 && outdegree[i] == 0){
                return i;
            }
        }
        return -1;
    }
}