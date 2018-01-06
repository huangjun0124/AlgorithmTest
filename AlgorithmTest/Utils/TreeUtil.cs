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

    class TreeUtil
    {
        public static TreeNode BuildTree(int?[] nums)
        {
            TreeNode[] nodes = new TreeNode[nums.Length];
            int end = nums.Length / 2;
            for (int i = nums.Length-1; i > -1; i--)
            {
                if (nums[i].HasValue)
                {
                    TreeNode node = new TreeNode(nums[i].Value);
                    nodes[i] = node;
                    if (i < end)
                    {
                        node.left = nodes[2 * i + 1];
                        node.right = nodes[2 * (i + 1)];
                    }
                }
                else
                {
                    nodes[i] = null;
                }
            }
            return nodes[0];
        }
    }
}
