public class Solution {
    public string foreignDictionary(string[] words) {
        var pairs = new List<List<char>>();
        for(int i = 0; i < words.Length - 1; i++){
            var firstWord = words[i];
            var secondWord = words[i + 1];
            var precheck = CompareTwoWords(firstWord, secondWord);
            if(precheck == false){
                return "";
            }
        }

        var notVisited = 0;
        var visited = 1;
        var visiting = 2;
        var statusMap = new Dictionary<char, int>();
        var adjList = new Dictionary<char, HashSet<char>>();
        foreach(var w in words){
            foreach(var c in w){
                adjList[c] = new HashSet<char>();
                statusMap[c] = notVisited;
            }
        }
        
        foreach(var pair in pairs){
            adjList[pair[0]].Add(pair[1]);
        }

        List<char> resArr = new List<char>();
        foreach(var kv in adjList){
            var v = kv.Key;
            var res = IsValidTreeDFS(v);
            if(res == false){
                return "";
            }
        }
        var finalRes = resArr.ToArray();
        Array.Reverse(finalRes);
        return new string(finalRes);

        bool IsValidTreeDFS(char i){
            if(statusMap[i] == visited){
                return true;
            }
            if(statusMap[i] == visiting){
                return false;
            }
            statusMap[i] = visiting;
            foreach(var a in adjList[i]){
                var res = IsValidTreeDFS(a);
                if(res == false){
                    return false;
                    break;
                }
            }
            resArr.Add(i);
            statusMap[i] = visited;
            return true;
        }
        
        bool CompareTwoWords(string w1, string w2){
            var p1 = 0;
            var p2 = 0;
            while(p1 < w1.Length){
                if(p2 >= w2.Length && p1 < w1.Length){
                    return false;
                }
                if(w1[p1] != w2[p2]){
                    pairs.Add(new List<char>(){ w1[p1], w2[p2] });
                    return true;
                }
                p1++;
                p2++;
            }
            return true;
        }
    }
}