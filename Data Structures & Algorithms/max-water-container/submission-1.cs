public class Solution {
    public int MaxArea(int[] height) {
      int l = 0;
      int r = height.Length - 1;
      int maxAmount = 0;
      while (l < r) {
        var lowestSide = Math.Min(height[l], height[r]);
        var distance = r - l;
        var amount = lowestSide * distance; 
        if(amount > maxAmount){
            maxAmount = amount;
        }

        if(height[l] > height[r]){
            r--;
        } else if(height[r] > height[l]){
            l++;
        } else {
            // equal
            r--;
            l++;
        }
      } 

      return maxAmount; 
    }
}