public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var s = new Stack<int>(); // index
        var rightWall = new int[heights.Length];
        var leftWall = new int[heights.Length];

        for(int i = 0; i < heights.Length; i++){
            while(s.Count > 0 && heights[s.Peek()] > heights[i]){
                var top = s.Pop();
                rightWall[top] = i;
            }
            s.Push(i);
        }

        if(s.Count > 0){
            while(s.Count > 0){
                var top = s.Pop();
                rightWall[top] = heights.Length;
            }
        }

        s = new Stack<int>();
        for(int i = heights.Length - 1; i >= 0; i--){
            while(s.Count > 0 && heights[s.Peek()] > heights[i]){
                var top = s.Pop();
                leftWall[top] = i;
            }
            s.Push(i);
        }

        if(s.Count > 0){
            while(s.Count > 0){
                var top = s.Pop();
                var res = -1;
                leftWall[top] = res;
            }
        }

        var areas = new int[heights.Length];
        for(int i = 0; i < heights.Length; i++){
            areas[i] = (rightWall[i] - leftWall[i] - 1) * heights[i];
        }

        return areas.Max();
    }
}