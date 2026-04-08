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
        Dictionary<Node, Node> d = new Dictionary<Node, Node>();
        var headCopy = head;
        while(head != null){
            d.Add(head, new Node(head.val));
            head = head.next;
        }
        head = headCopy;
        
        Node dummy = new Node(0);
        var ccDummy = dummy;
        
        while(head != null){
            var copy = d[head];
            copy.next = head.next != null ? d[head.next] : null;
            copy.random = head.random != null ? d[head.random] : null;
            dummy.next = copy;

            head = head.next;
            dummy = dummy.next;
        }

        return ccDummy.next;
    }
}
