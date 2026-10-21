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
        var res = new List<int>();
        var q = new Queue<TreeNode>();
        if(root != null){
            q.Enqueue(root);
        }

        while(q.Count > 0){
            int layerRes = 0;
            var batchLength = q.Count;
            for(int i = 0; i < batchLength; i++){
                var current = q.Dequeue();
                if(i == 0){
                    layerRes = current.val;
                }
                if(current.right != null){
                    q.Enqueue(current.right);
                }
                if(current.left != null){
                    q.Enqueue(current.left);
                }
            }
            res.Add(layerRes);
        }
        return res;
    }
}