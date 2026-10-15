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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var dummy = new ListNode();
        var cDummy = dummy;
        
        var leftOver = 0;
        while(l1 != null || l2 != null){
            var l1Value = l1 != null ?  l1.val : 0;
            var l2Value = l2 != null ?  l2.val : 0;

            var sum = l1Value + l2Value + leftOver;

            leftOver = sum / 10;
            sum = sum % 10;
            
            var sumNode = new ListNode(sum);
            dummy.next = sumNode;

            dummy = dummy.next;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        if(leftOver == 1){
            dummy.next = new ListNode(1);
        }

        return cDummy.next;
    }
}