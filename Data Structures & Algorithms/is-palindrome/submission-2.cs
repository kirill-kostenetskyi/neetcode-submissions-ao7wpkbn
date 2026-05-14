public class Solution {
    public bool IsPalindrome(string s) {
        var L = 0;
        var R = s.Length - 1;
        while(L <= R || (L > 0 && R > 0)){
            var LChar = s[L];
            var RChar = s[R];
            while(!char.IsLetterOrDigit(LChar) && L < s.Length - 1){
                L++;
                LChar = s[L];
            }
            while(!char.IsLetterOrDigit(RChar) && R > 0){
                R--;
                RChar = s[R];
            }
            if(char.ToLower(LChar) != char.ToLower(RChar) && L <= R){
                return false;
            }
            L++;
            R--;
        }

        return true;
    }
}