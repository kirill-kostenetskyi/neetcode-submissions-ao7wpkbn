public class Solution {
    public List<string> LetterCombinations(string digits) {
        Dictionary<char, char[]> keys = new()
        {
            ['2'] = new[] { 'a', 'b', 'c' },
            ['3'] = new[] { 'd', 'e', 'f' },
            ['4'] = new[] { 'g', 'h', 'i' },
            ['5'] = new[] { 'j', 'k', 'l' },
            ['6'] = new[] { 'm', 'n', 'o' },
            ['7'] = new[] { 'p', 'q', 'r', 's' },
            ['8'] = new[] { 't', 'u', 'v' },
            ['9'] = new[] { 'w', 'x', 'y', 'z' },
        };
		
		var result = new List<string>();
		Backtrack(0, "");
		return result;
		
		void Backtrack(int i, string currentString){
			if (i == digits.Length){
                if(currentString != "")
			        result.Add(currentString);
			    return;
            }
            
            var letters = keys[digits[i]];
            foreach(var l in letters){
                Backtrack(i + 1, currentString + l);
            }
            return;
		}
    }
}