using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Maximum_Product_of_Three_Numbers
    {
        // this is wrong when negtive two case : -4,-3,-2,-1,60
        public static int FindKMaxs(int[] nums)
        {
            int max , second , third;
            max = second = third = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    third = second;
                    second = max;
                    max = nums[i];
                }
                else if (nums[i] > second)
                {
                    third = second;
                    second = nums[i];
                }
                else if (nums[i] > third)
                {
                    third = nums[i];
                }
            }
            return max * second * third;
        }

        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            return Math.Max(nums[0] * nums[1] * nums[nums.Length - 1],
                nums[nums.Length - 3] * nums[nums.Length - 2] * nums[nums.Length - 1]);
        }

        public int FindKMaxsOptSolution(int[] nums)
        {
            int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue, min1 = int.MaxValue, min2 = int.MaxValue;
            foreach (int n in nums)
            {
                if (n > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = n;
                }
                else if (n > max2)
                {
                    max3 = max2;
                    max2 = n;
                }
                else if (n > max3)
                {
                    max3 = n;
                }

                if (n < min1)
                {
                    min2 = min1;
                    min1 = n;
                }
                else if (n < min2)
                {
                    min2 = n;
                }
            }
            return Math.Max(max1 * max2 * max3, max1 * min1 * min2);
        }
    }
}
