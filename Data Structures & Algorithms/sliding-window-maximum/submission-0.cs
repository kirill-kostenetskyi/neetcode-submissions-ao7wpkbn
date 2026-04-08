public class Solution {
    public int currentMax = 0;
    public LinkedList<int> deque = new LinkedList<int>();

    public int[] MaxSlidingWindow(int[] nums, int k) {
        var res = new List<int>();
        currentMax = nums[0];

        for(int i = 0; i < k ; i++){
            AddDuequeLogic(nums, k, i);
        }
        res.Add(nums[currentMax]);
        
        for(int i = k; i < nums.Length; i++){
            AddDuequeLogic(nums, k, i);
            res.Add(nums[currentMax]);
        }

        return res.ToArray();
    }

    private void AddDuequeLogic(int[] nums, int k, int currentIndex){
        // we add only something that is lower than the last element
        var last = deque.Last;
        while(last != null 
            && nums[last.Value] <= nums[currentIndex]
        ){
            deque.RemoveLast();
            last = deque.Last;
            
        }

        deque.AddLast(currentIndex);

        if(currentIndex - k == deque.First?.Value){
            // means we remove current max
            deque.RemoveFirst();
        }
        currentMax = deque.First.Value;
    }
}