public class Solution {
    public int LastStoneWeight(int[] stones) {
        var initArr = stones.Select(x => (x, x * -1)).ToArray();

        var heap = new PriorityQueue<int, int>(initArr);
        
        while(heap.Count > 1){
            var stone1 = heap.Dequeue();
            var stone2 = heap.Dequeue();
            if(stone1 > stone2){
                stone1 = stone1 - stone2;
                heap.Enqueue(stone1, -1 * stone1);
            }
        }

        return heap.Count > 0 ? heap.Peek() : 0;
    }
}