public class Solution {
    public int ClimbStairs(int n) {
        if(n <= 0){
            return 0;
        }
        if(n == 1){
            return 1;
        }
        if(n == 2){
            return 2;
        }

        return ClimbStairs(n - 2) + ClimbStairs(n - 1);
    }
}