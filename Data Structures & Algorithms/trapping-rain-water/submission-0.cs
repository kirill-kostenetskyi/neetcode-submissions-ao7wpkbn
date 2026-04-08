public class Solution {
    public int Trap(int[] height) {
        var minLeft = new int[height.Count()];
        for(int i = 0; i < height.Count(); i++) {
            var leftMin = i == 0 ? 0 : minLeft[i - 1];
            var prevH = i == 0 ? 0 : height[i - 1];
            var min = Math.Max(leftMin, prevH);
            minLeft[i] = min;
        }

        var minRight = new int[height.Count()];
        for(int i = height.Count() - 1; i >= 0; i--) {
            var rightMin = i == height.Count() -1 ? 0 : minRight[i + 1];
            var nextH = i == height.Count() - 1 ? 0 : height[i + 1];
            var min = Math.Max(rightMin, nextH);
            minRight[i] = min;
        }

        var res = 0;

        for(int i = 0; i < height.Count(); i++) {
            var waterLevel = Math.Min(minLeft[i], minRight[i]) - height[i];
            waterLevel = waterLevel < 0 ? 0 : waterLevel;
            res = res + waterLevel;
        }

        return res;
    }
}