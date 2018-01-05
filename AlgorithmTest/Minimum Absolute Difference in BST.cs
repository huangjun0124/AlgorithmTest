using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a binary search tree with non-negative values, find the minimum absolute difference between values of any two nodes.

    Example:

    Input:

     1
      \
       3
      /
     2

    Output:
    1

    Explanation:
    The minimum absolute difference is 1, which is the difference between 2 and 1 (or between 2 and 3).

    Note: There are at least two nodes in this BST.
    */
    class Minimum_Absolute_Difference_in_BST
    {
        // Inorder visit left -> current -> right, so it would generate the sorted list while traversing
        private List<int> list;
        private int minDiff = int.MaxValue;
        public int GetMinimumDifference(TreeNode root)
        {
            list = new List<int>();
            InOrder(root);
            return minDiff;
        }

        private void InOrder(TreeNode node)
        {
            if (node.left == null && node.right == null)
            {
                UpdateList(node.val);
                return;
            }
            if(node.left != null)
                InOrder(node.left);
            UpdateList(node.val);
            if(node.right != null)
                InOrder(node.right);
        }

        private void UpdateList(int val)
        {
            list.Add(val);
            if (list.Count > 1)
            {
                int tmp = list[list.Count - 2] - val;
                tmp = tmp < 0 ? -tmp : tmp;
                minDiff = minDiff > tmp ? tmp : minDiff;
            }
        }

        private int? prev;
        // optimize: you just need two value to diff, so no List, but a prev value is enough
        public int Solution2(TreeNode root)
        {
            if (root == null) return minDiff;
            Solution2(root.left);
            if (prev.HasValue)
            {
                minDiff = Math.Min(minDiff, root.val - prev.Value);
            }
            prev = root.val;
            Solution2(root.right);
            return minDiff;
        }
    }
}
