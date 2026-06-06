public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var res = new List<int>();
        var L = 0;
        var R = numbers.Length - 1;
        while(L < R){
            var twoSum = numbers[L] + numbers[R];
            if(twoSum == target){
                res.Add(L + 1);
                res.Add(R + 1);
                return res.ToArray();
            }
            if(twoSum < target){
                L++;
            }
             if(twoSum > target){
                R--;
            }
        }
        return res.ToArray();
    }
}