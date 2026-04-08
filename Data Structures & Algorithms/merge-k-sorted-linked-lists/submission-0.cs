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
        if(lists.Length == 0){
            return null;
        }
        if(lists.Length == 1){
            return lists[0];
        }
        for(int i = 0; i<= lists.Length - 2; i++){
            var mergedListHead = MergeTwoSortedLists(lists[i], lists[i+1]);
            lists[i + 1] = mergedListHead;
        }

        var result = lists[lists.Length - 1];
        return result;
    }

    private ListNode MergeTwoSortedLists(ListNode list1, ListNode list2){
        var dummy = new ListNode();
        var cDummy = dummy;

        while(list1 != null && list2 != null){
            if(list1.val <= list2.val){
                dummy.next = list1;
                list1 = list1.next;
            } else {
                dummy.next = list2;
                list2 = list2.next;
            }
            dummy = dummy.next;
        }
        if(list1 == null){
            dummy.next = list2;
        }
        if(list2 == null){
            dummy.next = list1;
        }
        return cDummy.next;
    }
}