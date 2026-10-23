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
    public int MaxPathSum(TreeNode root) {
        var bestRes = int.MinValue;
        DFS(root);
        return bestRes;

        int DFS(TreeNode root){
            if(root == null){
                return 0;
            }

            var left = DFS(root.left);
            var right = DFS(root.right);

            var sum = root.val + left + right;
            bestRes = Math.Max(sum, bestRes);
            bestRes = Math.Max(root.val, bestRes);
            bestRes = Math.Max(root.val + left, bestRes);
            bestRes = Math.Max(root.val + right, bestRes);
            
            var bestToReturn = root.val + left;
            bestToReturn = Math.Max(root.val + right, bestToReturn);
            bestToReturn = Math.Max(root.val, bestToReturn);

            return bestToReturn;
        }
    }
}