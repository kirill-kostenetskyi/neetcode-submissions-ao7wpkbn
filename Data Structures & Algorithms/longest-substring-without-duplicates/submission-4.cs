public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length <= 1) {
            return s.Length;
        }

        var set = new HashSet<char>();
        var maxLength = 0;
        var currentLength = 0;
        var L = 0;
        var R = 1;
        set.Add(s[L]);

        while(R < s.Length){
            if(set.Contains(s[R])){
                set.Remove(s[L]);
                L++;
            } else {
                set.Add(s[R]);
                R++;
            }
            maxLength = Math.Max(maxLength, set.Count);
        }

        return maxLength;
    }
}