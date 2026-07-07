public class KthLargest {
    PriorityQueue<int, int> heap = null;
    int maxK = 0;
    public KthLargest(int k, int[] nums) {
        maxK = k;
        var newArray = nums.Select(x => (x, x)).ToArray();
        heap = new PriorityQueue<int, int>(newArray);

    }
    
    public int Add(int val) {
        heap.Enqueue(val, val);
        
        while(heap.Count != maxK){
            heap.Dequeue();
        }
        return heap.Peek();
    }
}
