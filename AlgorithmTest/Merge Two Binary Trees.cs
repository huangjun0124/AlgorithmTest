using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Input: 
    Tree 1                     Tree 2                  
        1                         2                             
       / \                       / \                            
      3   2                     1   3                        
     /                           \   \                      
    5                             4   7                  
    Output: 
    Merged tree:
        3
       / \
      4   5
     / \   \ 
    5   4   7
    */
    class Merge_Two_Binary_Trees
    {
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            return GetMergeNode(t1, t2);
        }

        private static TreeNode GetMergeNode(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return null;
            var node = new TreeNode(0);
            if (t1 == null)
            {
                node.val = t2.val;
                node.left = t2.left;
                node.right = t2.right;
                return node;
            }
            if (t2 == null)
            {
                node.val = t1.val;
                node.left = t1.left;
                node.right = t1.right;
                return node;
            }
            node.val = t1.val + t2.val;
            node.left = GetMergeNode(t1.left, t2.left);
            node.right = GetMergeNode(t1.right, t2.right);
            return node;
        }

        // use stack
        public static TreeNode UseStackSolution(TreeNode t1, TreeNode t2)
        {
            TreeNode tree = new TreeNode(0);
            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(t1);
            s.Push(t2);
            s.Push(tree);
            // -1 means left, 1 means right
            Stack<int> direc = new Stack<int>();
            direc.Push(-1);
            while (s.Count > 0)
            {
                var node = s.Pop();
                t1 = s.Pop();
                t2 = s.Pop();
                var dir = direc.Pop();
                TreeNode tmpNode;
                if (t1 == null && t2 == null)
                {
                    tmpNode = null;
                }
                else if (t1 == null)
                {
                    tmpNode = t2;
                }
                else if (t2 == null)
                {
                    tmpNode = t1;
                }
                else
                {
                    tmpNode = new TreeNode(t1.val + t2.val);
                    s.Push(t1.left);
                    s.Push(t2.left);
                    s.Push(tmpNode);
                    direc.Push(-1);

                    s.Push(t1.right);
                    s.Push(t2.right);
                    s.Push(tmpNode);
                    direc.Push(1);
                }
                if (dir == -1)
                {
                    node.left = tmpNode;
                }
                else if (dir == 1)
                {
                    node.right = tmpNode;
                }
            }
            return tree.left;
        }
    }
}
