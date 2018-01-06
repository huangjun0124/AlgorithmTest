using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

    For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.

    Example:

    Given the sorted array: [-10,-3,0,5,9],

    One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:

        0
       / \
      -3   9
     /   /
   -10  5
*/
    class Convert_Sorted_Array_to_Binary_Search_Tree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;
            return BuildNode(nums, 0, nums.Length - 1);
        }

        private TreeNode BuildNode(int[] nums, int l, int h)
        {
            int m = (l + h) / 2;
            TreeNode node = new TreeNode(nums[m]);
            if (l == m)
                node.left = null;
            else
                node.left = BuildNode(nums, l, m - 1);
            if (h == m)
                node.right = null;
            else
                node.right = BuildNode(nums, m + 1, h);
            return node;
        }

        public TreeNode BuildNode2(int[] num, int low, int high)
        {
            if (low > high)
            { // Done
                return null;
            }
            int mid = low + (high - low) / 2; // avoids integer overflow
            TreeNode node = new TreeNode(num[mid]);
            node.left = BuildNode2(num, low, mid - 1);
            node.right = BuildNode2(num, mid + 1, high);
            return node;
        }

        // Iterative...
        public TreeNode Solution2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return null;
            }
            Queue<MyNode> queue = new Queue<MyNode>();
            int left = 0;
            int right = nums.Length - 1;
            int val = nums[left + (right - left) / 2];
            TreeNode root = new TreeNode(val);
            queue.Enqueue(new MyNode(root, left, right));

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    MyNode cur = queue.Dequeue();
                    int mid = cur.lb + (cur.rb - cur.lb) / 2;
                    if (mid != cur.lb)
                    {
                        TreeNode leftChild = new TreeNode(nums[cur.lb + (mid - 1 - cur.lb) / 2]);
                        cur.node.left = leftChild;
                        queue.Enqueue(new MyNode(leftChild, cur.lb, mid - 1));
                    }
                    if (mid != cur.rb)
                    {
                        TreeNode rightChild = new TreeNode(nums[mid + 1 + (cur.rb - mid - 1) / 2]);
                        cur.node.right = rightChild;
                        queue.Enqueue(new MyNode(rightChild, mid + 1, cur.rb));
                    }
                }
            }
            return root;
        }

        private class MyNode
        {
            public TreeNode node;
            public int lb;
            public int rb;

            public MyNode(TreeNode n, int theLeft, int theRight)
            {
                this.node = n;
                this.lb = theLeft;
                this.rb = theRight;
            }
        }
    }
}
