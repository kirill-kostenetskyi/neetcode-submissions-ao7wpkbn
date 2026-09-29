public class Solution {
    public int Trap(int[] height) {
        var rightMax = new int[height.Length];
        var leftMax = new int[height.Length];

        var bestLeftMax = height[0];
        for(int i = 0; i < height.Length - 1; i++){
            bestLeftMax = Math.Max(bestLeftMax, height[i]);
            leftMax[i] = bestLeftMax;
        }

        var bestRightMax = height[^1];
        for(int i = height.Length - 1; i >= 0; i--){
            bestRightMax = Math.Max(bestRightMax, height[i]);
            rightMax[i] = bestRightMax;
        }

        var res = 0;
        for(int i = 0; i < height.Length - 1; i++){
            var lowerSide = Math.Min(leftMax[i], rightMax[i]);
            if(lowerSide == 0){
                continue;
            }

            var water = lowerSide - height[i];
            res += water;
        }

        return res;
    }
}