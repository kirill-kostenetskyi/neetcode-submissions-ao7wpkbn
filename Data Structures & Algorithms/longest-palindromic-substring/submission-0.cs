public class Solution {
    
    public string LongestPalindrome(string s) {
        if(s.Length == 1){
            return s;
        }
        var hs = new HashSet<string>();
        var res = string.Empty;
        var L = 0;
        var R = s.Length - 1;

        DFS(L, R);

        return res;

        void DFS(int L, int R){
            if(L > R){
                return;
            }
            var substring = s[L..(R + 1)];

            if(hs.Contains(substring)){
                return;
            } else {
                hs.Add(substring);
            }

            DFS(L+1, R);
            DFS(L, R-1);

            var isPal = isPalindrome(L, R);
            if(isPal){
                if(res.Length < R - L + 1){
                    res = substring;
                }
            }
        }

        bool isPalindrome(int L, int R){
            while(L <= R){
                if(s[L] != s[R]){
                    return false;
                } else {
                    L++;
                    R--;
                }
            }
            return true;
        }   
    }
}