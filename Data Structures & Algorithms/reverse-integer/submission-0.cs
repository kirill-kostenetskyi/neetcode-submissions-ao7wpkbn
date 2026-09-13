public class Solution {
    public int Reverse(int x) {
        var res = 0;
        var maxIntExceptLast = int.MaxValue / 10;
        var maxIntLastDigit = int.MaxValue % 10;

        var minIntExceptLast = int.MinValue / 10;
        var minIntLastDigit = int.MinValue % 10;
        while(x != 0){
            var next = x % 10;
            x = x / 10;
            if((res > maxIntExceptLast || (res == maxIntExceptLast && next > maxIntLastDigit))
            || (res < minIntExceptLast || (res == minIntExceptLast && next < minIntLastDigit))){
                return 0;
            }
            res = res * 10 + next;
        }
        return res;
    }
}