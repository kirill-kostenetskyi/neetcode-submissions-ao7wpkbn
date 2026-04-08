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
        ListNode dummy = new ListNode();
        var cDummy = dummy;

        int counter = 0;
        var lastHeadPointer = head;
        while(head != null){
            counter++;
            
            if(counter == k){
                var savedNext = head.next;
                head.next = null; // cut the tail

                var reversed = ReverseList(lastHeadPointer); 
                dummy.next = reversed;
                dummy = lastHeadPointer; // оказывается это простой способ попасть сразу в конец, ведь мы по сути его и передавали в реверс
                // и тогда не нужен ревайнд в конец (что дает сложнотсть n^2).
                

                //dummy = RewindToTheEnd(dummy);

                head = savedNext;
                lastHeadPointer = savedNext;
                counter = 0;
            } else {
                head = head.next;
            }
        }
        dummy.next = lastHeadPointer;
        
        return cDummy.next;
    }

    private ListNode ReverseList(ListNode head){
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

    private ListNode RewindToTheEnd(ListNode head){
        while(head.next != null){
            head = head.next;
        }
        return head;
    }
}