using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Majority_Element
    {
        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> appearance = new Dictionary<int, int>();
            int i = 0;
            for (; i < nums.Length; i++)
            {
                if (!appearance.ContainsKey(nums[i]))
                {
                    appearance[nums[i]] = 1;
                }
                else
                {
                    appearance[nums[i]]++;
                }
                if (appearance[nums[i]] > nums.Length / 2)
                    break;
            }
            return nums[i];
        }

        public int Solution2(int[] nums)
        {
            Array.Sort(nums);
            int len = nums.Length;
            return nums[len / 2];
        }
    }
}
