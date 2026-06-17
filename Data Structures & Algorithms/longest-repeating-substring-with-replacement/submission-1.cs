public class Solution {
    public int CharacterReplacement(string s, int k) {
        var L = 0;
        var charsCounts = new Dictionary<char, int>();
        var maxSize = 0;
        for(int R = 0; R < s.Length; R++){
            if(charsCounts.ContainsKey(s[R])){
                charsCounts[s[R]]++;
            } else {
                charsCounts[s[R]] = 1;
            }

            var mostPopularLetter = charsCounts.Values.ToArray().Max();
            var windowSize = R - L + 1;

            while(windowSize - mostPopularLetter > k){
                charsCounts[s[L]]--;
                L++;
                mostPopularLetter = charsCounts.Values.ToArray().Max();
                windowSize = R - L + 1;
            }
            maxSize = Math.Max(maxSize, windowSize);

        }
        return maxSize;
    }
}