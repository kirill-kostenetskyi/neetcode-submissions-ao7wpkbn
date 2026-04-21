public class Solution {

    private PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

    public int LastStoneWeight(int[] stones) {

        foreach(var stone in stones){
            pq.Enqueue(stone, -stone);
        }

        while(pq.Count > 1){
            var y = pq.Dequeue();
            var x = pq.Dequeue();
            var leftOver = y - x;
            if(leftOver > 0){
                pq.Enqueue(leftOver, -leftOver);
            }
        }

        if(pq.Count > 0){
            return pq.Peek();
        }

        return 0;
    }
}