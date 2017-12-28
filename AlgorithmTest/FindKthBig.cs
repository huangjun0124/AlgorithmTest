using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class FindKthBig
    {
        public static int Solve(int[] nums, int k)
        {
            return QuickSort(nums, 0, nums.Length - 1, k);
        }

        private static int QuickSort(int[] nums, int left, int right, int k)
        {
            int i = left;
            int j = right;
            int tmp = nums[i];
            // big -> left; small -> right
            while (i < j)
            {
                while (i < j && tmp >= nums[j]) j--;
                if (i < j)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                }
                while (i < j && tmp < nums[i]) i++;
                if (i < j)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    j--;
                }
            }
            if (i == k - 1)
            {
                return tmp;
            }
            if (i < k - 1)
            {
                return QuickSort(nums, i + 1, right, k);
            }
            return QuickSort(nums, left, i - 1, k);
        }
    }
}
