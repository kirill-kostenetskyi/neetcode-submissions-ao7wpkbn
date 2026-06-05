public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {

        var startSpeed = 1;
        var maxSpeed = piles.Max();
        var L = startSpeed;
        var R = maxSpeed;

        while(L <= R){
            var M = (L + R) / 2; // current speed
            var MHours = GetHours(M); // how many hours need to finish all
            if(Ok(MHours, M)){
                R = M - 1;
            } else {
                L = M + 1;
            }
        }

        return L;

        bool Ok(int MHours, int M){
            // true -> we can try to reduce speed more. Reason: already fit H (less than H)
            // false -> we out of range already, need to speed up. Reason: Spend MORE hours to finish than we have
            if(MHours < h){
                return true;
            } else if (MHours > h) {
                return false;
            } else if(MHours == h){
                return true;
            }
            return false;
        }

        int GetHours(int speed){
            int res = 0;
            foreach(var p in piles){
                var leftOver = p % speed;
                var n = p / speed;
                if(leftOver > 0){
                    n = n + 1;
                }
                res = res + n;
            }
            return res;
        }
    }

}