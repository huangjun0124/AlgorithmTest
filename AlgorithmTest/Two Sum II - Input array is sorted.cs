using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
       Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.

           The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.Please note that your returned answers (both index1 and index2) are not zero-based.

           You may assume that each input would have exactly one solution and you may not use the same element twice.

           Input: numbers={ 2, 7, 11, 15}, target=9
   Output: index1=1, index2=2 
   */
    class Two_Sum_II___Input_array_is_sorted
    {
       // this does not use the sorted attribute given by this problem
        public static int[] TwoSum(int[] numbers, int target)
        {
            int[] ret = new int[2];
            Dictionary<int, int> num2index = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (num2index.ContainsKey(target - numbers[i]))
                {
                    ret[0] = num2index[target - numbers[i]];
                    ret[1] = i + 1;
                    break;
                }
                num2index[numbers[i]] = i + 1;
            }
            return ret;
        }

        // binary search, faster!
        public static int[] Solution2(int[] numbers, int target)
        {
            int[] ret = new int[2];
            int low = 0, high = numbers.Length - 1;
            while (low < high)
            {
                int sum = numbers[low] + numbers[high];
                if (sum == target)
                {
                    ret[0] = low + 1;
                    ret[1] = high + 1;
                    break;
                }
                if (sum < target)
                    low++;
                else
                    high--;
            }
            return ret;
        }

        //use for and within it use a binary search
        public static int[] Solution3(int[] numbers, int target)
        {
            if (numbers.Length == 0) return new int[]{};
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int start = i + 1, end = numbers.Length - 1, gap = target - numbers[i];
                while (start <= end)
                {
                    int m = start + (end - start) / 2;
                    if (numbers[m] == gap) return new int[]{ i + 1, m + 1};
                    if (numbers[m] > gap) end = m - 1;
                    else start = m + 1;
                }
            }
            return null;
        }
    }
}
