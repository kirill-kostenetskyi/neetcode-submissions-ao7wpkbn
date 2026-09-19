public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = new HashSet<int>(nums);
        var beginningList = new List<int>();
        foreach(var n in nums){
            // is beginning of sequence
            if(!set.Contains(n - 1)){
                beginningList.Add(n);
            }
        }
        var bestRes = 0;
        foreach(var b in beginningList){
            var res = 0;
            var sequenceCurrent = b;
            while(set.Contains(sequenceCurrent)){
                res++;
                sequenceCurrent++;
            }
            bestRes = Math.Max(res, bestRes);
        }
        return bestRes;
    }
}