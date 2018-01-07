using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a binary tree, check whether it is a mirror of itself(ie, symmetric around its center).

    For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
        1
       / \
      2   2
     / \ / \
    3  4 4  3

But the following[1, 2, 2, null, 3, null, 3] is not:

      1
     / \
    2   2
     \   \
     3    3

Note:
Bonus points if you could solve it both recursively and iteratively. 
    */
    class Symmetric_Tree
    {
        // 166 ms, beats 50%
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsNodeSame(root.left, root.right);
        }

        private bool IsNodeSame(TreeNode left, TreeNode right)
        {
            if (left == null || right == null) return left == right;
            if (left.val != right.val) return false;
            return IsNodeSame(left.left, right.right) && IsNodeSame(left.right, right.left);
        }

        //173 ms, beats 34.31%
        public bool IterativeVersion(TreeNode root)
        {
            if (root == null) return true;
            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(root.left);
            s.Push(root.right);
            while (s.Count > 0)
            {
                var left = s.Pop();
                var right = s.Pop();
                if (left == null && right == null) continue;
                if (left == null || right == null) return false;
                if (left.val != right.val) return false;
                s.Push(left.left);
                s.Push(right.right);
                s.Push(left.right);
                s.Push(right.left);
            }
            return true;
        }

        //195 ms, beats 13%
        public bool IterativeUseQueue(TreeNode root)
        {
            if (root == null) return true;
            Queue<TreeNode> q1 = new Queue<TreeNode>(), q2 = new Queue<TreeNode>();
            q1.Enqueue(root.left);
            q2.Enqueue(root.right);
            while (q1.Count > 0 && q2.Count>0)
            {
                var left = q1.Dequeue();
                var right = q2.Dequeue();
                if (null == left && null == right)
                    continue;
                if (null == left || null == right)
                    return false;
                if (left.val != right.val)
                    return false;
                q1.Enqueue(left.left);
                q1.Enqueue(left.right);
                q2.Enqueue(right.right);
                q2.Enqueue(right.left);
            }
            return true;
        }
    }
}
