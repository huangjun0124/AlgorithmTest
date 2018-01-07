using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    The set S originally contains numbers from 1 to n.But unfortunately, due to the data error, one of the numbers in the set got duplicated to another number in the set, which results in repetition of one number and loss of another number.

    Given an array nums representing the data status of this set after the error. Your task is to firstly find the number occurs twice and then find the number that is missing.Return them in the form of an array.

    Example 1:


    Input: nums = [1, 2, 2, 4]
Output: [2,3]

Note:


The given array size will in the range [2, 10000].

The given array's numbers won't have any order.
    */
    class Set_Mismatch
    {
        public int[] FindErrorNums(int[] nums)
        {
            int[] ret = new int[2];
            HashSet<int> set = new HashSet<int>();
            foreach (var num in nums)
            {
                if (!set.Add(num))
                    ret[0] = num;
            }
            for (int i = 1; i <= nums.Length; i++)
            {
                if (!set.Contains(i))
                    ret[1] = i;
            }
            return ret;
        }

        // this is slow...
        public int[] Solution2(int[] nums)
        {
            int[] ret = new int[2];
            Array.Sort(nums);
            for (int i = 0; i < nums.Length-1; i++)
            {
                if (nums[i] == nums[i + 1])
                    ret[0] = nums[i];
                else if (nums[i + 1] - nums[i] > 1)
                    ret[1] = nums[i + 1] - 1;
            }
            // [2,2,3] or [1,1,2] or [1,1] or [1,1,2,3] etc
            if (ret[1] == 0) // missing value not found by before
            {
                //[2,2,3]
                if(nums[0] != 1)
                    ret[1] = 1;
                else // [1,1,2,3]
                    ret[1] = nums.Length;
            }
            return ret;
        }

        // use negtive cur value to simulate HashMap
        public static int[] BestSolution(int[] nums)
        {
            int[] res = new int[2];
            foreach (int num in nums)
            {
                if (nums[Math.Abs(num) - 1] < 0) res[0] = Math.Abs(num);
                else nums[Math.Abs(num) - 1] *= -1;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) res[1] = i + 1;
            }
            return res;
        }
    }
}
