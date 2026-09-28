public class Solution {
    public int MaxArea(int[] height) {
        var L = 0;
        var R = height.Length - 1;
        var maxArea = 0;
        while(L < R){
            maxArea = Math.Max(maxArea, (R - L) * Math.Min(height[R], height[L]));
            if(height[L] < height[R]){
                L++;
            } else {
                R--;
            }
        }
        return maxArea;
    }
}