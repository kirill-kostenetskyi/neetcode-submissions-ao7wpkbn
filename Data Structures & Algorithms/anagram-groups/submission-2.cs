public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        foreach(var s in strs){
            int[] letters = new int[100];

            foreach(var c in s){
                var letterIndex = c - 'a';
                letters[letterIndex] = letters[letterIndex] + 1;
            }

            var key = string.Join(",", letters);
            if(!dict.ContainsKey(key)){
                dict[key] = new List<string>(){ s };
            } else {
                var currentArray = dict[key];
                currentArray.Add(s);
                dict[key] = currentArray;
            }
        }

        var results = new List<List<string>>();
        foreach(var key in dict.Keys){
            results.Add(dict[key]);
        }

        return results;
    }
}