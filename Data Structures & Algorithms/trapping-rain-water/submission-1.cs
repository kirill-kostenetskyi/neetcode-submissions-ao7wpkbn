public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        var leftMax  = new int[n];
        for (int i = 0; i < n; i++) {
            var prevMax = i == 0 ? 0 : leftMax[i - 1];
            var prevH   = i == 0 ? 0 : height[i - 1];
            leftMax[i]  = Math.Max(prevMax, prevH);
        }

        var rightMax = new int[n];
        for (int i = n - 1; i >= 0; i--) {
            var nextMax = i == n - 1 ? 0 : rightMax[i + 1];
            var nextH   = i == n - 1 ? 0 : height[i + 1];
            rightMax[i] = Math.Max(nextMax, nextH);
        }

        int res = 0;
        for (int i = 0; i < n; i++) {
            int waterLevel = Math.Min(leftMax[i], rightMax[i]) - height[i];
            if (waterLevel > 0) res += waterLevel;
        }

        return res;
    }
}