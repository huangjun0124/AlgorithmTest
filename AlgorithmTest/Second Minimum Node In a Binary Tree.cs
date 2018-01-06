using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly two or zero sub-node.If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes.


    Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.


    If no such second minimum value exists, output -1 instead.

    Example 1:


    Input: 
    2
    / \
    2   5
    / \
    5   7


    Output: 5
    Explanation: The smallest value is 2, the second smallest value is 5.


    Example 2:


    Input: 
    2
    / \
    2   2


    Output: -1
    Explanation: The smallest value is 2, but there isn't any second smallest value.
    */
    class Second_Minimum_Node_In_a_Binary_Tree
    {
        public static int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null || root.left == null) return -1;
            long min = 1L + int.MaxValue, secondMin = 1L + int.MaxValue;
            GetNodeVal(root, ref min, ref secondMin);
            if (min == secondMin || secondMin > int.MaxValue) return -1;
            return (int)secondMin;
        }

        private static int GetNodeVal(TreeNode node, ref long min, ref long secondMin)
        {
            int val;
            if (node.left == null && node.right == null)
                val = node.val;
            else
                val = Math.Min(GetNodeVal(node.left, ref min, ref secondMin),
                    GetNodeVal(node.right, ref min, ref secondMin));
            if (val > min && secondMin > int.MaxValue)
                secondMin = val;
            if (val < min)
            {
                secondMin = min;
                min = val;
            }
            else if (val != min && val < secondMin)
            {
                secondMin = val;
            }
            return val;
        }
    }
}
