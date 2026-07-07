public class MedianFinder {
    private PriorityQueue<int, int> leftHeap = null;
    private PriorityQueue<int, int> rightHeap = null;
    public MedianFinder() {
        leftHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        rightHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        var leftTop = leftHeap.Count > 0 ? leftHeap.Peek() : int.MinValue;
        var rightTop = rightHeap.Count > 0 ? rightHeap.Peek() : int.MinValue;
        if(leftTop == int.MinValue){
            leftHeap.Enqueue(num, num);
        }
        else if(num > leftTop && rightTop != int.MinValue){
            rightHeap.Enqueue(num, num);
        } else {
            leftHeap.Enqueue(num, num);
        }

        while(leftHeap.Count - rightHeap.Count > 1) {
            var tLeft = leftHeap.Dequeue();
            rightHeap.Enqueue(tLeft, tLeft);
        }
        while(rightHeap.Count - leftHeap.Count > 0) {
            var tRight = rightHeap.Dequeue();
            leftHeap.Enqueue(tRight, tRight);
        }
    }
    
    public double FindMedian() {
        if(leftHeap.Count > rightHeap.Count){
            return leftHeap.Peek();
        } else {
            var tLeft = leftHeap.Count > 0 ? leftHeap.Peek() : 0;
            var tRight = rightHeap.Count > 0 ? rightHeap.Peek() : 0;
            return ((double)(tLeft + tRight)) / 2;
        }
    }
}
