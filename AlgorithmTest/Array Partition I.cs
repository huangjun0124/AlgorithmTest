using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given an array of 2n integers, your task is to group these integers into n pairs of integer, say(a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.

    Example 1:
    Input: [1,4,3,2]
    Output: 4
    Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3, 4).

Note:
n is a positive integer, which is in the range of[1, 10000].
All the integers in the array will be in the range of[-10000, 10000].
    */
    class Array_Partition_I
    {
        // Sort, then accumulate 1,3,5,7...
        public static int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int ret = 0;
            for (int i = 0; i < nums.Length; i+=2)
            {
                ret += nums[i];
            }
            return ret;
        }

        /*
        suppose that all the integers in the array will be in the range of[0, 10000] rather than[-10000, 10000]. We create an array, named hashtable, whose capacity should be(10000 - 0) + 1 = 10001. This array is used to keep track of the times that an element appears in the original array.

            The key is to use the element itself as the index.For example, we traverse nums, if we encounter a 5, just do hashtable[5]++;; if we encounter a ‘9’, do hashtable[9]++;, and so on.This is what the first for loop used to do.

        In the second loop, we traverse hashtable.If hashtable[0] == 2, which means there are two 0 in nums, so the sorted array should start with two 0; if hashtable[1] == 3, there should be three 1 after those two 0, etc.

            Here we set two variables, flag and count.Since we just have to calculate the sum of min(ai, bi), which is the same to the sum of elements in even-index positions(0, 2, 4, …) in the sorted array.flag labels whether the element is in an even or odd position, and count is a sentinel that stops the loop.

            Each time we encounter an element, do --hashtable[i] to record we have already dealt with it.But i should not increase by 1 every time. Say if we have hashtable[5] == 2, after we dealt with the first 5, i should keep being 5 so we will encounter the second 5 later.That’s why we use:

        if (--hashtable[i] == 0)
        {
            i++;
        }

        In the problem, the range of elements is [-10000, 10000], so we have to create an hashtable of length 10000 - (-10000) + 1 = 20001; in the first loop, use hashtable[nums[i] + 10000]++; instead so that indices would not be negative; in the second loop, use ret += i - 10000; to neutralize that 10000 added before.

            I think this is clear enough. The time complexity should be O(n). This method is especially useful if we know the range of elements, and the range is not very large (like[INT_MIN, INT_MAX]) (or the space complexity will be huge).
            */
        public static int Solution2(int[] nums)
        {
            int ret = 0;
            bool flag = true;// used to bypass one after current(0->2->4)
            int[] hashtable = new int[20001];
            foreach (var n in nums)
            {
                ++hashtable[n + 10000];
            }
            for (int i = 0; i < 20001;)
            {
                if (hashtable[i] > 0)
                {
                    if (flag)
                    {
                        flag = false;
                        ret += (i - 10000);
                        --hashtable[i];
                    }
                    else
                    {
                        flag = true;
                        --hashtable[i];
                    }
                }
                else
                    ++i;
            }
            return ret;
        }
    }
}
