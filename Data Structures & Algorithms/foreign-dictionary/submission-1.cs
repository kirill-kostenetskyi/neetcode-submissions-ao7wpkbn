public class Solution {
    public string foreignDictionary(string[] words) {
        var adj = new Dictionary<char, HashSet<char>>();
        foreach(var w in words){
            foreach(var c in w){
                adj[c] = new HashSet<char>();
            }
        }

        for(int i = 0; i < words.Length - 1; i++){
            var first = words[i];
            var second = words[i + 1];
            var minLength = Math.Min(first.Length, second.Length);
            if(first.Length > second.Length){
                var sub1 = first[0..minLength];
                var sub2 = second[0..minLength];
                if(sub1 == sub2){
                    return "";
                }
            }
            for(int j = 0; j < minLength; j++){
                if(first[j] != second[j]){
                    adj[first[j]].Add(second[j]);
                    break;
                }
            }
        }
        var res = new List<char>();
        var visited = new HashSet<char>();
        var pathVisited = new HashSet<char>();

        foreach(var c in adj.Keys){
            var dfsRes = DFS(c);
            if(!dfsRes) {
                return "";
            }
        }
        res.Reverse();
        
        return string.Join("", res);

        bool DFS(char current){
            if(pathVisited.Contains(current)){
                return false;
            }
            if(visited.Contains(current)){
                return true;
            }

            pathVisited.Add(current);
            foreach(var n in adj[current]){
                if(DFS(n) == false){
                    return false;
                }
            }
            visited.Add(current);
            pathVisited.Remove(current);
            res.Add(current);
            return true;
        }
    }
}