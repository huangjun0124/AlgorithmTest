using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Write a function to delete a node(except the tail) in a singly linked list, given only access to that node.

    Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function.
    */
    class Delete_Node_in_a_Linked_List
    {
        // move each one forward
        public static void DeleteNode(ListNode node)
        {
            while (node.next != null)
            {
                node.val = node.next.val;
                if (node.next.next == null) break;
                node = node.next;
            }
            node.next = null;
        }

        // simpler
        public static void Solution2(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
