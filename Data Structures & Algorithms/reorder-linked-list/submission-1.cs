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
    public void ReorderList(ListNode head) {
        var slow = head;
        var fast = head;
        ListNode beforeSlow = null;
        while(fast != null){
            beforeSlow = slow;
            slow = slow.next;
            fast = fast?.next?.next;
        }

        beforeSlow.next = null;

        var list2 = Reverse(slow);
        var list1 = head;

        var dummy = new ListNode();

        while(list1 != null && list2 != null){
            dummy.next = list1;
            list1 = list1.next;
            dummy = dummy.next;
            
            dummy.next = list2;
            list2 = list2.next;
            dummy = dummy.next;
        }
        if(list1 == null){
            dummy.next = list2;
        }
        if(list2 == null){
            dummy.next = list1;
        }
        

        ListNode Reverse(ListNode head){
            ListNode prev = null;
            while(head != null){
                var temp = head.next;
                head.next = prev;
                prev = head;
                head = temp;
            }

            return prev;
        }
    }
}