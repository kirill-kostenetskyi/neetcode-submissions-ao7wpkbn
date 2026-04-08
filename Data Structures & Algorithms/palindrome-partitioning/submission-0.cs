public class Solution {
    List<List<string>> result = new List<List<string>>();
    string initStr = "";
    public List<List<string>> Partition(string s) {
        this.initStr = s;
        
        BackTrack(new List<string>(), "", s);
        return result;
    }

    private void BackTrack(List<string> path, string currentStr, string leftOver){
        if(currentStr.Length == initStr.Length){
            if(path.Count() > 0){
                result.Add(path);
            }
            
            return;
        }
        var loopLimit = leftOver.Count();
        for(int i = 0; i < loopLimit; i++){
            var subStr = leftOver.Substring(0, i + 1);
            var newLeftOver = leftOver.Substring(i + 1);
            var oldLeftOver = leftOver;
            path.Add(subStr);

            var firstHalfStr = currentStr + subStr;
            if(IsPalindrome(subStr)){
                BackTrack(path.ToList(), firstHalfStr, newLeftOver);
            }

            path.RemoveAt(path.Count() - 1);
            leftOver = oldLeftOver;
        }

    }
    
    private bool IsPalindrome(string s){
        var start = 0;
        var end = s.Count() - 1;

        do{
            if(s[start] != s[end]){
                return false;
            }
            start++;
            end--;
        }
        while(start != end && start > 0 && end > 0);
        
        return true;
    }
    
}