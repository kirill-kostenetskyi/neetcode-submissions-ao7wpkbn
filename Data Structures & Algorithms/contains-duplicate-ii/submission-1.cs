public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var hashSet = new HashSet<int>(); //1, 2, 3

        var R = 0;
        var L = 0;

        while(R != nums.Length){
            var headVal = nums[R]; // 3
            if(hashSet.Contains(headVal)){
                return true;
            }
            hashSet.Add(headVal);
            R++; // 3
            
            if((R - L) == k + 1){
                var tailVal = nums[L];
                hashSet.Remove(tailVal);
                L++;
            }
        }
        return false;
    }
}