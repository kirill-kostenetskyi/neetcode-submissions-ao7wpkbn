public class Solution
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new();
        public string Word;
    }

    public List<string> FindWords(char[][] board, string[] words)
    {
        var root = BuildTrie(words);
        var result = new List<string>();

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[0].Length; c++)
            {
                DFS(r, c, root);
            }
        }

        return result;
        
        void DFS(int r, int c, TrieNode node)
        {
            if (
                r < 0 ||
                c < 0 ||
                r >= board.Length ||
                c >= board[0].Length
            )
            {
                return;
            }

            char ch = board[r][c];

            // '#' означает: эта клетка уже есть в текущем пути.
            if (ch == '#' || !node.Children.TryGetValue(ch, out TrieNode nextNode))
            {
                return;
            }

            // Мы уже стоим в trie-узле, соответствующем текущей букве.
            if (nextNode.Word != null)
            {
                result.Add(nextNode.Word);

                // Предотвращает повторное добавление одного слова.
                nextNode.Word = null;
            }

            // Отмечаем клетку как использованную в текущей DFS-ветке.
            board[r][c] = '#';

            DFS(r + 1, c, nextNode);
            DFS(r - 1, c, nextNode);
            DFS(r, c + 1, nextNode);
            DFS(r, c - 1, nextNode);

            // Backtracking: возвращаем исходный символ.
            board[r][c] = ch;
        }
    }

    private TrieNode BuildTrie(string[] words)
    {
        var root = new TrieNode();

        foreach (string word in words)
        {
            TrieNode node = root;

            foreach (char ch in word)
            {
                if (!node.Children.TryGetValue(ch, out TrieNode nextNode))
                {
                    nextNode = new TrieNode();
                    node.Children[ch] = nextNode;
                }

                node = nextNode;
            }

            // Храним слово в конечном узле:
            // не нужно вручную собирать currentWord из List<char>.
            node.Word = word;
        }

        return root;
    }
}