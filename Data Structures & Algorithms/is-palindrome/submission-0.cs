public class Solution {
    public bool IsPalindrome(string s) {
        if(s.Length == 1){
            return true;
        }
        var i = 0;
        var j = s.Length - 1;
        while(i != j && i < j) {
            var l = s[i];
            var r = s[j];
            if(!char.IsLetterOrDigit(l)){
                i++;
                continue;
            }
            if(!char.IsLetterOrDigit(r)){
                j--;
                continue;
            }
            if(char.ToUpper(l) != char.ToUpper(r)){
                return false;
            } else {
                i++;
                j--;
            }
        };
        return true;
    }
}