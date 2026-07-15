public class Solution {
    public int CountSubstrings(string s) {
        var count = 0;
        
        for(int i = 0; i < s.Length; i++){
            var L = i;
            var R = i;
            while(L >= 0 && L < s.Length && R < s.Length && R >= 0 && s[L] == s[R]){
                count++;
                L--;
                R++;
            }

            L = i;
            R = i + 1;
            while(L >= 0 && L < s.Length && R < s.Length && R >= 0 && s[L] == s[R]){
                count++;
                L--;
                R++;
            }
        }
        return count;
    }
}