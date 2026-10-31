public class Solution {
    public List<string> FindWords(char[][] board, string[] words) {
        var trieRoot = BuildTrie();
        var res = new HashSet<string>();
        var dirs = new []{(-1, 0), (0, -1), (1, 0), (0, 1)};

        for(int r = 0; r < board.Length; r++){
            for(int c = 0; c < board[0].Length; c++){
                if(trieRoot.Children.ContainsKey(board[r][c])){
                    DFS(r, c, trieRoot.Children[board[r][c]]);
                }
            }
        }
        return res.ToList();

        void DFS(int r, int c, TrieNode root){
            if(board[r][c] == '#'){
                return;
            }
            if(root.IsEndOfWord){
                res.Add(root.Word);
            }
            var originalValue = board[r][c];
            board[r][c] = '#';
            foreach(var dir in dirs){
                var nr = dir.Item1 + r;
                var nc = dir.Item2 + c;
                if(nr < board.Length && nc < board[0].Length && nr >= 0 && nc >= 0
                && root.Children.ContainsKey(board[nr][nc])){
                    DFS(nr, nc, root.Children[board[nr][nc]]);
                }
            }
            board[r][c] = originalValue;
            return;
        }

        TrieNode BuildTrie(){
            var trieRoot = new TrieNode();
            var copyRoot = trieRoot;
            foreach(var w in words){
                trieRoot = copyRoot;
                foreach(var c in w){
                    if(trieRoot.Children.ContainsKey(c) == false){
                        trieRoot.Children[c] = new TrieNode();
                    }
                    trieRoot = trieRoot.Children[c];
                }
                trieRoot.IsEndOfWord = true;
                trieRoot.Word = w;
            }
            return copyRoot;
        }
    }
}

public class TrieNode(){
    public bool IsEndOfWord;
    public string Word;
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
}