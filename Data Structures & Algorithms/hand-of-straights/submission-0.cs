public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize > 0){
            return false;
        }
        var dict = new Dictionary<int, int>();
        foreach(var c in hand){
            dict[c] = dict.GetValueOrDefault(c) + 1;
        }

        Array.Sort(hand);

        foreach(var c in hand){
            var groupStart = c;
            if(dict[groupStart] == 0){
                continue;
            }
            for(int i = 1; i <= groupSize; i++){
                    if(!dict.ContainsKey(groupStart)){
                        return false;
                    }
                    var availableCount = dict[groupStart];
                    if(availableCount > 0){
                        dict[groupStart]--;
                    } else {
                        return false;
                    }
                    groupStart++;
                }            
        }

        return true;
    }
}