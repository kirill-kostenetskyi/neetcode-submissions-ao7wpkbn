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
    private int successCnt = 0;
    public int GoodNodes(TreeNode root) {
        int currentBranchMax = root.val;
        DFS(root, currentBranchMax);
        return successCnt;
    }

    private void DFS(TreeNode root, int currentBranchMax){
        var current = root?.val;
        if(root == null) {
            return;
        }
        if(root.val > currentBranchMax){
            currentBranchMax = root.val;
        }

        DFS(root.left, currentBranchMax);
        DFS(root.right, currentBranchMax);

        if(root.val >= currentBranchMax){
            successCnt++;
        }
    }
}