using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a binary tree, find the lowest common ancestor(LCA) of two given nodes in the tree.

    According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”

          _______3______
         /              \
     ___5__          ___1__
    /      \        /      \
    6      _2       0       8
          /  \
         7   4

    For example, the lowest common ancestor(LCA) of nodes 5 and 1 is 3. Another example is LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.
    */
    class Lowest_Common_Ancestor_of_a_Binary_Tree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (left != null && right != null) return root;
            return left ?? right;
        }

        //先从root遍历到p和q，记录每个node的父节点
        //然后对p，从p往上遍历到root，加入HashSet
        //然后对q，从q往上遍历，遇到第一个在HashSet中的节点，返回之
        public TreeNode IterativeVersion(TreeNode root, TreeNode p, TreeNode q)
        {
            Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            parent[root] = null;
            stack.Push(root);
            while (!parent.ContainsKey(p) || !parent.ContainsKey(q))
            {
                TreeNode node = stack.Pop();
                if (node.left != null)
                {
                    parent[node.left] = node;
                    stack.Push(node.left);
                }
                if (node.right != null)
                {
                    parent[node.right] = node;
                    stack.Push(node.right);
                }
            }
            HashSet<TreeNode> ancestors = new HashSet<TreeNode>();
            while (p != null)
            {
                ancestors.Add(p);
                p = parent[p];
            }
            while (!ancestors.Contains(q))
                q = parent[q];
            return q;
        }
    }
}
