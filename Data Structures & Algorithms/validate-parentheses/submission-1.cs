public class Solution {
    public bool IsValid(string s) {
        // "([{}])"
        // "[(])"
        // "[]"
        var d = new Dictionary<char, char>();
        d[']'] = '[';
        d[')'] = '(';
        d['}'] = '{';
        var stack = new Stack<char>();
        for(int i=0; i < s.Length; i++){
            if(d.ContainsKey(s[i])){
                // close character
                if(stack.Count == 0 || stack.Pop() != d[s[i]]){
                   return false;
                } 
            } else {
               // open character
                stack.Push(s[i]);
            }
        }

        if(stack.Count() == 0 && s.Length > 1){
            return true;
        } else {
            return false;
        }
    }
}
