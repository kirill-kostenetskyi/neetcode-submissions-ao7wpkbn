public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var lowerOnRight = this.GetLowestIndeciesOnRight(heights);
        var lowerOnLeft = this.GetLowestIndeciesOnLeft(heights);
        var allAreas = this.CalculateAreas(heights, lowerOnRight, lowerOnLeft);
        
        var maxArea = 0;
        for(int i = 0; i < allAreas.Length; i++){
            var current = allAreas[i];
            if(current > maxArea){
                maxArea = current;
            }
        }
        return maxArea;
    }

    private int[] GetLowestIndeciesOnRight(int[] heights){
        var stack = new Stack<int>();
        var result = new int[heights.Length];
        for(int i = 0; i < heights.Length; i++){
            var current = heights[i];
            while(stack.Count > 0 && heights[stack.Peek()] > current){
                var poped = stack.Pop();
                result[poped] = i;
            }

            stack.Push(i);
        }

        if(stack.Count > 0) {
            while(stack.Count > 0) {
                var poped = stack.Pop();
                result[poped] = heights.Length; // TODO comment this
            }
        }
        return result;
    }

    private int[] GetLowestIndeciesOnLeft(int[] heights){
        var stack = new Stack<int>();
        var result = new int[heights.Length];
        for(int i = heights.Length - 1; i >= 0; i--){
            var current = heights[i];
            while(stack.Count > 0 && heights[stack.Peek()] > current){
                var poped = stack.Pop();
                result[poped] = i;
            }

            stack.Push(i);
        }

        if(stack.Count > 0) {
            while(stack.Count > 0) {
                var poped = stack.Pop();
                result[poped] = -1;
            }
        }
        return result;
    }

    private int[] CalculateAreas(int[] heights, int[] lowerOnRight, int[] lowerOnLeft){
        var result = new int[heights.Length];

        for(int i = 0; i < heights.Length; i++){
            var width = lowerOnRight[i] - lowerOnLeft[i] - 1;
            var area = width * heights[i];
            result[i] = area;
        }
        return result;
    }
}