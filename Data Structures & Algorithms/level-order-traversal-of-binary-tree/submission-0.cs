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
    public List<List<int>> LevelOrder(TreeNode root) {
        var result = new List<List<int>>();
        if(root == null){
            return result;
        }
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while(q.Count() > 0){
            var currentCnt = q.Count();
            var level = new List<int>();
            for(int i = 0; i < currentCnt; i++){
                var currentNode = q.Dequeue();
                level.Add(currentNode.val);

                if(currentNode?.left != null){
                    q.Enqueue(currentNode?.left);
                }
                if(currentNode?.right != null){
                    q.Enqueue(currentNode?.right);
                }
            }
            result.Add(level);
        }

        return result;
    }
}
