public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var T = 0;
        var D = matrix.Length - 1;
        
        var row = -1;
        while(T <= D){
            var m = (T + D) / 2;
            var first = matrix[m][0];
            var last = matrix[m][^1];
            if(first > target){
                D = m - 1;
            } else if(last < target){
                T = m + 1;
            } else if(first <= target && last >= target){
                row = m;
                break;
            }
        }

        if(row == -1){
            return false;
        }

        var L = 0;
        var R = matrix[0].Length -1;

        while(L <= R){
            var m = (L + R) / 2;
            if(matrix[row][m] > target){
                R = m - 1;
            } else if(matrix[row][m] < target){
                L = m + 1;
            } else {
                return true;
            }
        }

        return false;
    }
}