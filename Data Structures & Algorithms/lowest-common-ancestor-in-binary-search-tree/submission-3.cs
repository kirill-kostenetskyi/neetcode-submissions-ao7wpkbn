/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        return DFS(root);

        TreeNode DFS(TreeNode root){
            if(root == null){
                return null;
            }

            if(root.val < p.val && root.val < q.val){
                return DFS(root.right);
            }

            if(root.val > p.val && root.val > q.val){
                return DFS(root.left);
            }
            // это не обязательно вообще писать, ибо это единственные условия которые остались
            if(root.val >= p.val && root.val <= q.val){
                return root;
            }
            // тоже самое
            if(root.val <= p.val && root.val >= q.val){
                return root;
            }

            return root;
        }
    }
}