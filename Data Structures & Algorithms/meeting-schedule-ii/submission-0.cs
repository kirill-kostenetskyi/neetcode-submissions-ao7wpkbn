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
    public int MinMeetingRooms(List<Interval> intervals) {
        var minHeap = new PriorityQueue<int, int>();

        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        foreach (var interval in intervals) {
            var start = interval.start;
            var end = interval.end;

            if (minHeap.Count > 0 && minHeap.Peek() <= start) {
                minHeap.Dequeue();
            }

            minHeap.Enqueue(end, end);
        }

        return minHeap.Count;
    }
}