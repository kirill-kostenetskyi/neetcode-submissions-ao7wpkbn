public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
      var d = new Dictionary<string, List<string>>();
      foreach (string s in strs){
        
        int[]arr = new int[26];
        foreach(char c in s){
            var numberRep = c - 'a';   
            arr[numberRep] = arr[numberRep] + 1; 
        }

        var key = string.Join(",", arr);
        if(!d.ContainsKey(key)){
            var l = new List<string>();
            l.Add(s);
            d[key] = l;
        } else {
            var currentList = d[key];
            currentList.Add(s);
        }
      }  
      List<List<string>> res = new List<List<string>>();
      foreach (var v in d.Values){
        res.Add(v);
      }
      return res;
    }
}