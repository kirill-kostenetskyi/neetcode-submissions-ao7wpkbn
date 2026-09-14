public class Solution {
    public int[] PlusOne(int[] digits) {
        var carry = 1;
        for(int i = digits.Length - 1; i >= 0; i--){
            var sum = digits[i] + carry;
            if(sum == 10){
                digits[i] = 0;
                carry = 1;
            } else {
                digits[i] = sum;
                carry = 0;
            }
        }
        if(carry == 1){
            var res = new int[digits.Length + 1];
            res[0] = 1;
            return res;
        }
        return digits;
    }
}