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
    public bool IsBalanced(TreeNode root) {
        Dfs(root);
        return result;
    }

    private int Dfs(TreeNode root){
        if(root == null){
            return 0;
        }

        var L = Dfs(root.left);
        var R = Dfs(root.right);

        if(Math.Abs(L- R) > 1){
            result = false;
        }

        var biggerOne = Math.Max(L, R);
        return biggerOne + 1; // 1 это мы добавляем текущую связь
    }
}