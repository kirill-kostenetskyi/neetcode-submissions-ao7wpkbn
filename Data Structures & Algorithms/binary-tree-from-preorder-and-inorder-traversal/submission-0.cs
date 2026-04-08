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
        if(preorder.Count() == 0 || inorder.Count() == 0){
            return null;
        }
        var rootVal = preorder[0];
        var root = new TreeNode(rootVal);
        // наша задача построить левую и правую ветку
        // каждая функция(нода) условно пусть думает как ей строить.
        // по скольку мы с вершины начинаем, мы ее в конце и вернем. 
        // можно глобально не думать о рекурсии в этот момент
        
        var indexInInorder = Array.IndexOf(inorder, rootVal);
        //для постройки левой ветки надо понять какой у нее массив 
        // preorder & inorder (по-задача)
        //в inorder то что слева от ноды в массиве всегда представляет левую ветку
        // посмотрим ее длину
        var leftLength = indexInInorder;
        // это дает нам понимание что в массиве preorder первые leftLenght и будут 
        // элементы которые идут слева в дереве. Посчитаем и вызовем метод:
        var leftPreorder = preorder.Skip(1).Take(leftLength).ToArray();
        var leftInorder = inorder.Take(leftLength).ToArray();
        root.left = BuildTree(leftPreorder, leftInorder);

        var rightLength = inorder.Count() - leftLength - 1;
        
        var rightInorder = inorder.Skip(leftLength + 1).Take(rightLength).ToArray();
        var rightPreorder = preorder.Skip(leftLength + 1).Take(rightLength).ToArray();
        root.right = BuildTree(rightPreorder, rightInorder);
        return root;
    }
}