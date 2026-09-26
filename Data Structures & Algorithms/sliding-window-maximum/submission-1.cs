public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var L = 0;
        var R = 0;
        var res = new List<int>();

        var ll = new LinkedList<(int Index, int Value)>();

        while(R < nums.Length){
            while(ll.Count > 0 &&  nums[R] >= ll.First.Value.Value){
                ll.RemoveFirst();
            }
            ll.AddFirst((R, nums[R]));
            R++;
            while(ll.Count > 0 && ll.Last.Value.Index < L){
                var last = ll.Last.Value;
                ll.RemoveLast();
            }
            if(R - L == k){
                res.Add(ll.Last.Value.Value);
                L++;
            }
        }

        return res.ToArray();
    }
}