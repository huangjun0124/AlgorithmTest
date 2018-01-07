using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s.A subtree of s is a tree consists of a node in s and all of this node's descendants. The tree s could also be considered as a subtree of itself.


    Example 1:
    Given tree s:

        3
       / \
      4   5
     / \
    1   2


    Given tree t:

      4 
     / \
    1   2


    Return true, because t has the same structure and node values with a subtree of s.


    Example 2:
    Given tree s:

         3
        / \
       4   5
      / \
     1   2
    /
    0


    Given tree t:

      4
     / \
    1   2

    Return false. 
    */
    class Subtree_of_Another_Tree
    {
        // times out...and,,,this won't work well if your node's value have multi sames
        public static bool IsSubtree(TreeNode s, TreeNode t)
        {
            string pres = PreOrder(s);
            string pret = PreOrder(t);
            int preIndex = pres.IndexOf(pret, StringComparison.InvariantCulture);
            if (preIndex < 0)
                return false;
            string inos = InOrder(s);
            string inot = InOrder(t);
            int inoIndex = inos.IndexOf(inot, StringComparison.InvariantCulture);
            if (inoIndex < 0)
                return false;
            if (pres.Length != pret.Length && pres[preIndex + pret.Length] == inos[inoIndex + inot.Length])
                return false;
            return true;
        }

        private static string PreOrder(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                sb.Append(node.val);
                if(node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }
            return sb.ToString();
        }

        private static string InOrder(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var node = root;
            while (node.left != null)
            {
                stack.Push(node);
                node = node.left;
            }
            stack.Push(node);
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                node = stack.Pop();
                sb.Append(node.val);
                if (node.right != null)
                {
                    node = node.right;
                    stack.Push(node);
                    while (node.left != null)
                    {
                        stack.Push(node.left);
                        node = node.left;
                    }
                }
            }
            return sb.ToString();
        }

        // this is the right solution...beats 86.52%
        public static bool isSubtree(TreeNode s, TreeNode t)
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(s);
            while (nodes.Count > 0)
            {
                TreeNode node = nodes.Dequeue();
                if (isSameTree(node, t))
                {
                    return true;
                }
                if (node.left != null)
                {
                    nodes.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    nodes.Enqueue(node.right);
                }
            }
            return false;
        }

        public static bool isSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
            {
                return true;
            }
            if (s == null || t == null)
            {
                return false;
            }
            if (s.val != t.val)
            {
                return false;
            }
            else
            {
                return isSameTree(s.left, t.left) && isSameTree(s.right, t.right);
            }
        }
    }
}
