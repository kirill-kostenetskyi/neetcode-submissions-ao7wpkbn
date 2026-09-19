public class Solution {

    // Encodes a list of strings to a single string.
    public string Encode(IList<string> strs) {
        var sb = new StringBuilder();
        foreach(var s in strs){
            sb.Append(s.Length);
            sb.Append("#");
            sb.Append(s);
        }
        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public List<string> Decode(string s) {
        var res = new List<string>();

        var sb = new StringBuilder();
        var p = 0;
        while(p < s.Length){
            if(s[p] == '#'){
                var nextStrLength = int.Parse(sb.ToString());
                sb = new StringBuilder();
                var finalSb = new StringBuilder();
                p++;
                while(nextStrLength != 0){
                    finalSb.Append(s[p]);
                    nextStrLength--;
                    p++;
                }
                res.Add(finalSb.ToString());
            } else {
                sb.Append(s[p]);    
                p++;
            }
        }
        return res;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));