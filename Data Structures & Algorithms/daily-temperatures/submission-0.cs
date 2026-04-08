public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var res = new int[temperatures.Length];
        var stack = new Stack<(int Index, int Val)>{};

        for(int n = 0; n < temperatures.Length; n ++){
            if(n == 0){
                stack.Push((n, temperatures[n]));
            } else {
                var peeked = stack.Peek();
                while(peeked.Val < temperatures[n]){
                    var poped = stack.Pop();
                    res[poped.Index] = n - poped.Index;
                    if(stack.Count != 0){
                        peeked = stack.Peek();
                    } else {
                        break;
                    }
                }
                stack.Push((n, temperatures[n]));
            }
        }

        return res;
    }
}
