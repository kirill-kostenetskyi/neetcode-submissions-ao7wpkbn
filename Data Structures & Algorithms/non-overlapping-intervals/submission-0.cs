public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        var prevStart = intervals[0][0]; // на самом деле лишняя переменая. хз зачем оставил
        var prevEnd = intervals[0][1];

        var res = 0;

        for(int i = 1; i < intervals.Length; i++){
            var currentStart = intervals[i][0];
            var currentEnd = intervals[i][1];

            if(currentStart >= prevEnd){
                prevStart = currentStart;
                prevEnd = currentEnd;
            } else {
                if(prevEnd < currentEnd){
                    // keep prev;
                } else {
                    // better replace with shorter tail one
                    prevStart = currentStart;
                    prevEnd = currentEnd;
                }
                res++;
            }
        }

        return res;
    }
}