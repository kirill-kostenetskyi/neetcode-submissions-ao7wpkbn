public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        if(piles.Length > h){
            return 0;
        }

        var L = 1;
        var R = piles.Max();
        var bestSpeed = piles.Max();
        
        while (L <= R){
            var M = (R - L) / 2 + L; // speed
            var time = CalculateTime(M);
            if(time <= h) {
                if(M < bestSpeed){ // non neccessary if but it makes things clear for me
                    bestSpeed = M;
                }
                R = M - 1;
            } else {
                L = M + 1;
            }
        }

        return bestSpeed;

        long CalculateTime(int speed){
            long res = 0;
            foreach(var pile in piles){
                var isLeftOver = pile % speed > 0 ? true : false;
                res = res + (pile / speed);
                if(isLeftOver){
                    res = res + 1;
                }
            }
            return res;
        }
    }
}