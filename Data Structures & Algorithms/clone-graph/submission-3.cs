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
    public Node CloneGraph(Node node) {
        var map = new Dictionary<Node, Node>();
        if(node == null){
            return null;
        }
        return DFS(node);

        Node DFS(Node node){
            if(map.ContainsKey(node)){
                return map[node];
            }
            var copy = new Node(node.val);
            map.Add(node, copy);

            foreach(var nei in node.neighbors){
                var copyNei = DFS(nei);
                copy.neighbors.Add(copyNei);
            }

            return copy;
        }
    }
}