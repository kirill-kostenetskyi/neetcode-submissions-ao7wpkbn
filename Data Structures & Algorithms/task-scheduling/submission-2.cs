public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var pq = new PriorityQueue<int, int>(nums.Select(x => (x, -x)).ToArray());
        while(k != 1){
            k--;
            pq.Dequeue();
        }
        return pq.Peek();
    }
}