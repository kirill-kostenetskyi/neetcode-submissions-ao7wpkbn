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
            if(stack.Count > 0){
                var peeked = stack.Peek();
                if(!d.ContainsKey(s[i]) || peeked != d[s[i]]){
                    stack.Push(s[i]);
                } else {
                    // mirrored
                    stack.Pop();
                }
            } else {  
                  stack.Push(s[i]);
            }
        }
        if(stack.Count() == 0){
            return true;
        } else {
            return false;
        }
    }
}