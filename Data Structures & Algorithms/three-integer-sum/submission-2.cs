public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        var result = new List<List<int>>();
        var sNums = nums.OrderBy(x => x).ToArray();
        for(int i = 0; i < nums.Length; i++){
            if(i != 0 && sNums[i] == sNums[i - 1]){
                continue;
            }
            var l = i + 1;
            var r = sNums.Length - 1;
            while (l < r){
                var threeSum = sNums[i] + sNums[l] + sNums[r];
                if(threeSum > 0) {
                    r--;
                }
                else if (threeSum < 0) {
                    l++;
                } 
                else {
                    result.Add(new List<int>() {sNums[i], sNums[l], sNums[r]});
                    //JUST MAKE A HASHSET ON THE INTREVIEW. Space complexity will be slitly higher (+ O(N)) but easy to write and un destand
                    while (l < r && sNums[l] == sNums[l + 1]) l++;
                    while (l < r && sNums[r] == sNums[r - 1]) r--;

                    l++;
                    r--;              
                }
            }
        }
        return result;
    }
}
