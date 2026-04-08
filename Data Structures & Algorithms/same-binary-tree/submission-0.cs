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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        DFS(p, q);
        return result;
    }

    private void DFS(TreeNode p, TreeNode q){
       if(p?.val != q?.val){
            result = false;
            return;
       }

       if(p == null && q == null){
            return;
       }

       DFS(p.left, q.left);
       DFS(p.right, q.right);

       return;
    }
}