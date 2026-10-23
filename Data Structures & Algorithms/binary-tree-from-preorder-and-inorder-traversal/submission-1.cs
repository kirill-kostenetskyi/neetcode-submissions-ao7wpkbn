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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(preorder.Length == 0 || inorder.Length == 0){
            return null;
        }

        var root = new TreeNode(preorder[0]);

        var m = Array.IndexOf(inorder, root.val);

        var leftInorder = inorder[0..m];
        var leftPreorder = preorder[1..(m + 1)];

        var rightInorder = inorder[(m + 1)..];
        var rightPreorder = preorder[(m + 1)..];

        root.left = BuildTree(leftPreorder, leftInorder);
        root.right = BuildTree(rightPreorder, rightInorder);

        return root;
    }
}