public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int i = 0;
        int j = numbers.Length - 1;
        while(i != j){
            int r = numbers[i];
            int l = numbers[j];

            var sum = r + l;
            if(sum > target){
                j--;
            }
            else if (sum < target){
                i++;
            } 
            else {
                return new int[2] {i + 1, j + 1};
            }
        }
        return new int[2]{0, 0};
    }
}