public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        var cache = new Dictionary<(int, int, int), bool>();

        var r1 = DFS(0, 0, 1, "");
        var r2 = DFS(0, 0, 2, "");

        return r1 || r2;

        bool DFS(int i1, int i2, int stringN, string currentString){ // i
            if((i1 == s1.Length && i2 == s2.Length) && currentString == s3){ 
                return true;
            }

            if(!s3.StartsWith(currentString)){
                return false;
            }

            bool res1 = false;
            bool res2 = false;
            
            if(cache.ContainsKey((i1, i2, stringN))){
                return cache[(i1, i2, stringN)];
            }

            if(stringN == 1){
                for(int i = i1; i < s1.Length; i++){
                    var newSubstring = s1[i1..(i + 1)];
                    var tempRes1 = DFS(i + 1, i2, 2, currentString + newSubstring);
                    if(tempRes1){
                        res1 = true;
                        break;
                    }
                }
            }
            
            if (stringN == 2) {
                for(int i = i2; i < s2.Length; i++){
                    var newSubstring = s2[i2..(i + 1)];
                    var tempRes2 = DFS(i1, i + 1, 1, currentString + newSubstring);
                    if(tempRes2){
                        res2 = true;
                        break;
                    }
                }
            }

            cache.Add((i1, i2, stringN), res1 || res2);

            return res1 || res2;
        }
    }
}