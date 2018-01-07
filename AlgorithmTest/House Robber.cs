using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    You are a professional robber planning to rob houses along a street.Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

    Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
    */
    class House_Robber
    {
        // this solution you can alrt the police and run away
        public int Rob(int[] nums)
        {
            if (nums.Length == 2) return nums[0] + nums[1];
            int evenSum = 0, oddSum = 0;
            int left = 0, tmp;
            for (int i = 0; i < nums.Length; i+=2)
            {
                if (i < nums.Length - 1)
                {
                    tmp = left + nums[i] + nums[i + 1];
                    if (tmp > evenSum)
                        evenSum = tmp;
                }
                left += nums[i];
            }
            if (left > evenSum) evenSum = left;
            left = 0;
            for (int i = 1; i < nums.Length; i += 2)
            {
                if (i < nums.Length - 1)
                {
                    tmp = left + nums[i] + nums[i + 1];
                    if (tmp > oddSum)
                        oddSum = tmp;
                }
                left += nums[i];
            }
            if (left > oddSum) oddSum = left;
            return Math.Max(oddSum, evenSum);
        }

        /*
        5       3       2        4 
        a=5     b=5     a=7      b=9
        //this is the right way */
        public int Solution(int[] nums)
        {
            int a = 0, b = 0;
            bool flag = true;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    a = Math.Max(a + nums[i], b);
                }
                else
                {
                    b = Math.Max(a, b + nums[i]);
                }
            }
            return Math.Max(a, b);
        }

        /*
        dp[i] means the most value that can be robbed before the ith store.For each store, we have two choice: rob or not rob:
        (1)if robbing, d[i] = d[i - 2] + nums[i], for stores robbed cannot be connected.
        (2)if not robbing, d[i] = d[i - 1];
        */
        public int Solution2(int[] nums)
        {
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[nums.Length - 1];
        }

        public int Solution3(int[] nums)
        {
            int n = nums.Length, pre = 0, cur = 0;
            for (int i = 0; i < n; i++)
            {
                int temp = Math.Max(pre + nums[i], cur);
                pre = cur;
                cur = temp;
            }
            return cur;
        }
    }
}
