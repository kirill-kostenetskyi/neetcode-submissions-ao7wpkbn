public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var m = matrix.Length; // rows count
        var n = matrix[0].Length; // column count

        var top = 0;
        var bottom = m - 1;
        var targetRowIndex = -1;
        while(top <= bottom){
            var first = 0;
            var last = n - 1;
            var middleRowIndex = (top + bottom) / 2;
            if(matrix[middleRowIndex][last] < target){
                top = middleRowIndex + 1;
            }
            else if(matrix[middleRowIndex][first] > target){
                bottom = middleRowIndex - 1;
            }
            else {
                targetRowIndex = middleRowIndex;
                break;
            }
        }

        if(targetRowIndex == -1){
            return false;
        }

        int[] targetRow = matrix[targetRowIndex];

        var left = 0;
        var right = targetRow.Length - 1;

        while(left <= right){
            var pointer = (left + right) / 2;
            if(targetRow[pointer] < target){
                left = pointer + 1;
            }
            if(targetRow[pointer] > target){
                right = pointer -1;
            }
            if(targetRow[pointer] == target) {
                return true;
            }
        }

        return false;
    }
}