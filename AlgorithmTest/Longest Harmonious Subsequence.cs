using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    We define a harmonious array is an array where the difference between its maximum value and its minimum value is exactly 1.

    Now, given an integer array, you need to find the length of its longest harmonious subsequence among all its possible subsequences.

    Example 1:

    Input: [1,3,2,2,5,2,3,7]
Output: 5
Explanation: The longest harmonious subsequence is [3,2,2,2,3].

Note: The length of the input array will not exceed 20,000.
    */
    class Longest_Harmonious_Subsequence
    {
        /*
         * 分析：子序列中最大和最小的元素差为1， 
         * 即有n个i，m个i+1的子序列就满足条件，而i和i+1在原来序列中的顺序无关紧要
         * 所以找满足条件的i和i+1出现次数最多的即可
         *[1,3,2,2,5,2,3,7]*/ 
        public static int FindLHS(int[] nums)
        {
            Array.Sort(nums);
            int result = 0;
            int left = 0, right = 0;
            while (right < nums.Length)
            {
                int diff = nums[right] - nums[left];
                if (diff == 0)
                    right++;
                else if (diff == 1)
                {
                    result = Math.Max(result, right - left + 1);
                    right++;
                }
                else
                    left++;
            }
            return result;
        }//310 ms

        //先统计每个元素出现的次数，然后对统计结果：如果某元素+1的值存在，那么求出他们出现的和即可
        public static int Solution2(int[] nums)
        {
            Dictionary<int, int> numShowCount = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (numShowCount.ContainsKey(num)) numShowCount[num]++;
                else numShowCount[num] = 1;
            }
            int max = 0;
            foreach (var key in numShowCount.Keys)
            {
                if (numShowCount.ContainsKey(key + 1))
                {
                    max = Math.Max(max, numShowCount[key] + numShowCount[key + 1]);
                }
            }
            return max;
        }//Runtime: 308 ms
    }
}
