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

public class Codec {
    // Encodes a tree to a single string.
    List<string> resArr = new List<string>();
    public string Serialize(TreeNode root) {
        serializeInternal(root);
        var res = string.Join(',', resArr);
        return res;
    }

    private void serializeInternal(TreeNode root){
        if(root == null){
            resArr.Add("N");
            return;
        }

        resArr.Add(root.val+"");

        serializeInternal(root.left);
        serializeInternal(root.right);
    }

    // Decodes your encoded data to tree.
    private string[] arr = [];
    public TreeNode Deserialize(string data) {
        arr = data.Split(",");
        if(arr.Count() == 0){
            return null;
        }
        int start = -1;
        var root = deserializeInternal(ref start);
        return root;
    }

    private TreeNode deserializeInternal(ref int i){
        i++;
        if(arr[i] == "N" || arr[i] == "" ||  arr.Length == i + 1){
            return null;
        }

        var root = new TreeNode(int.Parse(arr[i]));

        root.left = deserializeInternal(ref i);
        root.right = deserializeInternal(ref i);

        return root;
    }
}
