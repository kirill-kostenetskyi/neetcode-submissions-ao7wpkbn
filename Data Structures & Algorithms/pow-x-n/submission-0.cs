public class Solution {
    public double MyPow(double x, int n) {
        if(n == 0){
            return 1;
        }
        if(x == 0){
            return 0;
        }
        if(x == 1){
            return 1;
        }
        var res = Pow(x, Math.Abs((long)n));
        if(n < 0){
            return 1 / res;
        } else {
            return res;
        }

        double Pow(double x, long n){
            if(n == 0){
                return 1;
            }
            var res = Pow(x, n / 2);
            res = res * res;
            if(n % 2 == 1){
                res = res * x;
            }
            return res;
        }
    }
}