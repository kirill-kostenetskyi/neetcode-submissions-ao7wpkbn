public class TrieNode {
    public char Letter {get; set;}
    public Dictionary<char, TrieNode> Children {get; set;}
    public bool IsWordEnd {get; set;}
    public TrieNode(char letter){
        this.Letter = letter;
        Children = new Dictionary<char, TrieNode>();
    }
}

public class PrefixTree {
    TrieNode root;
    public PrefixTree() {
        root = new TrieNode(default);
    }
    
    public void Insert(string word) {
        var current = root;
        foreach(var c in word){
            if(current.Children.ContainsKey(c) == false){
                current.Children[c] = new TrieNode(c);
            }
            current = current.Children[c];
       }
       current.IsWordEnd = true;
    }
    
    public bool Search(string word) {
        var current = root;
        foreach(var c in word){
            if(current.Children.ContainsKey(c)){
                current = current.Children[c];
            } else {
                return false;
            }
        }

        if(current.IsWordEnd){
            return true;
        }

        return false;
    }
    
    public bool StartsWith(string prefix) {
        var current = root;
        foreach(var c in prefix){
            if(current.Children.ContainsKey(c) == false){
                return false;
            }
            current = current.Children[c];
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */