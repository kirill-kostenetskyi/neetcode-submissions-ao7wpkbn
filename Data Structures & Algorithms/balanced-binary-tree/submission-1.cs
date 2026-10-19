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
    bool balanced = true;
    public bool IsBalanced(TreeNode root) {
        
        DFS(root);

        return balanced;

        int DFS(TreeNode root){
            if(root == null){
                return 0;
            }

            var leftDepth = DFS(root.left) + 1;
            var rightDepth = DFS(root.right) + 1;

            if(Math.Abs(leftDepth - rightDepth) > 1){
                balanced = false;
            }   

            return Math.Max(leftDepth, rightDepth);         
        }
    }
}