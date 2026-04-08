public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var map = new Dictionary<char, int>();
        var s1Map = new Dictionary<char, int>();
        var L = 0;
        for(int i = 0; i < s1.Length; i++){
            if(s1Map.ContainsKey(s1[i])){
                s1Map[s1[i]] = s1Map[s1[i]] + 1; 
            } else {
                s1Map[s1[i]] = 1;
            }
        }

        for(int R = 0; R < s2.Length; R++){
            if(map.ContainsKey(s2[R])){
                map[s2[R]] = map[s2[R]] + 1; 
            } else {
                map[s2[R]] = 1;
            }

            while(R - L + 1 > s1.Length){
                map[s2[L]] = map[s2[L]] - 1; 
                L++;
            }

            var isMatched = IsMapMatched(s1Map, map);
            if(isMatched){
                return true;
            }
        }

        return false;
    }

    private bool IsMapMatched(Dictionary<char, int> map1, Dictionary<char, int> map2){
        foreach(var kvp in map1){
            if(kvp.Value == 0){
                continue;
            }
            if(map2.ContainsKey(kvp.Key)){
                if(map2[kvp.Key] != kvp.Value){
                    return false;
                }
            } else {
                return false;
            }
        }
        return true;
    }
}