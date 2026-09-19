public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var prefixBefore = new int[nums.Length];
        var prefixAfter = new int[nums.Length];
        Array.Fill(prefixBefore, 1);
        Array.Fill(prefixAfter, 1);
        var before = 1;
        var after = 1;
        for(int i = 1; i < nums.Length; i++){
            before = before * nums[i - 1];
            prefixBefore[i] = before;
        }
        for(int i = nums.Length - 2; i >= 0; i--){
            after = after * nums[i + 1];
            prefixAfter[i] = after;
        }
        var result = new int[nums.Length];
        for(int i = 0; i < nums.Length; i++){
            result[i] = prefixAfter[i] * prefixBefore[i];
        }
        return result;
    }
}