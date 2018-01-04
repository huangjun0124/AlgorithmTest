using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Move_Zeroes
    {
        public static void MoveZeroes(int[] nums)
        {
            int zeros = 0;
            foreach (var n in nums)
            {
                if (n == 0) zeros++;
            }
            int j = 0;
            for (int i = 0; j < nums.Length - zeros; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j++] = nums[i];
                }
            }
            for (; j < nums.Length ; j++)
            {
                nums[j] = 0;
            }
        }


        public void moveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;
            int insertPos = 0;
            foreach (var num in nums)
            {
                if (num != 0) nums[insertPos++] = num;
            }
            while (insertPos < nums.Length)
            {
                nums[insertPos++] = 0;
            }
        }
    }
}
