using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a binary search tree and the lowest and highest boundaries as L and R, trim the tree so that all its elements lies in [L, R] (R >= L). You might need to change the root of the tree, so the result should return the new root of the trimmed binary search tree.

    Example 1:
    Input: 
         1
        / \
       0   2

    L = 1
    R = 2

    Output: 
        1
         \
          2

    Example 2:

    Input: 
         3
        / \
       0   4
        \
         2
        /
       1

    L = 1
    R = 3

    Output: 
        3
       / 
      2   
     /
    1
 */
    class Trim_a_Binary_Search_Tree
    {
        public class Solution
        {
            public static TreeNode TrimBST(TreeNode root, int L, int R)
            {
                if (root == null) return null;
                if (root.val < L)
                    return TrimBST(root.right, L, R);
                if (root.val > R)
                    return TrimBST(root.left, L, R);
                root.left = TrimBST(root.left, L, R);
                root.right = TrimBST(root.right, L, R);
                return root;
            }

            public static TreeNode Solution2(TreeNode root, int L, int R)
            {

                // find the proper root
                while (root.val < L || root.val > R)
                {
                    if (root.val < L) { root = root.right; }
                    else { root = root.left; }
                }

                // temporary pointer for left and right subtree
                TreeNode Ltemp = root;
                TreeNode Rtemp = root;

                // remove the elements larger than L
                while (Ltemp.left != null)
                {
                    if ((Ltemp.left.val) < L) { Ltemp.left = Ltemp.left.right; }
                    else { Ltemp = Ltemp.left; }
                }
                // remove the elements larger than R
                while (Rtemp.right != null)
                {
                    if ((Rtemp.right.val) > R) { Rtemp.right = Rtemp.right.left; }
                    else { Rtemp = Rtemp.right; }
                }
                return root;
            }
        }
    }
}
