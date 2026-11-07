public class Solution {
    public List<string> LetterCombinations(string digits) {
        var d = new Dictionary<char, List<char>>();
        d.Add('2', new List<char> { 'a', 'b', 'c' });
        d.Add('3', new List<char> { 'd', 'e', 'f' });
        d.Add('4', new List<char> { 'g', 'h', 'i' });
        d.Add('5', new List<char> { 'j', 'k', 'l' });
        d.Add('6', new List<char> { 'm', 'n', 'o' });
        d.Add('7', new List<char> { 'p', 'q', 'r', 's' });
        d.Add('8', new List<char> { 't', 'u', 'v' });
        d.Add('9', new List<char> { 'w', 'x', 'y', 'z' });

        var res = new List<string>();
        DFS(0, "");
        return res; 

        void DFS(int i, string c){    
            if(i == digits.Length){
                if(c.Length == 0){
                    return;
                }   
                res.Add(c);
                return;
            }
            
            var letters = d[digits[i]];
            foreach(var l in letters){
                DFS(i + 1, c + l);
            }
        }
    }
}