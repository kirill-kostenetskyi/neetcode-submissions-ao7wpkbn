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
    public int GoodNodes(TreeNode root) {
        int res = 0;
        DFS(root, int.MinValue);
        return res;

        void DFS(TreeNode root, int currentMax){
            if(root == null){
                return;
            }

            if(root.val >= currentMax){
                res += 1;
                currentMax = root.val;
            }

            DFS(root.left, currentMax);
            DFS(root.right, currentMax);
        }
    }
}