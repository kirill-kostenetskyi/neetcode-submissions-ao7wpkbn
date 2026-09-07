public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        var prefix = 0;
        var minPrefix = 0;
        var start = 0;

        for(int i = 0; i < gas.Length; i++){
            prefix += gas[i] - cost[i];
            if(prefix < minPrefix){
                minPrefix = prefix;
                start = i + 1;
            }
        }

        if(prefix < 0){
            return -1;
        }
        
        if(start == gas.Length){
            return 0;
        } else {
            return start;
        }
    }
}