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
    public int MaxDepth(TreeNode root) {
        var q = new Queue<TreeNode>();
        var q2 = new Queue<int>();
        
        if(root != null){
            q.Enqueue(root);
            q2.Enqueue(root.val);
        }
        var level = 0;
        while(q.Count() > 0){
            level++;
            var c = q.Count();
            for(int i = 1; i <= c; i++){
                var item = q.Dequeue();
                q2.Dequeue();
                if(item.left != null){
                    q.Enqueue(item.left);
                    q2.Enqueue(item.left.val);
                }
                if(item.right != null){
                    q.Enqueue(item.right);
                    q2.Enqueue(item.right.val);
                }
            }       
        }

        return level;
    }
}