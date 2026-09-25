public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var s = new Stack<(int Value, int Index)>();
        var res = new int[temperatures.Length];
        for(int i = 0; i < temperatures.Length; i++){
            while(s.Count > 0 && s.Peek().Value < temperatures[i]){
                var top = s.Pop();
                res[top.Index] = i - top.Index;
            }
            s.Push((temperatures[i], i));
        }
        return res;
    }
}