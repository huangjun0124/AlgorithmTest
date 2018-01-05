using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Reverse_Linked_List
    {
        //recursively
        public static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            return ReverseNode(head, null);
        }

        private static ListNode ReverseNode(ListNode node, ListNode parent)
        {
            if (node.next == null)
            {
                node.next = parent;
                return node;
            }
            else
            {
                var ret = ReverseNode(node.next, node);
                node.next = parent;
                return ret;
            }
        }

        //iteratively 
        public static ListNode Solution2(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode newHead = null;
            Stack<ListNode> stack = new Stack<ListNode>(); 
            stack.Push(head);
            stack.Push(head.next);
            head.next = null;
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var parent = stack.Pop();
                if (node.next == null)
                {
                    newHead = node;
                }
                else
                {
                    stack.Push(node);
                    stack.Push(node.next);
                }
                node.next = parent;
            }
            return newHead;
        }

        // draw a draft and you should know how it works
        public static ListNode Solution3(ListNode head)
        {
            ListNode p = null;
            while (head != null)
            {
                var tmp = head.next;
                head.next = p;
                p = head;
                head = tmp;
            }
            return p;
        }
    }
}
