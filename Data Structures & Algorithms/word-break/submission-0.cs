public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        var dp = new bool[s.Length + 1];
        dp[dp.Length - 1] = true;

        var hashSet = new HashSet<string>(wordDict);
        for(int i = dp.Length - 1; i >= 0; i--){

            foreach(var word in wordDict){

                var lengthToTheEnd = s.Length - i;

                if(lengthToTheEnd < word.Length){
                    continue;
                }
                var substring = s[i..(i + word.Length)];
                if(hashSet.Contains(substring) && dp[i + word.Length] == true){
                    dp[i] = true;
                }
            }
        }

        return dp[0];
    }
}