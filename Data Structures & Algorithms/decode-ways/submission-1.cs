public class Solution {
    public int NumDecodings(string s) {
        var current = 0;
        var next1 = 1;
        var next2 = 0;

        for(int i = s.Length - 1; i >= 0; i--){
            if(s[i] == '0'){
                current = 0;
            } else {
                current = next1;
                if(i + 1 < s.Length && isValidPair(s[i], s[i + 1])){
                    current = next1 + next2;
                }
            }
            next2 = next1;
            next1 = current;
        }      

        return current;

        bool isValidPair(char a, char b){
            var ab = $"{a}{b}";
            try{
                int abInt =  int.Parse(ab);
                if(10 <= abInt && abInt <= 26){
                    return true;
                }
                return false;
            } catch(Exception e){
                return false;
            }
        }
    }
}