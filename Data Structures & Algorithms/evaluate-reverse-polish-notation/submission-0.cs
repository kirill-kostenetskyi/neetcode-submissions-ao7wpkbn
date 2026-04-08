public class Solution {
    public int EvalRPN(string[] tokens) {
        var s = new Stack<int>();
        var operations = new HashSet<string>(){ "*", "/", "+", "-"};
        foreach(var token in tokens) {
            var isOperation = operations.Contains(token);
            if(isOperation){
                var second = s.Pop();
                var first = s.Pop();
                if(token == "+"){
                    s.Push(first + second);
                }
                if(token == "-"){
                    s.Push(first - second);
                }
                if(token == "*"){
                    s.Push(first * second);
                }
                if(token == "/"){
                    s.Push(first / second);
                }
            } 
            else {
                s.Push(int.Parse(token));
            }
        }
        return s.Pop();
    }
}