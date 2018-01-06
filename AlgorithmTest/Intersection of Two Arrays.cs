using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Intersection_of_Two_Arrays
    {
        public static int[] intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var n in nums1)
            {
                set.Add(n);
            }
            HashSet<int> ret = new HashSet<int>();
            foreach (var n in nums2)
            {
                if (set.Contains(n))
                {
                    ret.Add(n);
                }
            }
            return ret.ToArray();
        }

        public static int[] Solution2(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int i = 0, j = 0;
            HashSet<int> ret = new HashSet<int>();
            while (i<nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    ret.Add(nums1[i]);
                    i++;
                    j++; 
                }
                else if (nums1[i] < nums2[j])
                    i++;
                else
                    j++; 
            }
            return ret.ToArray();
        }


        public int[] Solution3(int[] nums1, int[] nums2)
        {
            HashSet<int> set = new HashSet<int>(); 
            Array.Sort(nums2);
            foreach (int num in nums1)
            {
                if (binarySearch(nums2, num))
                {
                    set.Add(num);
                }
            }
            int i = 0;
            int[] result = new int[set.Count()];
            foreach (int num in set)
            {
                result[i++] = num;
            }
            return result;
        }

        private bool binarySearch(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target)
                {
                    return true;
                }
                if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return false;
        }

        //Intersection of Two Arrays II
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var n in nums1)
            {
                if (!dic.ContainsKey(n))
                    dic[n] = 1;
                else dic[n]++;
            }
            var ret = new List<int>();
            foreach (var n in nums2)
            {
                if (dic.ContainsKey(n) && dic[n] > 0)
                {
                    ret.Add(n);
                    dic[n]--;
                }
            }
            return ret.ToArray();
        }
    }
}
