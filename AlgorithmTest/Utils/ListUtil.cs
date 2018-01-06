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

    class ListUtil
    {
        public static ListNode BuildList(int[] nums)
        {
            ListNode l1 = null, last = null;
            for (int i = 0; i < nums.Length; i++)
            {
                var tmp = new ListNode(nums[i]);
                if (l1 == null)
                {
                    last = l1 = tmp;
                }
                else
                {
                    last.next = tmp;
                    last = last.next;
                }
            }
            return l1;
        }
    }
}
