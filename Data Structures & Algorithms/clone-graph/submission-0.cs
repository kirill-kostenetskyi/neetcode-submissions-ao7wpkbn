/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    private Dictionary<Node, Node> oldToNew = new Dictionary<Node, Node>();
    public Node CloneGraph(Node node) {
        return Clone(node);
    }

    private Node Clone(Node node){
        if(node == null){
            return null;
        }
        
        if(oldToNew.ContainsKey(node)){
            return oldToNew[node];
        }

        var clone = new Node(node.val);
        oldToNew.Add(node, clone);

        foreach(var nei in node.neighbors){
            var clonedNei = Clone(nei);
            clone.neighbors.Add(clonedNei);
        }

        return clone;
    }
}