using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a Binary Search Tree(BST), convert it to a Greater Tree such that every key of the original BST is changed to the original key plus sum of all keys greater than the original key in BST.

    Example:

    Input: The root of a Binary Search Tree like this:
       5
     /   \
    2     13

    Output: The root of a Greater Tree like this:
       18
      /   \
    20     13
    Explaination:
        5 -> 5 + 13
        2 -> 2 + 5 + 13
        13 -> 13
    */
    class Convert_BST_to_Greater_Tree
    {
        // inorder start from left!!!
        public TreeNode ConvertBST(TreeNode root)
        {
            TreeNode node = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            int sum = 0;
            while (node != null || stack.Count > 0)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.right;
                }
                else
                {
                    node = stack.Pop();
                    sum += node.val;
                    node.val = sum;

                    node = node.left;
                }
            }
            return root;
        }


        public TreeNode SolutionRecurr(TreeNode root)
        {
            Convert(root, 0);
            return root;
        }

        private int Convert(TreeNode node, int sum)
        {
            if (node == null) return sum;
            sum = Convert(node.right, sum);
            sum += node.val;
            node.val = sum;
            return Convert(node.left, sum);
        }
    }
}
