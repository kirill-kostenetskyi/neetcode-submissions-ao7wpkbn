public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var res = new List<int[]>();
        var newStart = newInterval[0];
        var newEnd = newInterval[1];

        var inserted = false;
        for(int i = 0; i < intervals.Length; i++){
            var currentStart = intervals[i][0];
            var currentEnd = intervals[i][1];

            if(newStart > currentEnd){
                // completely on the left
                res.Add(intervals[i]);
            } else if(newEnd < currentStart){
                // completely on the right
                if(inserted == false){
                    res.Add(newInterval);
                    inserted = true;
                }
                res.Add(intervals[i]);
            } else {
                //everything else overlap and should be merged
                newInterval[0] = Math.Min(currentStart, newInterval[0]);
                newInterval[1] = Math.Max(currentEnd, newInterval[1]);
            }
        }

        if(inserted == false){
            res.Add(newInterval);
        }

        return res.ToArray();
    }
}
