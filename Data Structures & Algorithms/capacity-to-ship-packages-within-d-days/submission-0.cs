public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        var L = weights.Max();
        var R = weights.Sum();

        while(L <= R){
            var M = (L + R) / 2;
            var MDays = HowManyDays(M);
            if(MDays <= days){
                R = M - 1;
            } else {
                L = M + 1;
            }
        }
        
        return L;

        int HowManyDays(int capacity){
            var res = 0;
            var sum = 0;
            for(int i = 0; i < weights.Length; i++){
                sum = sum + weights[i];
                if(sum > capacity){
                    res++;
                    sum = weights[i];
                }
            }
            res++;
            return res;
        }
    }
}