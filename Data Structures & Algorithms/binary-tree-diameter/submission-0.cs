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
    private int maxCount = 0;

    public int DiameterOfBinaryTree(TreeNode root) {
        Iterate(root);
        return maxCount;
    }

    private int Iterate(TreeNode root){
        if(root == null){
            return 0;
        } 
        int currentVal = root.val;

        var leftCnt = Iterate(root.left);
        var rightCnt = Iterate(root.right);

        var biggerOne = Math.Max(leftCnt, rightCnt);

        maxCount = Math.Max(leftCnt + rightCnt, maxCount);

        return biggerOne + 1;
    }
}