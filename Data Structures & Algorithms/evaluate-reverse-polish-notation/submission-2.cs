public class Solution {
    public int EvalRPN(string[] tokens) {
        var s = new Stack<int>();
        foreach(var t in tokens){
            if(int.TryParse(t, out var i)){
                s.Push(int.Parse(t));
            } else {
                var second = s.Pop();
                var first = s.Pop();
                if(t == "+"){
                    s.Push(first + second);
                } else if (t == "-"){
                    s.Push(first - second);
                } else if (t == "*"){
                    s.Push(first * second);
                } else if (t == "/"){
                    s.Push(first / second);
                }
            }
        }
        return s.Pop();
    }
}