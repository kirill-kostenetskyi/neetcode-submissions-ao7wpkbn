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
        var carry = 0;
        var dummy = new ListNode();
        var cDummy = dummy;
        while(l1 != null || l2 != null || carry > 0){
            var v1 = l1?.val ?? 0; // 0 
            var v2 = l2?.val ?? 0; // 0 
            var sum = v1 + v2 + carry; //1
            carry = 0;

            if(sum >= 10){
                carry = 1; // 0
            }
            var cleanValue = sum % 10; // 1

            dummy.next = new ListNode(cleanValue);
            dummy = dummy.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return cDummy.next;
    }
}