public class Solution {
    private List<string> result = new List<string>();
    private Dictionary<int, List<char>> d = new Dictionary<int, List<char>>();
    private int maxLvl = 0;
    private string digits;

    public List<string> LetterCombinations(string digits) {
        d.Add(2, new List<char> { 'a', 'b', 'c' });
        d.Add(3, new List<char> { 'd', 'e', 'f' });
        d.Add(4, new List<char> { 'g', 'h', 'i' });
        d.Add(5, new List<char> { 'j', 'k', 'l' });
        d.Add(6, new List<char> { 'm', 'n', 'o' });
        d.Add(7, new List<char> { 'p', 'q', 'r', 's' });
        d.Add(8, new List<char> { 't', 'u', 'v' });
        d.Add(9, new List<char> { 'w', 'x', 'y', 'z' });

        maxLvl = digits.Length;
        this.digits = digits;


        List<int> digitsNum = new List<int>();
        foreach(char c in digits){
            digitsNum.Add(c);
        }

        Logic(new List<char>(), 0);
        return result;
    }

    private void Logic(List<char> currentStack, int currentLvl){
        if(currentLvl == maxLvl){
            var currentStr = new string(currentStack.ToArray());
            if(!string.IsNullOrEmpty(currentStr)){
                result.Add(currentStr);
            }
            return;
        }
        
        char numberChar = digits[currentLvl];
        int numberInt = numberChar - '0';
        List<char> currentLetters = d[numberInt]; // def
        for(int currentLetter_i = 0; currentLetter_i < currentLetters.Count(); currentLetter_i++){
            //d //e //f 
            currentLvl = currentLvl + 1;
            currentStack.Add(currentLetters[currentLetter_i]);

            Logic(currentStack.ToList(), currentLvl);

            currentLvl = currentLvl - 1;
            currentStack.RemoveAt(currentStack.Count() - 1);

        }
        
        return;
    }
}