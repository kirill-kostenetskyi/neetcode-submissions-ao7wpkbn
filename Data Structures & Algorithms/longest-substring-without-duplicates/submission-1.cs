public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var set = new HashSet<char>();
        var longestStr = 0;
        int L = 0;

        for (int R = 0; R < s.Length; R++){
            char c = s[R];
            while(set.Contains(c) && L <= R){
                set.Remove(s[L]);
                L++;
            }
            set.Add(c);
            longestStr = Math.Max(longestStr, R - L + 1);
        }

        return longestStr;
    }
}