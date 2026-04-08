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
    public ListNode ReverseList(ListNode head){
        ListNode p1 = null;
        var p2 = head;

        while(p2 != null){
            var p2Next = p2.next;

            p2.next = p1;
            p1 = p2;

            p2 = p2Next;
        }

        return p1;
    }
}
