public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if(s1.Length > s2.Length){
            return false;
        }
        var s1A = new int[26];
        var s2A = new int[26];
        for(int i = 0; i < s1.Length; i++){
            var nChar = s1[i] - 'a';
            s1A[nChar]++;
        }
        
        var L = 0;

        for(int R = 0; R < s2.Length; R++){
            var rChar = s2[R] - 'a';
            s2A[rChar]++;
            if(R - L + 1 < s1.Length){
                continue;
            }
            while(R - L + 1 > s1.Length){
                var lChar = s2[L] - 'a';
                s2A[lChar]--;
                L++;
            }

            if(CompareArr()){
                return true;
            }
        }

        return false;

        bool CompareArr(){
            for(int i = 0; i < s1A.Length; i++){
                if(s1A[i] != s2A[i]){
                    return false;
                }
            }
            return true;
        }
    }
}