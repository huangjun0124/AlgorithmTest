using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Missing_Number
    {
        public int MissingNumber(int[] nums)
        {
            bool findN = false, zeroInverted = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int n = nums[i];
                if (n < 0) n *= -1;
                if (n == nums.Length)
                    findN = true;
                else
                {
                    if (nums[n] == 0)
                        zeroInverted = true;
                    nums[n] *= -1;
                }
            }
            if (!findN) return nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) return i;
                if (nums[i] == 0 && !zeroInverted) return i;
            }
            return -1;
        }

        // From 0 -> n, all show with pairs except the one missing
        public static int Solution2(int[] nums)
        {
            int xor = 0, i;
            for (i = 0; i < nums.Length; i++)
            {
                xor = xor ^ i ^ nums[i];
            }
            return xor ^ i;
        }

        // Sum(0,1,...,n) - Sum(nums[0],...nums[n-1)
        public static int missingNumber(int[] nums)
        {
            int sum = nums.Length;
            for (int i = 0; i < nums.Length; i++)
                sum += i - nums[i];
            return sum;
        }

        /*
        there are two cases after sorting the nums
        one: from large to small order, they are arithmetic sequence, just like[0, 1, 2, 3],now it must miss the last item n = 4, so you return 3+1=4
        two: from large to small order,they are not arithmetic sequence as one item missed among them,just like[0, 1, 2, 4], so you return 3
        so give my solution not using XOR:
        */
        public int Solution3(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i]) return i;
            }
            return nums[nums.Length - 1] + 1;
        }
    }
}
