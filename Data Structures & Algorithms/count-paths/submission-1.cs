public class Solution {
    public int UniquePaths(int m, int n) {
        var prevRow = new int[n];
        Array.Fill(prevRow, 1);

        var counter = m - 2;

        while(counter >= 0) {
            var currentRow = new int[n];
            currentRow[^1] = 1;
            for(int i = n - 2; i >= 0; i--){
                currentRow[i] = prevRow[i] + currentRow[i + 1];
            }
            prevRow = currentRow;
            counter--;
        } 
        return prevRow[0];
    }
}