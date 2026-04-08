public class Solution {

    //TODO: use spans to improve performance:
    // string original = "hello world";
    //ReadOnlySpan<char> span = original.AsSpan();
    private char delSymbol = '#';

    public string Encode(IList<string> strs) {
        var sb = new StringBuilder();
        foreach(var str in strs) {
            sb.Append(str.Length);
            sb.Append(delSymbol);
            sb.Append(str);
        }
        return sb.ToString();
    }

    public List<string> Decode(string s) {
         var res = new List<string>();
        int i = 0;
        int last = 0;
        while(i < s.Length){
            var c = s[i];
            if(c == delSymbol){
                var len = int.Parse(s.Substring(last, i - last)); // next string length
                var startIndex = i + 1;
                var str = s.Substring(startIndex, len);
                res.Add(str);
                i = i + len + 1;
                last = i;
            } else {
                i++;
            }
        }
        return res;
   }
}