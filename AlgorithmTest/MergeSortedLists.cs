using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

    class MergeSortedLists
    {
        // no change to l1 & l2, use extra space to save result
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode ret = new ListNode(0), last = ret;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    ListNode tmp = new ListNode(l1.val);
                    last.next = tmp;
                    last = last.next;
                    l1 = l1.next;
                }
                else
                {
                    ListNode tmp = new ListNode(l2.val);
                    last.next = tmp;
                    last = last.next;
                    l2 = l2.next;
                }
            }
            while (l1 != null)
            {
                ListNode tmp = new ListNode(l1.val);
                last.next = tmp;
                last = last.next;
                l1 = l1.next;
            }
            while (l2 != null)
            {
                ListNode tmp = new ListNode(l2.val);
                last.next = tmp;
                last = last.next;
                l2 = l2.next;
            }
            return ret.next;
        }

        // change l1 & l2
        public static ListNode Solution2(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
            {
                return l1 ?? l2;
            }
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }
            current.next = l1 == null ? l2 : l1;
            return dummy.next;
        }
    }
}
