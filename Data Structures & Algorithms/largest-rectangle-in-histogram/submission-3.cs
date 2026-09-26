public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var s = new Stack<(int Index, int StartIndex)>(); // index
        var rightWall = new int[heights.Length];
        var leftWall = new int[heights.Length];
        s.Push((0, -1));

        for(int i = 1; i < heights.Length; i++){
            if(s.Count > 0 && heights[s.Peek().Index] > heights[i]){
                var lastStartIndex = 0;
                while(s.Count > 0 && heights[s.Peek().Index] > heights[i]){
                    var top = s.Pop();
                    rightWall[top.Index] = i;
                    leftWall[top.Index] = top.StartIndex;
                    lastStartIndex = top.StartIndex;
                }
                s.Push((i, lastStartIndex));
            } else {
                s.Push((i, i - 1));
            }
        }

        if(s.Count > 0){
            while(s.Count > 0){
                var top = s.Pop();
                rightWall[top.Index] = heights.Length;
                leftWall[top.Index] = top.StartIndex;
            }
        }

        var areas = new int[heights.Length];
        for(int i = 0; i < heights.Length; i++){
            areas[i] = (rightWall[i] - leftWall[i] - 1) * heights[i];
        }

        return areas.Max();
    }
}