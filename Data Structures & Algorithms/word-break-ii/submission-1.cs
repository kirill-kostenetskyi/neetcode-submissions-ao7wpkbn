public class Solution {
    public List<string> WordBreak(string s, IList<string> wordDict) {
        var memo = new Dictionary<int, List<string>>();

        return DFS(0);
//возвращает все возможные предложения, которыми можно разбить суффикс строки начиная с i.
        List<string> DFS(int i) {
            if (i == s.Length)
                return new List<string> { "" };

            if (memo.TryGetValue(i, out var cached))
                return cached;

            var result = new List<string>();

            foreach (var word in wordDict) {
                if (i + word.Length > s.Length)
                    continue;

                if (s.Substring(i, word.Length) != word)
                    continue;

                foreach (var suffix in DFS(i + word.Length)) {
                    var sentence = word +
                        (suffix.Length > 0 ? " " + suffix : "");

                    result.Add(sentence);
                }
            }

            memo[i] = result;
            return result;
        }
    }
}