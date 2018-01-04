using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Average_of_Levels_in_Binary_Tree
    {
        public static IList<double> AverageOfLevels(TreeNode root)
        {
            Dictionary<int, double> depthSum = new Dictionary<int, double>();
            Dictionary<int, int> depthNum = new Dictionary<int, int>();
            TraverseTree(root, 1, depthSum, depthNum);
            List<double> ret = new List<double>();
            foreach (var d in depthSum.Keys)
            {
                ret.Add(depthSum[d] / depthNum[d]);
            }
            return ret;
        }

        public static void TraverseTree(TreeNode node, int depth, Dictionary<int, double> dicSum, Dictionary<int, int> dicNum)
        {
            if (node == null) return;
            if (!dicSum.ContainsKey(depth))
            {
                dicSum[depth] = node.val;
                dicNum[depth] = 1;
            }
            else
            {
                dicSum[depth] += node.val;
                dicNum[depth]++;
            }
            if(node.left != null)
                TraverseTree(node.left, depth + 1, dicSum, dicNum);
            if(node.right != null)
                TraverseTree(node.right, depth + 1, dicSum, dicNum);
        }

        //Use a Queue 
        public static IList<double> Solution2(TreeNode root)
        {
            List<Double> result = new List<double>();
            Queue<TreeNode> q = new Queue<TreeNode>();

            if (root == null) return result;
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int n = q.Count;
                double sum = 0.0;
                for (int i = 0; i < n; i++)
                {
                    TreeNode node = q.Dequeue();
                    sum += node.val;
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
                result.Add(sum / n);
            }
            return result;
        }


        // Use two stack
        public static IList<double> Solution3(TreeNode root)
        {
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            List<Double> averageList = new List<double>();
            stack1.Push(root);
            double sum = 0;
            int count = 0;
            while (stack1.Count>0 || stack2.Count>0)
            {
                sum = 0;
                count = 0;
                while (stack1.Count>0)
                {
                    TreeNode t = stack1.Pop();
                    sum += t.val;
                    count++;
                    if (t.left != null)
                        stack2.Push(t.left);
                    if (t.right != null)
                        stack2.Push(t.right);
                }
                if (count != 0)
                {
                    averageList.Add(sum / count);
                }
                sum = 0;
                count = 0;
                while (stack2.Count > 0)
                {
                    TreeNode t = stack2.Pop();
                    sum += t.val;
                    count++;
                    if (t.left != null)
                        stack1.Push(t.left);
                    if (t.right != null)
                        stack1.Push(t.right);
                }
                if (count != 0)
                {
                    averageList.Add(sum / count);
                }
            }
            return averageList;
        }

        // this is a fucking stupid question
        public static int FindLUSlength(string a, string b)
        {
            return a.Equals(b) ? -1 : Math.Max(a.Length, b.Length);
        }
    }
}
