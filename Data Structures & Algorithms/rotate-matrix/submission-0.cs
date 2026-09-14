public class Solution {
    public void Rotate(int[][] matrix) {
        for(int r = 0; r < matrix.Length; r++){
            for(int c = 0; c < matrix.Length; c++){
                if(r >= c){
                    continue;
                }
                var temp = matrix[r][c];
                matrix[r][c] = matrix[c][r];
                matrix[c][r] = temp;
            }
        }
        for(int r = 0; r < matrix.Length; r++){
            Array.Reverse(matrix[r]);
        }
        return;
    }
}