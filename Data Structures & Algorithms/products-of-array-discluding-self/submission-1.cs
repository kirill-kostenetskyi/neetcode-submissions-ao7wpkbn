public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var result = new int[nums.Length];
        var prefix = new int[nums.Length];
        var prefixProd = 1;
        for(int i = 0; i < nums.Length; i++){
            var current = nums[i];
            prefixProd = prefixProd * current;
            prefix[i] = prefixProd;
        }

        var sufix = new int[nums.Length];
        var sufixProd = 1;
        for(int i = nums.Length - 1; i >= 0; i--){
            var current = nums[i];
            sufixProd = sufixProd * current;
            sufix[i] = sufixProd;
        }

        for(int i = 0; i < nums.Length; i++){
            var prodBefore = i > 0 ? prefix[i - 1] : 1;
            var prodAfter = i < nums.Length - 1 ? sufix[i + 1] : 1;
            result[i] = prodBefore * prodAfter;
        }

        return result;
    }
}