using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    /*
      Given two binary trees, write a function to check if they are the same or not.
     Two binary trees are considered the same if they are structurally identical 
     and the nodes have the same value. 
     */
    class Same_Tree
    {
        // recursion
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val == q.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
            return false;
        }

        // use stack
        public static bool Solution2(TreeNode p, TreeNode q)
        {
            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(p);
            s.Push(q);
            while (s.Count > 0)
            {
                p = s.Pop();
                q = s.Pop();
                if (p == null && q == null) continue;
                if (p == null || q == null) return false;
                if (p.val == q.val)
                {
                    s.Push(p.right);
                    s.Push(q.right);
                    s.Push(p.left);
                    s.Push(q.left);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
