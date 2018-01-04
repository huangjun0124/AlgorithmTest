using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Max_Consecutive_Ones
    {

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int result = 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                    result = Math.Max(count, result);
                }
                else count = 0;
            }
            return result;
        }

        //Sliding window solution
        public static  int SolutionPrefer(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int res = 0;
            for (int left = 0; left < nums.Length; left++)
            {
                if (nums[left] == 0) continue;
                int right = left + 1;
                while (right < nums.Length && nums[right] == 1)
                {
                    right++;
                }
                res = Math.Max(res, right - left);
                left = right;
            }
            return res;
        }
    }
}
