using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given an unsorted array of integers, find the length of longest continuous increasing subsequence(subarray).

    Example 1:

    Input: [1,3,5,4,7]
Output: 3
Explanation: The longest continuous increasing subsequence is [1,3,5], its length is 3. 
Even though[1, 3, 5, 7] is also an increasing subsequence, it's not a continuous one where 5 and 7 are separated by 4. 

Example 2:

Input: [2,2,2,2,2]
Output: 1
Explanation: The longest continuous increasing subsequence is [2], its length is 1. 

Note: Length of the array will not exceed 10,000. 
    */
    class Longest_Continuous_Increasing_Subsequence
    {
        public static int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int maxLength = 1, length = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    if (++length > maxLength)
                        maxLength = length;
                }
                else length = 1;
            }
            return maxLength;
        }

        // DP solution
        public int Solution2(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int n = nums.Length;
            int[] dp = new int[n];
            int max = 1;
            dp[0] = 1;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    dp[i] = dp[i - 1] + 1;
                }
                else
                {
                    dp[i] = 1;
                }
                max = Math.Max(max, dp[i]);
            }
            return max;
        }
    }
}
