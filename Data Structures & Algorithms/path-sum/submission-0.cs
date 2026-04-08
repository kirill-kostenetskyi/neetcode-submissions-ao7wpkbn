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
    private int sum = 0;
    public bool HasPathSum(TreeNode root, int targetSum) {
        if(root != null){
            sum = sum + root.val;
        } else {
            return false;
        }
        if(root?.left == null && root?.right == null){
            // leaf
            if(targetSum == sum){
                return true;
            } else {
                sum = sum - root.val;
                return false;
            }
        }

        if(root.left != null){
            var res = HasPathSum(root.left, targetSum);
            if(res){
                return true;
            }
        }
        
        if(root.right != null){
            var res = HasPathSum(root.right, targetSum);
            if(res){
                return true;
            }
        }
        
        sum = sum - root.val;
        return false;
    }
}