public class Solution {
    public int MinDistance(string word1, string word2) {
        var cache = new Dictionary<(int, int), int>();
        return DFS(0, 0);
    
        // min operations to convert starting from i and j
        int DFS(int i, int j){
            // word1 leftover "abc", word2 leftover ""
            if(j == word2.Length){
                return word1.Length - i;
            }
            // word1 == "" and word2 = "abc"
            if(i == word1.Length){
                return word2.Length - j;
            }
            if(cache.TryGetValue((i, j), out var cached)){
                return cached;
            }

            var bestRes = 501;
            if(word1[i] == word2[j]){
                var res1 = DFS(i + 1, j + 1);
                bestRes = Math.Min(bestRes, res1);
            } else {
                // replace
                var res2 = DFS(i + 1, j + 1) + 1;
                bestRes = Math.Min(bestRes, res2);
                // remove
                var res3 = DFS(i + 1, j) + 1;
                bestRes = Math.Min(bestRes, res3);
                // insert
                var res4 = DFS(i, j + 1) + 1;
                bestRes = Math.Min(bestRes, res4);
            }
            cache[(i, j)] = bestRes;
            return bestRes;
        }
    }

}