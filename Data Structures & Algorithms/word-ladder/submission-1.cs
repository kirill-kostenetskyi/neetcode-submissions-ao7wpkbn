public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var wordToPattern = new Dictionary<string, HashSet<string>>();
        var patternToWord = new Dictionary<string, HashSet<string>>();
        var adjList = new Dictionary<string, HashSet<string>>();
        wordList.Add(beginWord);
        foreach(var word in wordList){
            var patterns = ListPatterns(word);
            wordToPattern[word] = patterns;
            foreach(var pattern in patterns){
                if(patternToWord.TryGetValue(pattern, out var list)){
                    list.Add(word);
                } else {
                    patternToWord[pattern] = new HashSet<string>(){ word };
                }
            }
        }

        foreach(var word in wordList){
            adjList[word] = new HashSet<string>();
            foreach(var pattern in wordToPattern[word]) {
                var wordsBelongToPattern = patternToWord[pattern];
                adjList[word].UnionWith(wordsBelongToPattern);
            }
            adjList[word].Remove(word);
        }

        var visited = new HashSet<string>();
        var q = new Queue<string>();
        foreach(var w in adjList[beginWord]){
            q.Enqueue(w);
        }
        var depth = 1;
        while(q.Count > 0){
            depth++;
            var layerSize = q.Count();
            for(int i = 0; i < layerSize; i++){
                var word = q.Dequeue();
                if(word == endWord){
                    return depth;
                }
                if(visited.Contains(word)){
                    continue;
                }
                foreach(var w in adjList[word]){
                    q.Enqueue(w);
                }
                visited.Add(word);
            }
        }

        return 0;

        HashSet<string> ListPatterns(string word){
            var res2 = new List<string>();
            var res = new HashSet<string>();
            for(int i = 0; i < word.Length; i++){
                var sb = new StringBuilder(word);
                sb[i] = '*';
                res.Add(sb.ToString());
                res2.Add(sb.ToString());
            }
            return res;
        }
    }
}