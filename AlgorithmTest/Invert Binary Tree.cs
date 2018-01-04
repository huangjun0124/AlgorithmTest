using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Invert_Binary_Tree
    {
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }

        // Use stack or queue, they both work well
        public static TreeNode Solution2(TreeNode root)
        {
            if (root == null) return null;
            //Stack<TreeNode> s = new Stack<TreeNode>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            //s.Push(root);
            q.Enqueue(root);
            //while (s.Count > 0)
            while (q.Count > 0)
            {
                //var node = s.Pop();
                var node = q.Dequeue();
                var tmp = node.left;
                node.left = node.right;
                node.right = tmp;
                if(node.left != null)
                    //s.Push(node.left);
                    q.Enqueue(node.left);
                if(node.right != null)
                    //s.Push(node.right);
                    q.Enqueue(node.right);
            }
            return root;
        }
    }
}
