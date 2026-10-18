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
    public ListNode ReverseKGroup(ListNode head, int k) {
        var dummy = new ListNode();
        var cDummy = dummy;
        
        var begin = head;

        var counter = 0;

        while(head != null){
            counter++;
            if(counter != k){
                head = head.next;
            } else {
                var tempNext = head.next;
                head.next = null;

                ListNode reversedHead = Reverse(begin);
                dummy.next = reversedHead;

                while(dummy.next != null){ // можно заменить на dummy.next = reversedHead; - так проще, но я все таки оставил тут цикл как я придумал сам
                    dummy  = dummy.next;
                }

                head = tempNext;
                begin = head;
                counter = 0;
            }
        }  
        dummy.next = begin;

        return cDummy.next;

        ListNode Reverse(ListNode head){
            ListNode prev = null;
            while(head != null){
                var tempNext = head?.next;
                head.next = prev;

                prev = head;
                head = tempNext;
            }
            return prev; // new head
        }
    }
}