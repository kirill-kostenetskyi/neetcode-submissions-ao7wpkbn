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
    public TreeNode InvertTree(TreeNode root) {
        Invert(root);
        return root;
    }

    private void Invert(TreeNode root){
        if(root == null){
            return;
        }

        var tempLeft = root.left;
        var tempRight = root.right;

        root.right = tempLeft;
        root.left = tempRight;

        Invert(root.left);
        Invert(root.right);
    }
}