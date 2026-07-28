public class Solution {
    public int OpenLock(string[] deadends, string target) {
        if(deadends.Contains("0000")){
            return -1;
        }

        if (target == "0000")
            return 0;

        var q = new Queue<string>();
        var deadendsHash = new HashSet<string>(deadends);
        var calculated = new HashSet<string>();

        q.Enqueue("0000");
        var counter = 0;
        while(q.Count() > 0){
            var currentQueueSize = q.Count;

            counter++;
            var nextQueueChunk = new List<string>();
            for(int i = 0; i < currentQueueSize; i++){
                var wheel = q.Dequeue();
                var wheelArray = wheel.Select(x => x - '0').ToArray();
                
                for(int j = 0; j < 8; j++){
                    var wheelArrayCopy = wheelArray.ToArray();
                    if(j >= 0 && j <= 3){
                        wheelArrayCopy[j] = wheelArrayCopy[j] + 1;
                        if(wheelArrayCopy[j] == 10){
                           wheelArrayCopy[j] = 0; 
                        }
                    } else {
                        wheelArrayCopy[j - 4] = wheelArrayCopy[j - 4] - 1;
                        if(wheelArrayCopy[j- 4] == -1){
                           wheelArrayCopy[j- 4] = 9; 
                        }
                    }
                    var newWheenString = string.Join("", wheelArrayCopy);
                    if(calculated.Contains(newWheenString)){
                        continue;
                    }
                    if(newWheenString == target){
                        return counter;
                    }
                    if(!deadendsHash.Contains(newWheenString)){
                        q.Enqueue(newWheenString);
                        calculated.Add(newWheenString);
                    }
                }
            }
        }
        return -1;
    }
}