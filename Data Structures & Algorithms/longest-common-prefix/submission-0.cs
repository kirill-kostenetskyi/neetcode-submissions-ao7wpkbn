public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var longestStr = strs.Select(x => x.Length).Max();
        var sb = new StringBuilder();
        for(int i = 0; i < longestStr; i++){
            if(i >= strs[0].Length){
                return sb.ToString();
            }
            var letter = strs[0][i];
            foreach(var s in strs){
                if(i >= s.Length || s[i] != letter){
                    return sb.ToString(); 
                }
            }
            sb.Append(letter);
        }
        return sb.ToString();
    }
}