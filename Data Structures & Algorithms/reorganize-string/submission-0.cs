public class Solution {
    public string ReorganizeString(string s) {
        var sb = new StringBuilder();
        PriorityQueue<(char Letter, int Count), int> maxHeap;
        (char Letter, int Count) previous = (default, 0); 
        InitHeap();

        while(maxHeap.Count > 0){
            var heapTop = maxHeap.Dequeue();
            sb.Append(heapTop.Letter);

            var prevTemp = previous;
            previous.Letter = heapTop.Letter;
            previous.Count = heapTop.Count - 1;
            if(prevTemp.Count > 0){
                maxHeap.Enqueue((prevTemp.Letter, prevTemp.Count), prevTemp.Count);
            }
        }

        if(previous.Count > 0){
            return "";
        }

        return sb.ToString();

        void InitHeap(){
            var countMap = new Dictionary<char, int>();
            foreach(var c in s){
                if(countMap.TryGetValue(c, out int count)){
                    countMap[c] = count + 1;
                } else {
                    countMap[c] = 1;
                }
            }

            var heapifyArr = new List<(char Letter, int Count)>();
            foreach(var kv in countMap){
                heapifyArr.Add((kv.Key, kv.Value));
            }

            maxHeap = new PriorityQueue<(char Letter, int Count), int>(heapifyArr.Select(x => ((x.Letter, x.Count), x.Count)), Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }

    }
}