public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        if (nums.Length == 0)
            return new int[] { -1, -1 };

        int L = 0;
        int R = nums.Length - 1;

        // Find first position
        while (L < R) {
            int M = L + (R - L) / 2;

            if (nums[M] >= target) {
                R = M;
            } else {
                L = M + 1;
            }
        }

        if (nums[L] != target)
            return new int[] { -1, -1 };

        int startRes = L;

        L = 0;
        R = nums.Length - 1;

        // Find last position
        while (L < R) {
            int M = L + (R - L + 1) / 2;

            if (nums[M] <= target) {
                L = M;
            } else {
                R = M - 1;
            }
        }

        int endRes = L;

        return new int[] { startRes, endRes };
    }
}