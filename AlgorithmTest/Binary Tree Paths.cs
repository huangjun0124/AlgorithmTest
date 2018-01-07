using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a binary tree, return all root-to-leaf paths.

    For example, given the following binary tree:
        1
      /   \
     2     3
      \
       5
    All root-to-leaf paths are:
    ["1->2->5", "1->3"]
    */
    class Binary_Tree_Paths
    {
        List<string> ret = new List<string>();
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            if (root == null) return ret;
            Traverse(root, "");
            return ret;
        }

        private void Traverse(TreeNode node, string prefix)
        {
            if (node.left == null && node.right == null)
            {
                ret.Add(prefix + node.val);
            }
            if (node.left != null)
            {
                Traverse(node.left, prefix + node.val + "->");
            }
            if(node.right != null)
            {
                Traverse(node.right, prefix + node.val + "->");
            }
        }
    }
}
