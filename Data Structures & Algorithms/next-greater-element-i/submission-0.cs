public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var nums1Map = new Dictionary<int,int>(); //<value, inded>
        for(int i = 0; i < nums1.Length; i++) {
            nums1Map.Add(nums1[i], i);
        }
        var res = new int[nums1.Length];
        for(int i = 0; i < res.Length; i++) {
            res[i] = -1;
        }
        var s = new Stack<int>();
        for(int i = 0; i < nums2.Length; i++) {
            var num2 = nums2[i];
            if(s.Count > 0){
                // found next greater for all
                while(s.Count > 0 && num2 >= s.Peek()){
                    var val = s.Pop();
                    if(nums1Map.ContainsKey(val)){
                        var index = nums1Map[val];
                        res[index] = num2;
                    }
                }
            }
            s.Push(num2);
        }

        return res;
    }
}