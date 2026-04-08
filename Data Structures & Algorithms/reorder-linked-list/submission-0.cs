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

        ListNode lastNodeOfTheFirstHalf = null;
        while(fast != null){
            lastNodeOfTheFirstHalf = slow;
            slow = slow.next; // 1, 2, 3
            fast = fast?.next?.next; // 3, 5, null
        }

        var halfBegin = slow;
        lastNodeOfTheFirstHalf.next = null;

        var list1 = head;
        var list2 = reverse(halfBegin);

        var dummy = new ListNode();
        var cDummy = dummy;
        //list1 = [1, 2]
        //list2 = [5, 4, 3]
        //dummy = [0, 1, 5] l1 = 2, l2 = 4
        //dummy = [0, 1, 5, 2, 4] l1 = _, l2 = 3

        var takeFromFirst = true;

        while(list1 != null && list2 != null){
           if(takeFromFirst){
                dummy.next = list1;
                list1 = list1.next;
                takeFromFirst = false;
           } else {
                dummy.next = list2;
                list2 = list2.next;
                takeFromFirst = true;
           }
           dummy = dummy.next;
        }

        if(list2 != null){
            dummy.next = list2;
        }
        else if(list1 != null){
            dummy.next = list1;
        }
        head = cDummy;
    }

    private ListNode getHalf(ListNode head){
        var slow = head;
        var fast = head;

        while(fast != null){
            slow = slow.next; // 1, 2, 3
            fast = fast?.next?.next; // 3, 5, null
        }

        return slow;
    }

    private ListNode reverse(ListNode head){
        ListNode p1 = null;
        ListNode p2 = head;

        while(p2 != null){
            var p2Next = p2.next;
            p2.next = p1;

            p1 = p2;
            p2 = p2Next;
        }
        return p1;
    }
}