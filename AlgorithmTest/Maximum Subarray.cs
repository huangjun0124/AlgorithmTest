using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Maximum_Subarray
    {

        // O(n^2)
        public static int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                int tempMax = nums[i], plus = nums[i];
                for (int j = i+1; j < nums.Length; j++)
                {
                    plus += nums[j];
                    if (tempMax < plus)
                    {
                        tempMax = plus;
                    }
                }
                if (max < tempMax) max = tempMax;
            }
            return max;
        }


        // O(n)
        public static int Solution2(int[] nums)
        {
            int maxSoFar = nums[0], maxEndingHere = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                maxEndingHere = Math.Max(maxEndingHere + nums[i], nums[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }

        // O(n)
        public static int Solution3(int[] nums)
        {
            int ans = nums[0], sum = 0;
            foreach (int t in nums)
            {
                sum += t;
                ans = Math.Max(sum, ans);
                sum = Math.Max(sum, 0);
            }
            return ans;
        }
    }
}
