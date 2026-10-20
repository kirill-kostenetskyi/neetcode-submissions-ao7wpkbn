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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        return DFS(root);

        bool DFS(TreeNode root){
            if(root == null){
                return false;
            }

            if(root.val == subRoot.val){
                var isSame = IsSameTree(root, subRoot);
                if(isSame){
                    return true;
                }
            }
            
            var left = DFS(root.left);
            var right = DFS(root.right);

            return left || right;
        }

        bool IsSameTree(TreeNode p, TreeNode q){
            if(p == null && q == null){
                return true;
            }
            if(p?.val != q?.val){
                return false;
            }

            var left = IsSameTree(p.left, q.left);
               if(left == false){
                return false;
            }

            var right = IsSameTree(p.right, q.right);
            if(right == false){
                return false;
            }

            return true;
        }
    }
}