using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a non-empty array of non-negative integers nums, the degree of this array is defined as the maximum frequency of any one of its elements.

    Your task is to find the smallest possible length of a (contiguous) subarray of nums, that has the same degree as nums.

    Example 1:

    Input: [1, 2, 2, 3, 1]
Output: 2
Explanation: 
The input array has a degree of 2 because both elements 1 and 2 appear twice.
Of the subarrays that have the same degree:
[1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2]
The shortest length is 2. So return 2.

Example 2:

Input: [1,2,2,3,1,4,2]
Output: 6

Note:
nums.length will be between 1 and 50,000.
nums[i] will be an integer between 0 and 49,999.
*/
    class Degree_of_an_Array
    {
        public static int FindShortestSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            // how many times the num has appeared so far
            Dictionary<int, int> apperance = new Dictionary<int, int>();
            // first apperance index of num
            Dictionary<int, int> startPos = new Dictionary<int, int>();
            int maxApperance = 0, maxEndPos = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!startPos.ContainsKey(nums[i]))
                {
                    startPos[nums[i]] = i;
                    apperance[nums[i]] = 1;
                }
                else apperance[nums[i]]++;
                if (maxApperance < apperance[nums[i]])
                {
                    // nums[i] repeat count max, change max to nums[i]
                    maxApperance = apperance[nums[i]];
                    maxEndPos = i;
                }
                else if (maxApperance == apperance[nums[i]])
                {
                    // nums[i] repeat count equals to before, if sub array length is shorter, change max to this
                    if ((maxEndPos - startPos[nums[maxEndPos]] + 1) - (i - startPos[nums[i]] + 1) > 0)
                    {
                        maxApperance = apperance[nums[i]];
                        maxEndPos = i;
                    }
                }
            }
            return maxEndPos - startPos[nums[maxEndPos]] + 1;
        }

        // save space...? may be not...but it is an idea
        public int findShortestSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            Dictionary<int, int[]> map = new Dictionary<int, int[]>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], new int[] { 1, i, i });  // the first element in array is degree, second is first index of this key, third is last index of this key
                }
                else
                {
                    int[] temp = map[nums[i]];
                    temp[0]++;
                    temp[2] = i;
                }
            }
            int degree = int.MinValue, res = Int32.MaxValue;
            foreach (int[] value in map.Values)
            {
                if (value[0] > degree)
                {
                    degree = value[0];
                    res = value[2] - value[1] + 1;
                }
                else if (value[0] == degree)
                {
                    res = Math.Min(value[2] - value[1] + 1, res);
                }
            }
            return res;
        }
    }
}
