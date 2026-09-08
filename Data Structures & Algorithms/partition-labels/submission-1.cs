public class Solution {
    public List<int> PartitionLabels(string s) {
        var dict = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++){
            var c = s[i];
            dict[c] = i;
        }

        int start = 0;
        int end = 0;
        var res = new List<int>();
        var groupSize = 0;
        for(int i = 0; i < s.Length; i++){
            start = i; // на самом деле не нужен
            end = Math.Max(dict[s[i]], end);
            groupSize = groupSize + 1;
            if(start == end){
                res.Add(groupSize);
                groupSize = 0;
            }
        }
        return res;
    }
}