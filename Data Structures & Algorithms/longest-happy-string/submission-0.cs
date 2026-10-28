public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        var sb = new StringBuilder();
        PriorityQueue<(char Letter, int Count), int> maxHeap;

        PushLettersToTheHeap();
        while(maxHeap.Count > 0){
            var heapTop = maxHeap.Dequeue();
            char prevPrevLetter = sb.Length > 1 ? sb[^2] : default;
            char prevLetter = sb.Length > 0 ? sb[^1] : default;

            var tempHeapTop = heapTop;

            if(prevLetter == heapTop.Letter && prevPrevLetter == heapTop.Letter){
                if(maxHeap.Count > 0){
                    heapTop = maxHeap.Dequeue();
                    sb.Append(heapTop.Letter);
                    maxHeap.Enqueue((tempHeapTop.Letter, tempHeapTop.Count), tempHeapTop.Count);
                } else {
                    break;
                }
            } else {
                sb.Append(heapTop.Letter);
            }

            var newCount = heapTop.Count - 1;
            if(newCount > 0){
                maxHeap.Enqueue((heapTop.Letter, newCount), newCount);
            }
        }
        
        return sb.ToString();

        void PushLettersToTheHeap(){
            var heapifyArr = new List<(char Letter, int Count)>();
            if(a > 0){
                heapifyArr.Add(('a', a));
            }            
            if(b > 0){
                heapifyArr.Add(('b', b));
            }            
            if(c > 0){
                heapifyArr.Add(('c', c));
            }
            maxHeap = new PriorityQueue<(char Letter, int Count), int>(heapifyArr.Select(x => ((x.Letter, x.Count), x.Count)), Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }
    }
}