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
        if(node == null){
            return null;
        }

        Node cloned;

        if(oldToNew.ContainsKey(node)){
            cloned = oldToNew[node];
        } else {
            cloned = new Node();
            cloned.val = node.val;
            oldToNew[node] = cloned;
        }


        foreach(var nei in node.neighbors){
            if(oldToNew.ContainsKey(nei)){
                var clonedNei = oldToNew[nei];
                cloned.neighbors.Add(clonedNei);
            } else {
                var clonedNei2 = CloneGraph(nei);
                cloned.neighbors.Add(clonedNei2);
            }
        }

        return cloned;
    }
}