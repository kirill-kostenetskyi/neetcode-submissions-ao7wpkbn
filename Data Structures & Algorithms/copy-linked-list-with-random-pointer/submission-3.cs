/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        var map = new Dictionary<Node, Node>();
        var h = head;

        while(h != null){
            map[h] = new Node(h.val);
            h = h.next;
        }

        var result = head != null ? map[head] : null;

        while(head != null){
            map[head].next = head.next != null ? map[head.next] : null;
            map[head].random = head.random != null ? map[head.random] : null;
            head = head.next;
        }

        return result;
    }
}