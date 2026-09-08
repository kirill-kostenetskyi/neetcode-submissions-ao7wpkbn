/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */
public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        //intervals = intervals.OrderBy(x => x[0]).ToArray();
        // не могу запомнить написание кастомного компарера 
        intervals.Sort((a, b) => a.start.CompareTo(b.start));
        var prevEnd = -1;
        foreach(var interval in intervals){
            var start = interval.start;
            var end = interval.end;
            if(start < prevEnd){
                return false;
            }
            prevEnd = end;
        }
        return true;
    }
}
