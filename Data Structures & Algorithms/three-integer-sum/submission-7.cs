public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        List<List<int>> res = new List<List<int>>();
        var hashRes = new HashSet<(int, int, int)>();
        for(int i = 0; i < nums.Length; i++){
            var pairRes = FindPair(i);
            foreach(var singlePair in pairRes){
                var pairs = new int[3]{nums[singlePair.Item1], nums[singlePair.Item2], nums[i]};
                Array.Sort(pairs);
                hashRes.Add((pairs[0], pairs[1], pairs[2]));
            }
        }

        foreach(var i in hashRes){
            res.Add(new List<int>(){ i.Item1,i.Item2,i.Item3 });
        }

        return res;

        List<(int, int)> FindPair(int targetIndex){
            var res = new List<(int, int)>();
            var L = 0;
            var R = nums.Length - 1;
            var target = nums[targetIndex] * -1;
            if(L == targetIndex){
                L++;
            } 
            if(R == targetIndex){
                R--;
            }
            
            while(L < R){
                if(L == targetIndex){
                    L++;
                    continue;
                }
                if(R == targetIndex){
                    R--;
                    continue;
                }

                if(nums[L] + nums[R] > target){
                    R--;
                } else if(nums[L] + nums[R] < target){
                    L++;
                } else if(nums[L] + nums[R] == target) {
                    res.Add((L, R));
                    L++;
                    R--;
                }
            }
            return res;
        }
    }
}