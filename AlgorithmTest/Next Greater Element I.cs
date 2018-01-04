using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    You are given two arrays(without duplicates) nums1 and nums2 where nums1’s elements are subset of nums2.Find all the next greater numbers for nums1's elements in the corresponding places of nums2.


    The Next Greater Number of a number x in nums1 is the first greater number to its right in nums2.If it does not exist, output -1 for this number.

Example 1:
Input: nums1 = [4, 1, 2], nums2 = [1, 3, 4, 2].
Output: [-1,3,-1]
Explanation:

For number 4 in the first array, you cannot find the next greater number for it in the second array, so output -1.

For number 1 in the first array, the next greater number for it in the second array is 3.

For number 2 in the first array, there is no next greater number for it in the second array, so output -1.


Example 2:
Input: nums1 = [2, 4], nums2 = [1, 2, 3, 4].
Output: [3,-1]
Explanation:

For number 2 in the first array, the next greater number for it in the second array is 3.

For number 4 in the first array, there is no next greater number for it in the second array, so output -1.


Note:


All elements in nums1 and nums2 are unique.
The length of both nums1 and nums2 would not exceed 1000.
    */
    class Next_Greater_Element_I
    {
        /*
        Suppose we have a decreasing sequence followed by a greater number
            For example[5, 4, 3, 2, 1, 6] then the greater number 6 is the next greater element for all previous numbers in the sequence

        We use a stack to keep a decreasing sub-sequence, whenever we see a number x greater than stack.peek() we pop all elements less than x and for all the popped ones, their next greater element is x
            For example[9, 8, 7, 3, 2, 1, 6]
        The stack will first contain[9, 8, 7, 3, 2, 1] and then we see 6 which is greater than 1 so we pop 1 2 3 whose next greater element should be 6
            */
        public static int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var f in findNums)
            {
                dic[f] = -1;
            }
            Stack<int> s = new Stack<int>();
            foreach (var n in nums)
            {
                while (s.Count > 0 && s.Peek() < n)
                {
                    dic[s.Pop()] = n;
                }
                if(dic.ContainsKey(n))
                    s.Push(n);
            }
            for (int i = 0; i < findNums.Length; i++)
            {
                findNums[i] = dic[findNums[i]];
            }
            return findNums;
        }
    }
}
