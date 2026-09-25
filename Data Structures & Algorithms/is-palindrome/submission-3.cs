public class Solution {
    public bool IsPalindrome(string s) {
        var L = 0;
        var R = s.Length - 1;
        while (L < R){
            while(L < R && char.IsLetterOrDigit(s[L]) == false){
                L++;
            }
            while(L < R && char.IsLetterOrDigit(s[R]) == false){
                R--;
            }
            if(char.ToLower(s[L]) != char.ToLower(s[R])){
                return false;
            }
            L++;
            R--;
        }
        return true;
    }
}