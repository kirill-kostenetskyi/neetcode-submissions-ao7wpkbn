public class Solution {
    
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }
        var d = new Dictionary<char, int>(s.Length);
        foreach(char c in s){
            if(d.ContainsKey(c)){
                d[c] = d[c] + 1;
            } else {
                d[c] = 1;
            }
        }

        foreach(char ct in t){
            if(!d.ContainsKey(ct)){
                return false;
            }    

            if(d[ct] == 0){
                return false;
            }

            d[ct] = d[ct] - 1;
        }
        return true;
    }
}
