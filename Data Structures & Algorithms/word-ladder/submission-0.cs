public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var wordsPatterns = new Dictionary<string, List<string>>();
        var visited = new HashSet<string>();

        var startPatterns = new List<string>(); // helper array to start the BFS

        wordList.Add(beginWord);

        if(wordList.Any(x => endWord == x) == false){
            return 0;
        }

        foreach(var word in wordList){
            var patterns = GetWordPatterns(word);

            foreach(var pattern in patterns){
                if(!wordsPatterns.ContainsKey(pattern)){
                    wordsPatterns[pattern] = new List<string>() { word };
                } else {
                    wordsPatterns[pattern].Add(word);
                }

                if(word == beginWord){
                    startPatterns.Add(pattern);
                }
            }
        }

        //BFS
        var q = new Queue<List<string>>();

        visited.Add(beginWord);

        q.Enqueue(startPatterns);
    
        var currentLayer = 1;

        while(q.Count() > 0){
            var currentPatterns = q.Dequeue();
            currentLayer = currentLayer + 1;

            var nextBFSLayerPatterns = new List<string>();

            foreach(var cp in currentPatterns) {
                var similarPatternsWords = wordsPatterns[cp];

                foreach(var spw in similarPatternsWords){
                    if(visited.Contains(spw)){
                        continue;
                    } 
                                            
                    if(spw == endWord){
                        return currentLayer;
                    }

                    visited.Add(spw);

                    var nextPatterns = GetWordPatterns(spw);
                    nextBFSLayerPatterns.AddRange(nextPatterns);
                }
            }

            if(nextBFSLayerPatterns.Count > 0){
                q.Enqueue(nextBFSLayerPatterns);
            }
        }

        return 0;
    }

    private List<string> GetWordPatterns(string word){
        var result = new List<string>();
        for(int starIndex = 0; starIndex < word.Length; starIndex++){
            var patternBuilder = "";
            for(int wordIndex = 0; wordIndex < word.Length; wordIndex++){
                if(wordIndex == starIndex){
                    patternBuilder = patternBuilder + "*";
                } else {
                    patternBuilder = patternBuilder + word[wordIndex];
                }
            }
            result.Add(patternBuilder);
        }
        return result;
    }
}
