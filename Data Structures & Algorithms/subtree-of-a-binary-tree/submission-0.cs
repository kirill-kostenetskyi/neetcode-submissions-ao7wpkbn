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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (subRoot == null) {
            return true;
        }
        if (root == null) {
            return false;
        }
        if(CompareTrees(root, subRoot)){
            return true;
        }

        if(IsSubtree(root?.left, subRoot)){
            return true;
        }

        if(IsSubtree(root?.right, subRoot)){
            return true;
        }

        return false;
    }
    
   private bool CompareTrees(TreeNode q, TreeNode p) {
        if (q == null && p == null) return true;
        if (q == null || p == null) return false;
        if (q.val != p.val) return false;

        return CompareTrees(q.left, p.left) &&
            CompareTrees(q.right, p.right);
    }
}