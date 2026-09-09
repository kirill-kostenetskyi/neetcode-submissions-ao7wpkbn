public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        var res = new List<int[]>();
        res.Add(intervals[0]);

        var i = 1;

        while(i < intervals.Length){
            var prevStart = res[^1][0];
            var prevEnd = res[^1][1];

            var currentStart = intervals[i][0];
            var currentEnd = intervals[i][1];

            if(prevEnd < currentStart){
                // no overlap
                res.Add(intervals[i]);
            } else {
                // overlap
                var mergedStart = Math.Min(currentStart, prevStart);
                var mergedEnd = Math.Max(currentEnd, prevEnd);
                res[^1] = new int[2]{ mergedStart, mergedEnd };
            }
            i++;
        }

        return res.ToArray();
    }
}