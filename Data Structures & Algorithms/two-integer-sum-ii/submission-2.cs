public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var L = 0;
        var R = numbers.Length - 1;
        while(L < R){
            if(numbers[L] + numbers[R] > target){
                R--;
            } else if(numbers[L] + numbers[R] < target){
                L++;
            } else {
                return new int[2]{ L + 1, R + 1};
            }
        }
        return new int[2];
    }
}