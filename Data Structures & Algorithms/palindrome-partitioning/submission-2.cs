public class Solution {
    public List<List<string>> Partition(string s) {
        var res = new List<List<string>>();
        DFS(1, new List<string>(){s[0].ToString()});
        return res;

        void DFS(int i, List<string> c){
            if(i == s.Length){
                if(IsPalindrome(c[(c.Count - 1)]) == false){
                    return;
                }
                res.Add(c.ToList());
                return;
            }

            var last = c[(c.Count - 1)];
            if(IsPalindrome(last)){
                c.Add(s[i].ToString());
                DFS(i + 1, c);
                c.RemoveAt(c.Count - 1);
            }
            c[c.Count - 1] = last + s[i];
            DFS(i + 1, c);
        }

        bool IsPalindrome(string s){
            var L = 0;
            var R = s.Length - 1;
            while(L < R){
                if(s[L] != s[R]){
                    return false;
                }
                L++;
                R--;
            }
            return true;
        }
    }
}