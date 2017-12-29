using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class RemoveDuplicatesfromSortedArray
    {
        // diff indicates how many position(duplications) is removed
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;
            int diff = 0;
            int before = nums[0];
            for (int i = 1; i+diff < nums.Length;)
            {
                if (before == nums[i])
                {
                    diff++;
                    if (i + diff > nums.Length - 1) break;
                    // move number in position [i+diff] to i
                    nums[i] = nums[i + diff];
                }
                else
                { 
                    before = nums[i];
                    if (i + diff + 1 > nums.Length - 1) break;
                    // move i forward one position, and its value assigned to number in position [i+diff]
                    nums[++i] = nums[i + diff];
                }
            }
            return nums.Length - diff;
        }

        public static int Solution2(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;
            int id = 1;
            for (int i = 1; i < nums.Length; ++i)
                if (nums[i] != nums[i - 1]) nums[id++] = nums[i];
            return id;
        }

        public static int Solution3(int[] nums)
        {
            int pos = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (i == 0 || nums[i] != nums[pos - 1])
                    nums[pos++] = nums[i];
            }
            return pos;
        }
    }
}
