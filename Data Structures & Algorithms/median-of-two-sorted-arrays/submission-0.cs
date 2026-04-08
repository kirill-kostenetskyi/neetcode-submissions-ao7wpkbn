public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var A = nums1;
        var B = nums2;

        if(nums1.Length > nums2.Length){
            A = nums2;
            B = nums1;
        }

        var totalSize = A.Length + B.Length;
        var half = totalSize / 2; // длина левого массива в любом случае такая

        var l = 0;
        var r = A.Length; // сколько элеметов мы берем
        
        while (l <= r) {
            var takeA = (r + l) / 2; // сколько эленетов берем из лева первого массива. НЕ ИНДЕКС 
            var takeB = half - takeA;// сколько элементов берем из левой части второго массива. НЕ ИНДЕКС
            
            var aLeft = takeA == 0 ? int.MinValue : A[takeA - 1];
            var aRight = takeA == A.Length ? int.MaxValue : A[takeA];
            var bLeft = takeB == 0 ? int.MinValue : B[takeB - 1];
            var bRight = takeB == B.Length ? int.MaxValue : B[takeB];

            if(aLeft <= bRight && bLeft <= aRight){
                // found 
                if(totalSize % 2 > 0){
                    // odd
                    return Math.Min(aRight, bRight);
                } else {
                    // even
                    return Math.Max(aLeft, bLeft) * 0.5 + Math.Min(aRight, bRight) * 0.5;
                }
                
            } else if (bLeft > aRight){
                l = takeA + 1;
            } else {
                r = takeA - 1;
            }
        }
        return 0;
    }
}
