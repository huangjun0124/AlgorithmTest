using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ConsoleApp1
{
    class TwoSum
    {
        public static int[] TwoSumSolution(int[] nums, int target)
        {
            int[] ret = new int[2];
            for (int i = 0; i < nums.Length-1; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        ret[0] = i;
                        ret[1] = j;
                        return ret;
                    }
                }
            }
            return ret;
        }

        public static int[] TwoSum2(int[] numbers, int target)
        {
            int[] res = new int[2];
            if (numbers == null || numbers.Length < 2)
                return null;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int diff = target - numbers[i];
                if (map.ContainsKey(diff))
                {
                    res[0] = map[diff] + 1;
                    res[1] = i + 1;
                    return res;
                }
                map[numbers[i]] = i;
            }
            return null;
        }
    }
}
