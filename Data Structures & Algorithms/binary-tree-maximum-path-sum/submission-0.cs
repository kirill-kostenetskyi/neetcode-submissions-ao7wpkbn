/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    private int maxSum = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        MaxSumInternal(root);
        return maxSum;
    }

    private int MaxSumInternal(TreeNode root){
          if(root == null){
            return 0;
        }
        maxSum = Math.Max(maxSum, root.val);
        
        var leftSum = MaxSumInternal(root.left);
        var rightSum = MaxSumInternal(root.right);
        var total = leftSum + root.val + rightSum;

        maxSum = Math.Max(maxSum, total);
        maxSum = Math.Max(maxSum, leftSum + root.val);
        maxSum = Math.Max(maxSum, rightSum + root.val);

        var res = Math.Max(leftSum + root.val, rightSum + root.val);
        res = Math.Max(res, root.val);
        return res;
    }
}
