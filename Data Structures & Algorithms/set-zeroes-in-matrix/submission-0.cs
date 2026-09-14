public class Solution {
    public void SetZeroes(int[][] matrix) {
        var firstRowHasZero  = false;
        var firstColHasZero = false;
        for(int i = 0; i < matrix[0].Length; i++){
             if(matrix[0][i] == 0){
                firstRowHasZero  = true;
                break;
            }
        }

        for(int i = 0; i < matrix.Length; i++){
             if(matrix[i][0] == 0){
                firstColHasZero = true;
                break;
            }
        }

        for(int r = 1; r < matrix.Length; r++){
            for(int c = 1; c < matrix[0].Length; c++){
                if(matrix[r][c] == 0){
                    matrix[r][0] = 0;
                    matrix[0][c] = 0;
                }
            }
        }

        for(int r = 1; r < matrix.Length; r++){
            for(int c = 1; c < matrix[0].Length; c++){
                if(matrix[r][0] == 0){
                    matrix[r][c] = 0;
                }
                if(matrix[0][c] == 0){
                    matrix[r][c] = 0;
                }
            }
        }

        if(firstRowHasZero){
            Array.Fill(matrix[0], 0);
        }
        if(firstColHasZero){
            for(int r = 0; r < matrix.Length; r++){
                matrix[r][0] = 0;
            }
        }
    }
}