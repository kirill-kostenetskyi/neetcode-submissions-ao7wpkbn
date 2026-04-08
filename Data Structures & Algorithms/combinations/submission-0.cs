public class Solution {
    private List<List<int>> result = new List<List<int>>();
    public List<List<int>> Combine(int n, int k) {
        Logic(n, k, new List<int> (), 1);
        return result;
    }

    private void Logic(int n, int k, List<int> currentSet, int i){
        if(currentSet.Count() == k){
            result.Add(currentSet);
            return;
        }
        if(i > n){
            return;
        }

        currentSet.Add(i);
        
        i = i + 1;

        Logic(n, k, currentSet.ToList(), i);
        currentSet.RemoveAt(currentSet.Count() - 1);
        Logic(n, k, currentSet.ToList(), i);
    }
}