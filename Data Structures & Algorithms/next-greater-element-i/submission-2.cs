public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var s = new Stack<int>();
        var map = new Dictionary<int, int>();
        for(int i = 0; i < nums1.Length; i++){
            map.Add(nums1[i], i);
        }
        var res = new int[nums1.Length];
        Array.Fill(res, -1);

        for(int i = 0; i < nums2.Length; i++){
            while(s.Count > 0 && s.Peek() < nums2[i]){
                var top = s.Pop();
                if(map.ContainsKey(top)){
                    res[map[top]] = nums2[i];
                }
            }
            s.Push(nums2[i]);
        }
        return res;
    }
}