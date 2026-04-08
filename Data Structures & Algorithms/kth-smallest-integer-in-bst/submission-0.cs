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
    public int KthSmallest(TreeNode root, int k) {
        var s = new Stack<TreeNode>();
        var current = root;

        while(s.Count() > 0 || current != null){
            while(current != null){
                s.Push(current);
                current = current?.left;
            }
            current = s.Pop();
            k--;
            if(k == 0){
                return current.val;
            }
            
            current = current?.right;
        }

        return -1;
        
    }
}