public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        var result = new HashSet<int>();
        foreach(var triplet in triplets){
            var isValid = true;
            for(int i = 0; i < triplet.Length; i++){
                if(triplet[i] > target[i]){
                    isValid = false;
                    break;
                }
            }
            if(isValid){
                for(int i = 0; i < triplet.Length; i++){
                    if(triplet[i] == target[i]){
                        result.Add(i);
                    }
                }
            }
        }
        return result.Count == 3;
    }
}