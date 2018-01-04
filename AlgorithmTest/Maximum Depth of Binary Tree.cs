using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Maximum_Depth_of_Binary_Tree
    {
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        // Use a Queue, similiar to Average_of_Levels_in_Binary_Tree
        public static int Solution2(TreeNode root)
        {
            if (root == null) return 0;
            int ret = 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                ret++;
                int n = q.Count;
                while (n > 0)
                {
                    var tmp = q.Dequeue();
                    if(tmp.left != null) q.Enqueue(tmp.left);
                    if(tmp.right != null) q.Enqueue(tmp.right);
                    n--;
                }
            }
            return ret;
        }
    }
}
