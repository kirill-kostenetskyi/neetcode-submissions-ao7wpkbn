public class Solution {
    public int MinOperations(string s) {
        int currentCounter = 0;
        int minCounter = int.MaxValue;

        char prev = '1';
        foreach(var c in s){
            if(prev == c){
                currentCounter++;
                prev = c == '1' ? '0' : '1';
            } else {
                prev = c;
            }
        }
        minCounter = Math.Min(minCounter, currentCounter);

        currentCounter = 0;
        prev = '0';
        foreach(var c in s){
            if(prev == c){
                currentCounter++;
                prev = c == '1' ? '0' : '1';
            } else {
                prev = c;
            }
        }
        minCounter = Math.Min(minCounter, currentCounter);

        return minCounter;

    }
}