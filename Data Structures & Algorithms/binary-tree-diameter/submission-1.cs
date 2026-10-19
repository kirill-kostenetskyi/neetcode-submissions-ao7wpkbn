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
    private int bestDiameter = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        DFS(root);
        return bestDiameter;

        int DFS(TreeNode root){
            if(root == null){
                return 0;
            }

            var leftDepth = DFS(root.left);
            var rightDepth = DFS(root.right);

            var total = leftDepth + rightDepth;

            bestDiameter = Math.Max(bestDiameter, total);

            return Math.Max(leftDepth + 1, rightDepth + 1);
        }
    }
}