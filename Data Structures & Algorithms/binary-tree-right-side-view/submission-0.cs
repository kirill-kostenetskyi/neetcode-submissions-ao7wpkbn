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
    public List<int> RightSideView(TreeNode root) {
        var result = new List<int>();
        var q = new Queue<TreeNode>();

        q.Enqueue(root);

        while(q.Count() > 0){

            var cnt = q.Count();

            for(int i=0; i < cnt; i++){
                var node = q.Dequeue();
                if(node == null){
                    continue;
                }

                if(node.left != null){
                    q.Enqueue(node.left);
                }
                
                if(node.right != null){
                    q.Enqueue(node.right);
                }

                if(i == cnt - 1){
                    // the most right
                    result.Add(node.val);
                }
            }
        }

        return result;
    }
}