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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        return DFS(p, q);

        bool DFS(TreeNode p, TreeNode q){
            if(p == null && q == null){
                return true;
            }
            if(p?.val != q?.val){
                return false;
            }
            var left = DFS(p.left, q.left);
            var right = DFS(p.right, q.right);
            
            if(left == false || right == false){
                return false;
            }

            return true;
        }
    }

}