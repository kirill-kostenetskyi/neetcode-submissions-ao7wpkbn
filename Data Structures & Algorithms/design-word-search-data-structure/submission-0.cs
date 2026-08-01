public class TrieNode {
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool Word { get; set; }
    public char Letter { get; set; } // not a must have but I added to see what's going on in the debug mode

    public TrieNode(char letter){
        Children = new Dictionary<char, TrieNode> ();
        Letter = letter;
    }
}

public class WordDictionary {
    private TrieNode root;

    public WordDictionary() {
        root = new TrieNode('-');
    }
    
    public void AddWord(string word) {
        var currentLevel = root;
        foreach(var c in word){
            if(!currentLevel.Children.ContainsKey(c)){
                currentLevel.Children.Add(c, new TrieNode(c));
            }
            currentLevel = currentLevel.Children[c];
        }
        currentLevel.Word = true;
    }
    
    public bool Search(string word) {
        return DFS(0, root);

        bool DFS(int i, TrieNode currentLevel){ 

            if(i == word.Length){
                if(currentLevel.Word){
                    return true;
                }
                else {
                    return false;
                }
            }
            

            var c = word[i];

            if(c == '.'){
                foreach(var keyValue in currentLevel.Children){
                    var result = DFS(i + 1, keyValue.Value);
                    if(result){
                        return true;
                    }
                }
            }

            if(currentLevel.Children.ContainsKey(c)){
                currentLevel = currentLevel.Children[c];
                return DFS(i + 1, currentLevel);
            }

            return false;
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */