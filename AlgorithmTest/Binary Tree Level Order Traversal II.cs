using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).

    For example:
    Given binary tree[3, 9, 20, null, null, 15, 7],

         3
        / \
       9  20
         /  \
        15   7

return its bottom-up level order traversal as:
[
[15,7],
[9,20],
[3]
]
    */
    class Binary_Tree_Level_Order_Traversal_II
    {
        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (root == null) return ret;
            Dictionary<int, List<int>> levelResult = new Dictionary<int, List<int>>();
            int level = InOrderTraver(root, 1, levelResult);
            for (int i = level; i > 0; i--)
            {
                ret.Add(levelResult[i]);
            }
            return ret;
        }

        // OPT: Dictionary<int, List<int>>  actually can be replaced by a List, so use IList<IList<int>>


        private static int InOrderTraver(TreeNode node, int depth, Dictionary<int, List<int>> dic)
        {
            if (!dic.ContainsKey(depth))
            {
                dic.Add(depth, new List<int>(){node.val});
            }
            else
            {
                dic[depth].Add(node.val);
            }
            int left = 0, right = 0;
            if (node.left != null)
                left = InOrderTraver(node.left, depth + 1, dic);
            if (node.right != null)
                right = InOrderTraver(node.right, depth + 1, dic);
            if (node.left == null && node.right == null)
                return 1;
            return Math.Max(left, right) + 1;
        }


        public static List<List<int>> Solution2(TreeNode root)
        {
            List<List<int>> wrapList = new List<List<int>>();
            levelMaker(wrapList, root, 0);
            // Reverse wrapList here...todo
            return wrapList;
        }

        private static void levelMaker(List<List<int>> list, TreeNode root, int level)
        {
            if (root == null) return;
            if (level >= list.Count)
            {
                list.Add(new List<int>());
            }
            levelMaker(list, root.left, level + 1);
            levelMaker(list, root.right, level + 1);
            list[level].Add(root.val);
        }

        // BFS is the best solution here
        public static List<List<int>> Solution3(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<List<int>> wrapList = new List<List<int>>();
            if (root == null) return wrapList;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int levelNum = queue.Count;
                List<int> subList = new List<int>();
                for (int i = 0; i < levelNum; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                    subList.Add(node.val);
                }
                wrapList.Insert(0, subList);
            }
            return wrapList;
        }
    }
}
