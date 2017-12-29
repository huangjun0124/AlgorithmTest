using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class MergeSortedArray
    {
        // nums1 : 0, 1, 2, ...., m-1
        // nums2 : 0, 1, 2,..., n-1
        // nums1R: 0, 1, 2, ..........., m+n-1
        public static void merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                    nums1[k--] = nums1[i--];
                else
                    nums1[k--] = nums2[j--];
            }
            while (j >= 0)
                nums1[k--] = nums2[j--];
        }
    }
}
