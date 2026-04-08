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
    private bool result = true;
    public bool IsValidBST(TreeNode root) {
        DFS(root);
        return result;
    }

    private void DFS(TreeNode root, long lowerBound = long.MinValue, long upperBound = long.MaxValue) {
        if(root == null){
            return;
        }
        if(root.val <= lowerBound || root.val >= upperBound){
            result = false;
            return;
        }

        DFS(root.left, lowerBound, root.val);
        DFS(root.right, root.val, upperBound);

        return;
    }
}