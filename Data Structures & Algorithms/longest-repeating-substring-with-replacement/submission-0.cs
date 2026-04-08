public class Solution {
    public int CharacterReplacement(string s, int k) {
        var maxLen = 0;
        var map = new Dictionary<char, int>();
        var L = 0;

        for(int R = 0; R < s.Length; R++){
            if(map.ContainsKey(s[R])){
                map[s[R]] = map[s[R]] + 1;
            } else {
                map[s[R]] = 1;
            }

            var moreOftenLetterCnt = map.Values.ToArray().Max();
            var howManyLettersShouldBeReplaced = R - L + 1 - moreOftenLetterCnt;
            while(howManyLettersShouldBeReplaced > k && L <= R){
                // shift L
                map[s[L]] = map[s[L]] - 1;
                L++;
                moreOftenLetterCnt = map.Values.ToArray().Max();
                howManyLettersShouldBeReplaced = R - L + 1 - moreOftenLetterCnt;
            }

            var windowSize = R - L + 1;
            maxLen = Math.Max(windowSize, maxLen);
        }

        return maxLen;

    }
} 