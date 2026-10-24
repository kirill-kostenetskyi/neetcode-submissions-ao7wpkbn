public class Solution {
    public int LastStoneWeight(int[] stones) {
        var pq = new PriorityQueue<int, int>(stones.Select(x => (x, x)), Comparer<int>.Create((a, b) => b.CompareTo(a)));

        while(pq.Count >= 2){
            var y = pq.Dequeue();
            var x = pq.Dequeue();
            if(x != y){
                pq.Enqueue(y - x, y - x);
            }
        }
        if(pq.Count == 1){
            return pq.Peek();
        }
        return 0;
    }
}