/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 
public class Solution {
    ListNode newHead = null;
    public ListNode ReverseList(ListNode head) {
        return ReverseInternal(head, null);
    }

    private ListNode ReverseInternal(ListNode current, ListNode prevNode){
        if(current == null){
            return null;
        }
        if(current.next == null){
            //base 
            current.next = prevNode;
            newHead = current;
            return current;
        }

        var res = ReverseInternal(current.next, current);

        current.next = prevNode;

        return res;
    }
}