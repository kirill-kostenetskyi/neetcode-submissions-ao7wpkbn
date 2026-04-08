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
        var dummy = new ListNode();
        dummy.next = head;

        ListNode p1 = dummy; 
        ListNode p2 = dummy;

        var stepsAheadCnt = n - 1;
        for (var i = 0; i < stepsAheadCnt; i++){
            p2 = p2.next;
        }

        ListNode beforeP1 = null;
        while(p2.next != null){
            beforeP1 = p1;
            p2 = p2.next;
            p1 = p1.next;
        }

        beforeP1.next = p1.next;

        return dummy?.next;
    }
}
