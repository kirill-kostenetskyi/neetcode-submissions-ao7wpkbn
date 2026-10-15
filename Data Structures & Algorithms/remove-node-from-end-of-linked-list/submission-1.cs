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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode();
        dummy.next = head;

        var p1 = dummy;
        ListNode p2 = head;

        while(n > 0){ 
            p2 = p2?.next;
            n--;
        }

        while(p2 != null){
            p2 = p2?.next;
            p1 = p1.next;
        }

        p1.next = p1?.next?.next;

        return dummy.next;
    }
}