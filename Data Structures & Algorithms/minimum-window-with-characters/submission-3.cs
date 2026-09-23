public class Solution {
    public string MinWindow(string s, string t) {
        if(t.Length > s.Length){
            return "";
        }
        var tFreq = new int[128];
        var wFreq = new int[128];

        for(int i = 0; i < t.Length; i++){
            var charCode = t[i];
            tFreq[charCode]++;
        }
        var result = int.MaxValue;
        var L = 0;
        var resL = 0;
        var resR = 0;

        for(int R = 0; R < s.Length; R++){
            wFreq[s[R]]++;

            if(IsWindowsValid() == false) {
                continue;
            }
            while(L <= R && IsWindowsValid()){
                if(R - L + 1 < result){
                    result = R - L + 1;
                    resL = L;
                    resR = R;
                }
                wFreq[s[L]]--;
                L++;
            }
        }
        if(result == int.MaxValue){
            return "";
        }

        return s[resL..(resR + 1)];

        bool IsWindowsValid(){
            for(int i = 0; i < 128; i++){
                if(tFreq[i] != 0 && wFreq[i] < tFreq[i]){
                    return false;
                }
            }
            return true;
        }
    }
}