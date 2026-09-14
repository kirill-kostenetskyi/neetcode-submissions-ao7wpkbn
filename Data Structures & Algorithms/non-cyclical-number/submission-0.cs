public class Solution {
    public bool IsHappy(int n) {
        var visited = new HashSet<int>();
        while(n != 1){
            visited.Add(n);
            var sum = DigitSum(n);
            if(visited.Contains(sum)){
                return false;
            }
            n = sum;
        }

        return true;

        int DigitSum(int n){
            var res = 0;
            while(n != 0){
                var lastDigit = n % 10;
                n = n / 10;
                res = res + (int) Math.Pow(lastDigit, 2);
            }
            return res;
        }
    }
}