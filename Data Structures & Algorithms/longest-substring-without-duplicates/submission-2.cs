public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var alreadyAdded = new HashSet<char>();
        var L = 0;
        var R = 0;
        var longest = 0;
        while(R < s.Length){
            while(alreadyAdded.Contains(s[R]) && L != R){
                alreadyAdded.Remove(s[L]);
                L++;
            }
            alreadyAdded.Add(s[R]);
            R++;
            longest = Math.Max(longest, R - L);
        }

        return longest;
    }
}