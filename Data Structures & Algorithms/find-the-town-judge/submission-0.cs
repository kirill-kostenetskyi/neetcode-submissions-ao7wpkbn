public class Solution {
    public int FindJudge(int n, int[][] trust) {
        var adjList = new Dictionary<int, HashSet<int>>();
        for(int i = 1; i <= n; i++){
            adjList[i] = new HashSet<int>();
        }
        foreach(var t in trust){
            var a = t[0];
            var b = t[1];
            adjList[a].Add(b);
        }
        var count = 0;
        int res = 0;
        foreach(var kv in adjList){
            if(kv.Value.Count == 0){
                res = kv.Key;
                count++;
            }
        }
        if(count == 1){
            // second check
            foreach(var kv in adjList){
                if(kv.Key == res){
                    continue;
                } else {
                    if(kv.Value.Contains(res) == false){
                        return -1;
                    }
                }
            }
            return res;
        }
        return -1;
    }
}