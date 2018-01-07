﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a binary search tree(BST), find the lowest common ancestor(LCA) of two given nodes in the BST.

    According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”

         _______6______
        /              \
     ___2__          ___8__
    /      \        /      \
    0      _4_       7       9
          /   \
         3     5

    For example, the lowest common ancestor(LCA) of nodes 2 and 8 is 6. Another example is LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.
    */
    class Lowest_Common_Ancestor_of_a_Binary_Search_Tree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > p.val && root.val > q.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else if (root.val < p.val && root.val < q.val)
            {
                return LowestCommonAncestor(root.right, p, q);
            }
            else
            {
                return root;
            }
        }

        public TreeNode Solution2(TreeNode root, TreeNode p, TreeNode q)
        {
            while ((root.val - p.val) * (root.val - q.val) > 0)
                root = p.val < root.val ? root.left : root.right;
            return root;
        }
    }
}
