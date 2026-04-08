public class Solution {
    public string MinWindow(string s, string t) {
        var L = 0;
        var R = 0;
        var tMap = new Dictionary<char, int>();
        var currentWindowMap = new Dictionary<char, int>();
        string output = null;
        // 1. shift left if zero matches;
        // 2. if at least one match shift right 
        // 3. if full match shift left until no match
        // 4. shift right up untill the end
        
        for(R = 0; R < t.Length; R++){
            if(!tMap.ContainsKey(t[R])){
                tMap[t[R]] = 1;
            } else {
                tMap[t[R]] = tMap[t[R]] + 1;
            } 
        }

        bool atLeastOneMatch = false;
        bool fullMatch = false;

        for(R = 0; R < s.Length; R++){
            if(!currentWindowMap.ContainsKey(s[R])){
                currentWindowMap[s[R]] = 1;
            } else {
                currentWindowMap[s[R]] = currentWindowMap[s[R]] + 1;
            } 
            //TODO: learn how to do it fast c#
            (atLeastOneMatch, fullMatch) = CompareMaps(
                tMap,
                currentWindowMap);
            if(fullMatch && (output == null || output.Length > R - L + 1)){
                output = s.Substring(L, R - L + 1);
            }
            while(fullMatch && L < R){
                currentWindowMap[s[L]] = currentWindowMap[s[L]] - 1;
                L++;

                (atLeastOneMatch, fullMatch) = CompareMaps(
                    tMap,
                    currentWindowMap);
                if(fullMatch && (output == null || output.Length > R - L + 1)){
                    output = s.Substring(L, R - L + 1);
                }
            }
        }
        
        R = s.Length - 1;
        (atLeastOneMatch, fullMatch) = CompareMaps(
                tMap,
                currentWindowMap);
        while(fullMatch && L < R){
            currentWindowMap[s[L]] = currentWindowMap[s[L]] - 1;
            L++;

            (atLeastOneMatch, fullMatch) = CompareMaps(
                tMap,
                currentWindowMap);
            if(fullMatch && (output == null || output.Length > R - L + 1)){
                output = s.Substring(L, R - L + 1);
            }
        }
        if(output == null){
            return "";
        }
        return output;
    }

    private (bool atLeastOne, bool fullMatch) CompareMaps(IDictionary<char, int> map1, IDictionary<char, int> map2){
        var atLeastOneMatch = false;

        foreach(var kvp in map1){
            var isPresented = map2.TryGetValue(kvp.Key, out int value);
            if(isPresented && value >= kvp.Value){
                atLeastOneMatch = true;
                continue;
            } else {
                if(kvp.Value == 0){
                    continue;
                }
                return (atLeastOneMatch, false);
            }
        }
        return (atLeastOneMatch, true);
    }
}
