using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Sum_of_Left_Leaves
    {
        public static int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;
            return (root.left != null
                ? TravelFromLeft(root.left)
                : 0) + (root.right != null
                    ? TravelFromRight(root.right)
                    : 0);
        }

        private static int TravelFromLeft(TreeNode node)
        {
            if (node.left == null && node.right == null) return node.val;
            int left = 0, right = 0;
            if (node.left != null)
                left = TravelFromLeft(node.left);
            if (node.right != null)
                right = TravelFromRight(node.right);
            return left + right;
        }

        private static int TravelFromRight(TreeNode node)
        {
            if (node.left == null && node.right == null) return 0;
            int left = 0, right = 0;
            if (node.left != null)
                left = TravelFromLeft(node.left);
            if (node.right != null)
                right = TravelFromRight(node.right);
            return left + right;
        }

        public int Solution2(TreeNode root)
        {
            return sumOfLeftLeavesHelper(root, false);
        }

        private int sumOfLeftLeavesHelper(TreeNode root, bool b)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null)
            {
                if (b) return root.val;
                return 0;
            }
            return sumOfLeftLeavesHelper(root.left, true) + sumOfLeftLeavesHelper(root.right, false);
        }
    }
}
