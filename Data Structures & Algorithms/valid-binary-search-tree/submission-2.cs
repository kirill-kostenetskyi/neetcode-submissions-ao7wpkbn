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
    public bool IsValidBST(TreeNode root) {
        return DFS(root, long.MinValue, long.MaxValue);

        bool DFS(TreeNode root, long lowerBound, long upperBound){
            if(root == null){
                return true;
            }

            if(root.val > lowerBound && root.val < upperBound){
                return DFS(root.left, lowerBound, root.val) && DFS(root.right, root.val, upperBound);
            } else {
                return false;
            }
        }
    }
}