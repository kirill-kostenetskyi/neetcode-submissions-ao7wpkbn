/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        var arr = new List<string>();
        DFS(root);
        return string.Join(",", arr);

        void DFS(TreeNode root){
            if(root == null){
                arr.Add("n");
                return;
            }

            arr.Add(root.val.ToString());
            DFS(root.left);
            DFS(root.right);

            return;
        }
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        var arr = data.Split(",");
        int i = 0;
        var res = DFS(ref i);
        return res;
        
        TreeNode DFS(ref int i){
            if(arr[i] == "n"){
                return null;
            }

            var node = new TreeNode(int.Parse(arr[i]));
            i = i + 1;
            node.left = DFS(ref i);
            i = i + 1;
            node.right = DFS(ref i);

            return node;
        }
    }

}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));