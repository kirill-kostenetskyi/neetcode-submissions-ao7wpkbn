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
        return DFS(root, long.MinValue, long.MaxValue);
    }

    private bool DFS(TreeNode root, long min, long max){
        if(root == null){
            return true;
        }

        if(root.val >= max || root.val <= min){
            return false;
        }

        return DFS(root.left, min, root.val) && DFS(root.right, root.val, max);
    }
}