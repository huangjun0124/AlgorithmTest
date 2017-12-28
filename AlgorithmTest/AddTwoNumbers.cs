using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class AddTwoNumbers
    {
        public static ListNode AddTwoNumbersSolution(ListNode l1, ListNode l2)
        {
            ListNode ret = null, last = null;
            bool isOverrun = false;
            while (l1 != null || l2 != null)
            {
                int temp = 0;
                if (l1 != null)
                    temp += l1.val;
                if (l2 != null)
                    temp += l2.val;
                if (isOverrun) temp += 1;
                if (temp > 9)
                {
                    isOverrun = true;
                    temp = temp % 10;
                }
                else
                {
                    isOverrun = false;
                }
                ListNode tmp = new ListNode(temp);
                if (last == null)
                {
                    last = ret = tmp;
                }
                else
                {
                    last.next = tmp;
                    last = last.next;
                }
                l1 = l1?.next;
                l2 = l2?.next;
            }
            if (isOverrun)
            {
                ListNode tmp = new ListNode(1);
                last.next = tmp;
            }
            return ret;
        }
    }
}
