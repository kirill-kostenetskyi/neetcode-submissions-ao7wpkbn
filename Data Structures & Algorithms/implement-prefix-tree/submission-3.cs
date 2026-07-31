public class PrefixTree {

    private Dictionary<char, PrefixTree> Children { get; set; }
    private bool Word { get; set; }

    public PrefixTree() {
        this.Children = new Dictionary<char, PrefixTree>();
    }
    
    public void Insert(string word) {
        var currentLevel = this;
        foreach(var c in word){
            if(!currentLevel.Children.ContainsKey(c)){
                currentLevel.Children.Add(c, new PrefixTree());
            }
            currentLevel = currentLevel.Children[c];
        }
        currentLevel.Word = true;
    }
    
    public bool Search(string word) {
        var currentLevel = this;
        foreach(var c in word){
            if(currentLevel.Children.ContainsKey(c)){
                currentLevel = currentLevel.Children[c];
            } else {
                return false;
            }
        }
        return currentLevel.Word;
    }
    
    public bool StartsWith(string prefix) {
        var currentLevel = this;
        foreach(var c in prefix){
            if(currentLevel.Children.ContainsKey(c)){
                currentLevel = currentLevel.Children[c];
            } else {
                return false;
            }
        }
        return true;
    }
}