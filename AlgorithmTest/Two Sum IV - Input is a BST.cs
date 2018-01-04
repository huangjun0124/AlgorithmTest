using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Two_Sum_IV___Input_is_a_BST
    {
        /*
        This method also works for those who are not BSTs.The idea is to use a hashtable to save the values of the nodes in the BST.Each time when we insert the value of a new node into the hashtable, we check if the hashtable contains k - node.val.

            Time Complexity: O(n), Space Complexity: O(n).
            */
        public bool FindTarget(TreeNode root, int k)
        {
            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                int diff = k - node.val;
                if (dic.ContainsKey(diff))
                    return true;
                dic[node.val] = true;
                if(node.left != null) nodes.Enqueue(node.left);
                if (node.right != null) nodes.Enqueue(node.right);
            }
            return false;
        }

        /*
        The idea is to use a sorted array to save the values of the nodes in the BST by using an inorder traversal.Then, we use two pointers which begins from the start and end of the array to find if there is a sum k.

            Time Complexity: O(n), Space Complexity: O(n).
        */
        public bool Solution2(TreeNode root, int k)
        {
            List<int> nums = new List<int>();
            inorder(root, nums);
            for (int i = 0, j = nums.Count- 1; i < j;)
            {
                if (nums[i] + nums[j] == k) return true;
                if (nums[i] + nums[j] < k) i++;
                else j--;
            }
            return false;
        }

        public void inorder(TreeNode root, List<int> nums)
        {
            if (root == null) return;
            inorder(root.left, nums);
            nums.Add(root.val);
            inorder(root.right, nums);
        }

        /*
        Use binary search method.For each node, we check if k - node.val exists in this BST.

            Time Complexity: O(nlogn), Space Complexity: O(h). h is the height of the tree, which is logn at best case, and n at worst case.
        */
        TreeNode root;
        //DFS each node, and try to search the target 'node' such that 'node'.val = k-node.val
        //make sure you don't pick the node itself, like if k = 2 and node.val = 1, don't return node itself!
        public bool Solution3(TreeNode node, int k)
        {
            this.root = node;//set variable for the root of this tree
            return SearchTarget(root, k);
        }

        private bool SearchTarget(TreeNode node, int k)
        {
            if (node == null) return false;
            if (searchForValueFromRoot(node, k - node.val)) return true;//make sure you don't find the node itself!
            return SearchTarget(node.left, k) || SearchTarget(node.right, k);//DFS traverse
        }

        private bool searchForValueFromRoot(TreeNode node, int k)
        {
            TreeNode current = root;//search from the root node
            while (current != null)
            {
                if (k > current.val) current = current.right;
                else if (k < current.val) current = current.left;
                else return current != node;//you can't find the node itself!
            }
            return false;
        }

    }
}
