public class Solution {
    public int NumDecodings(string s) {
        var cache = new Dictionary<int, int>();

        return DFS(0);

        int DFS(int i){
            if(i == s.Length){
                return 1;
            }
            if(s[i] == '0'){
                return 0;
            }
            if(cache.ContainsKey(i)){
                return cache[i];
            }

            var count1 = DFS(i + 1);
            var count2 = 0;
            if(i + 1 < s.Length && isValidPair(s[i], s[i + 1])){
                count2 = DFS(i + 2);
            }
            cache[i] = count1 + count2;

            return count1 + count2;
        }

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