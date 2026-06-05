public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        List<string> duplciates = new List<string>();
        nums = nums.OrderBy(x=> x).ToArray(); 
        for(int i = 0; i < nums.Length; i++){
            var current = nums[i];

            var L = 0;
            var R = nums.Length - 1;
            while (L < R){
                if(L == i){
                    L++;
                    continue;
                }
                if(R == i){
                    R--;
                    continue;
                }

                var LNum = nums[L];
                var RNum = nums[R];
                var twoSum = LNum + RNum;
                if(current * -1 == twoSum){
                    var duplicatesEntity = new List<int>{ current, LNum, RNum };
                    duplicatesEntity = duplicatesEntity.OrderBy(x=> x).ToList();
                    var duplicatesString = string.Join(',', duplicatesEntity);
                    if(!duplciates.Contains(duplicatesString)){
                        result.Add(new List<int>{ current, LNum, RNum});
                        duplciates.Add(duplicatesString);
                    }
                    L++;
                    R--;
                } else if(current * -1 > twoSum){
                    L++;
                } else if(current * -1 < twoSum){
                    R--;
                }
            }
        }
        return result;
    }
}