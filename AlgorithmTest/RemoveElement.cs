using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class RemoveElement
    {
        public static int RemoveElementSolution(int[] nums, int val)
        {
            int pos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[pos++] = nums[i];
                }
            }
            return pos;
        }

        public static int Solution2(int[] nums, int val)
        {
            int n = nums.Length;
            int i = 0;
            while (i < n)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[n - 1];
                    n--;
                }
                else
                    i++;
            }
            return n;
        }
    }
}
