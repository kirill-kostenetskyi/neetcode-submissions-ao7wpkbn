public class Solution {    
    public string MinWindow(string s, string t) {
        var L = 0;
        var R = 0;
        var already = 0;
        var expected = t.Length;
        var mapT = new Dictionary<char, int>();
        var mapS = new Dictionary<char, int>();
        string output = "";
        int outputLength = int.MaxValue;
        
        for(R = 0; R < t.Length; R++){
            if(!mapT.ContainsKey(t[R])){
                mapT[t[R]] = 1;
            } else {
                mapT[t[R]] = mapT[t[R]] + 1;
            } 
        }

        for(R = 0; R < s.Length; R++){
            if(mapT.ContainsKey(s[R])){
                var mapSNewVal = increaseByOne(mapS, s[R]);
                if(mapSNewVal <= mapT[s[R]]){
                    already += 1;
                }
            }

            while(already == expected){
                var currentL = s[L];
                if(L==5 && R == 10){

                }
                if(mapT.ContainsKey(s[L])){
                    var mapSNewVal = decreaseByOne(mapS, s[L]);
                    if(mapSNewVal < mapT[s[L]]){
                        already -= 1;
                    }
                }

                if(outputLength > R - L + 1){
                    output = s.Substring(L, R - L + 1);
                    outputLength = output.Length;
                }

                L++;
            }

        }
            
        return output;
    }

    private int increaseByOne(Dictionary<char, int> map, char C){
         if(map.ContainsKey(C)){
            map[C] += 1;
        } else {
            map[C] = 1;
        }
        return map[C];    
    }

    private int decreaseByOne(Dictionary<char, int> map, char C){
        if(map.ContainsKey(C)){
            map[C] += -1;
        } else {
            map[C] = 0;
        }
        return map[C];    
    }
}
