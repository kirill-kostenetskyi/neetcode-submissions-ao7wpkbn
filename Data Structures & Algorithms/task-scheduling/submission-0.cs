public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var t = 1;
        // var resultString = "";
        var resCount = 0;
        PriorityQueue<(char Letter, int Count), int> maxHeap;
        var queue = new Queue<(char Letter, int Count, int AvailableAt)>();

        var letterCount = new Dictionary<char, int>();
        CountLetters();
        PushLettersToTheHeap();

        while(queue.Count > 0 || maxHeap.Count > 0){
            if(queue.Count > 0 && queue.Peek().AvailableAt <= t){
                var qTop = queue.Dequeue();
                maxHeap.Enqueue((qTop.Letter, qTop.Count), qTop.Count);
            }

            if(maxHeap.Count > 0){
                var heapTop = maxHeap.Dequeue();

                // resultString += heapTop.Letter;
                resCount++;
                var newCount = heapTop.Count - 1;
                var newAvalableAt = t + n + 1;
                if(newCount > 0){
                    queue.Enqueue((heapTop.Letter, newCount, newAvalableAt));
                }
            } else {
                // resultString += "_";
                resCount++;
            }
            t++;
        }

        // return resultString.Length;
        return resCount;

        void CountLetters(){
            foreach(var t in tasks){
                if(letterCount.TryGetValue(t, out var count)){
                    letterCount[t] += 1;
                } else {
                    letterCount[t] = 1;
                }
            }
        }

        void PushLettersToTheHeap(){
            var heapifyArr = new List<(char Letter, int Count)>();
            foreach(var kv in letterCount){
                heapifyArr.Add((kv.Key, kv.Value));
            }
            maxHeap = new PriorityQueue<(char Letter, int Count), int>(heapifyArr.Select(x => ((x.Letter, x.Count), x.Count)), Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }
    }
}