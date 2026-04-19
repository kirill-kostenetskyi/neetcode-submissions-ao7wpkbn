public class KthLargest {

    private PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
    private int k;
    public KthLargest(int k, int[] nums) {
        this.k = k;
        foreach(var n in nums){
            pq.Enqueue(n, n);
        }
        while(pq.Count > k){
            pq.Dequeue();
        }
    }
    
    public int Add(int val) {
        pq.Enqueue(val, val);
         while(pq.Count > k){
            pq.Dequeue();
        }
        var min = pq.Peek();
        return min;
    }
}