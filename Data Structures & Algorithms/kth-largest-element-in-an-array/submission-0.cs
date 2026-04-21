public class Solution {

    private PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

    public int FindKthLargest(int[] nums, int k) {
        foreach(var n in nums){
            pq.Enqueue(n,n);
        }

        while(pq.Count > k){
            pq.Dequeue();
        }

        return pq.Peek();
    }
}