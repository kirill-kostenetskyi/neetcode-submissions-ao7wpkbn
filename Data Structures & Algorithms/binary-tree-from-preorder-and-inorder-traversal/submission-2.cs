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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(preorder.Length == 0 || inorder.Length == 0){
            return null;
        }

        var root = new TreeNode(preorder[0]);

        var m = Array.IndexOf(inorder, root.val); // O(n)

        var leftInorder = inorder[0..m]; // O(n)
        var leftPreorder = preorder[1..(m + 1)]; // O(n)

        var rightInorder = inorder[(m + 1)..]; // O(n)
        var rightPreorder = preorder[(m + 1)..]; // O(n)
        // итоговая сложность 5х O(n) = O(n).
        // а сложность всего алгоритма O(n^2), но можно сделать O(N) введя дикшионари
        // и передавая начало массива/конец массива вместо создания массива. 
        root.left = BuildTree(leftPreorder, leftInorder);
        root.right = BuildTree(rightPreorder, rightInorder);

        return root;
    }
}