public class Solution {
    public int CharacterReplacement(string s, int k) {
        var dict = new Dictionary<char, int>();
        var L = 0;
        var R = 1;
        var maxLength = 1;
        dict[s[L]] = 1;

        while(R < s.Length){
            if(dict.TryGetValue(s[R], out var existing)){
                dict[s[R]] = existing + 1;
            } else {
                dict[s[R]] = 1;
            }

            while((R - L + 1) - dict.Values.Max() > k){
                dict[s[L]]--;
                L++;
            }
            maxLength = Math.Max(maxLength, R - L + 1);
            R++;
        }     
        return maxLength;
    }
}