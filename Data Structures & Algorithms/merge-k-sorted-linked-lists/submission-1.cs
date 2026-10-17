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
    public ListNode MergeKLists(ListNode[] lists) {
        var heap = new PriorityQueue<ListNode, int>();

        foreach(var list in lists){
            if(list != null){
                heap.Enqueue(list, list.val);
            }
        }

        var dummy = new ListNode();
        var dCopy = dummy;
        
        while(heap.Count > 0){
            var top = heap.Dequeue();
            dummy.next = top;
            dummy = dummy.next;

            if(top.next != null){
                heap.Enqueue(top.next, top.next.val);
            }
        }

        return dCopy.next;
    }
}
