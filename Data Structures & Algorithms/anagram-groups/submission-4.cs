public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, List<string>>();
        foreach(var s in strs){
            var countArr = new int[26];
            foreach(var c in s){
                var index = c - 'a';
                countArr[index]++;
            }
            var key = string.Join(",", countArr);
            if(dict.TryGetValue(key, out var list)){
                list.Add(s);
            } else {
                dict[key] = new List<string>(){ s };
            }
        }
        
        List<List<string>> result = new List<List<string>>();
        foreach(var kv in dict){
            var curentList = kv.Value;
            result.Add(curentList.ToList());
        }
        return result;
    }
}