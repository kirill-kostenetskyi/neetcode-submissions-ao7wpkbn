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
        TreeNode res = null;
        DFS(root);
        return res;

        int DFS(TreeNode root){
            if(root == null){
                return 0;
            }
            int sum = 0;
            if(root == p || root == q){
                sum = 1;
            }

            var left = DFS(root.left);
            var right = DFS(root.right);

            sum = sum + left + right;

            if(sum >= 2 && res == null){
                res = root;
            }

            return sum;
        }
    }
}