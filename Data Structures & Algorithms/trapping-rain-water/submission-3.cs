public class Solution {
    public int Trap(int[] height) {
        var left = 0;
        var right = height.Count() - 1;

        var totalWater = 0;

        var maxLeft = height[left];
        var maxRight = height[right];

        while (left < right) 
        {
            if(maxLeft <= maxRight) {
                //shift left
                var wallHeight = Math.Min(maxLeft, maxRight);
                var water = wallHeight - height[left];
                water = water < 0 ? 0 : water;
                totalWater = totalWater + water;
                left++;
                maxLeft = maxLeft < height[left] ? height[left] : maxLeft;
            } else {
                // shift right
                var wallHeight = Math.Min(maxLeft, maxRight);
                var water = wallHeight - height[right];
                water = water < 0 ? 0 : water;
                totalWater = totalWater + water;
                right--;
                maxRight = maxRight < height[right] ? height[right] : maxRight;
            }     
        }
       
        return totalWater;
    }
}