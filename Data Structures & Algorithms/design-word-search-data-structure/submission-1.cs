public class TrieNode{
    public bool IsEndWord;
    public char Letter;
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    
    public TrieNode(char letter){
        this.Letter = letter;
    }
}

public class WordDictionary {
    TrieNode root;
    public WordDictionary() {
        root = new TrieNode(default);
    }
    
    public void AddWord(string word) {
        var cur = root;
        foreach(var c in word){
            if(cur.Children.ContainsKey(c) == false){
                cur.Children[c] = new TrieNode(c);
            }
            cur = cur.Children[c];
        }
        cur.IsEndWord = true;
    }
    
    public bool Search(string word) {
        var current = root;
        return DFS(0, current);

        bool DFS(int start, TrieNode node){
            if(start == word.Length){
                return node.IsEndWord;
            }

            if(node.Children.ContainsKey(word[start])){
                return DFS(start + 1, node.Children[word[start]]);
            }
            else if(word[start] == '.'){
                foreach(var kv in node.Children){
                    var res = DFS(start + 1, kv.Value);
                    if(res){
                        return true;
                    }
                }
                return false;
            } else {
                return false;
            }
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */