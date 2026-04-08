public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var res = new int[temperatures.Length];
        var stack = new Stack<(int Index, int Val)>{};

        for(int n = 0; n < temperatures.Length; n ++){
            if(n == 0){
                stack.Push((n, temperatures[n]));
            } else {
                var top = stack.Peek();
                while(top.Val < temperatures[n]){
                    var popped = stack.Pop();
                    res[popped.Index] = n - popped.Index;
                    if(stack.Count != 0){
                        top = stack.Peek();
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
