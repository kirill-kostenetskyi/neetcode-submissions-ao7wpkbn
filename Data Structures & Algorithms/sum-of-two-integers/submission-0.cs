public class Solution {
    public int GetSum(int a, int b) {
        while(b != 0){
            var temp = a;
            a = a ^ b;
            b = (b & temp) << 1;
        } 
        return a;
    }
}
