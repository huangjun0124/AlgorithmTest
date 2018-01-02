using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace ConsoleApp1
{
    class RemoveDuplicatesfromSortedList
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null) return null;
            ListNode pre = head, current = head.next;
            while (current != null)
            {
                if (pre.val != current.val)
                {
                    pre.next = current;
                    pre = current;
                    current = current.next;
                }
                else
                {
                    current = current.next;
                }
            }
            //{1,1,1,2,2,3,4,5,5,5}
            if (pre.next != null) pre.next = null;
            return head;
        }

        // save one space
        public static ListNode Solution2(ListNode head)
        {
            ListNode list = head;
            while (list != null)
            {
                if (list.next == null)
                {
                    break;
                }
                if (list.val == list.next.val)
                {
                    list.next = list.next.next;
                }
                else
                {
                    list = list.next;
                }
            }
            return head;
        }

        public static ListNode Solution3(ListNode head)
        {
            ListNode cur = head;
            while (cur != null)
            {
                while (cur.next != null && cur.val == cur.next.val)
                    cur.next = cur.next.next;
                cur = cur.next;
            }
            return head;
        }
    }
}
