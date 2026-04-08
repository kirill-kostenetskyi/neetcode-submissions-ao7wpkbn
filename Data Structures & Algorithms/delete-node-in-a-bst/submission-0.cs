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
    public TreeNode DeleteNode(TreeNode root, int key) {
        // возвращаем всегда ноду которая теперь будет вместо той ноды что мы удалили
        if(root == null){
            return null;
        }
       
        if(key < root.val){
            root.left = DeleteNode(root.left, key);
        } else if(key > root.val){
            root.right = DeleteNode(root.right, key);
        } else {
            //root.val == key
            if(root.left == null){
                root = root.right;
            } else if(root.right == null){
                root = root.left;
            } else {
                // более сложный сценрий где есть две ноды child/descendent (наслденики)
                var minDown = FindMinimunVal(root.right);
                root.val = minDown;
                root.right = DeleteNode(root.right, minDown);
            }
        }
    
        return root;
    }

    private int min = 0;
    private int FindMinimunVal(TreeNode root){
        if(root == null){
            return min;
        }
        min = root.val;

        if(root.left != null){
            FindMinimunVal(root.left);
        }

        return min;
    }
}