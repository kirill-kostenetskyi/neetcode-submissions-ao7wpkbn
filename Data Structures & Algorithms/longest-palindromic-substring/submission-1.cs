public class Solution {
    public string LongestPalindrome(string s) {
        var maxStr = s[0].ToString();
        
        for(int i = 0; i < s.Length; i++){
            var L = i;
            var R = i;
            while(L >= 0 && L < s.Length && R < s.Length && R >= 0 && s[L] == s[R]){
                var maxLen = R - L + 1;
                if(maxLen > maxStr.Length){
                    maxStr = s[L..(R + 1)];
                }
                L--;
                R++;
            }

            L = i;
            R = i + 1;
            while(L >= 0 && L < s.Length && R < s.Length && R >= 0 && s[L] == s[R]){
                var maxLen = R - L + 1;
                if(maxLen > maxStr.Length){
                    maxStr = s[L..(R + 1)];
                }
                L--;
                R++;
            }
        }
        return maxStr;
    }
}