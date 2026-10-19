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
    public int MaxDepth(TreeNode root) {

        return DFS(root, 0);

        int DFS(TreeNode root, int i){
            if(root == null){
                return i;
            }

            return Math.Max(DFS(root.left, i + 1), DFS(root.right, i + 1));
        }
    }
}