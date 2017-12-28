using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class MedianofTwoSortedArrays
    {

        // O(m+n)
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double ret = 0;
            int i = 0, j = 0,k = 0;
            int[] final = new int[nums1.Length+nums2.Length];
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    final[k++] = nums1[i++];
                }
                else
                {
                    final[k++] = nums2[j++];                    
                }
            }
            while (i < nums1.Length)
            {
                final[k++] = nums1[i++];
            }
            while (j < nums2.Length)
            {
                final[k++] = nums2[j++];
            }
            if (final.Length % 2 == 0)
            {
                ret = (final[final.Length / 2 - 1] + final[final.Length / 2])/2.0;
            }
            else
            {
                ret = final[final.Length / 2];
            }
            return ret;
        }


        public static double FindMedianSortedArraysSaveSpace(int[] A, int[] B)
        {
            if ((A == null || A.Length == 0) && (B == null || B.Length == 0))
            {
                return -1.0;
            }
            int lenA = A?.Length ?? 0;
            int lenB = B?.Length ?? 0;
            int len = lenA + lenB;
            int indexM1 = (len - 1) / 2, indexM2 = len / 2;
            int m1 = 0, m2 = 0;

            /* merge sort */
            int indexA = 0, indexB = 0, indexC = 0;
            // case1: both A and B have elements
            while (indexA < lenA && indexB < lenB)
            {
                if (indexC > indexM2)
                {
                    break;
                }
                if (indexC == indexM1)
                {
                    m1 = Math.Min(A[indexA], B[indexB]);
                }
                if (indexC == indexM2)
                {
                    m2 = Math.Min(A[indexA], B[indexB]);
                }
                if (A[indexA] < B[indexB])
                {
                    indexA++;
                }
                else
                {
                    indexB++;
                }
                indexC++;
            }
            // case2: only A has elements
            while (indexA < lenA)
            {
                if (indexC > indexM2)
                {
                    break;
                }
                if (indexC == indexM1)
                {
                    m1 = A[indexA];
                }
                if (indexC == indexM2)
                {
                    m2 = A[indexA];
                }
                indexA++;
                indexC++;
            }
            // case3: only B has elements
            while (indexB < lenB)
            {
                if (indexC > indexM2)
                {
                    break;
                }
                if (indexC == indexM1)
                {
                    m1 = B[indexB];
                }
                if (indexC == indexM2)
                {
                    m2 = B[indexB];
                }
                indexB++;
                indexC++;
            }

            // return median for even and odd cases
            if (len % 2 == 0)
            {
                return (m1 + m2) / 2.0;
            }
            return m2;
        }

        public static double FindMedianSortedArraysLogmn(int[] A, int[] B)
        {
            if ((A == null || A.Length == 0) && (B == null || B.Length == 0))
            {
                return -1.0;
            }
            int lenA = A?.Length ?? 0;
            int lenB = B?.Length ?? 0;
            int len = lenA + lenB;

            // return median for even and odd cases
            if (len % 2 == 0)
            {
                return (findKth(A, 0, B, 0, len / 2) + findKth(A, 0, B, 0, len / 2 + 1)) / 2.0;
            }
            return findKth(A, 0, B, 0, len / 2 + 1);
        }

        private static int findKth(int[] A, int indexA, int[] B, int indexB, int k)
        {
            int lenA = A?.Length ?? 0;
            if (indexA > lenA - 1)
            {
                return B[indexB + k - 1];
            }
            int lenB = B?.Length ?? 0;
            if (indexB > lenB - 1)
            {
                return A[indexA + k - 1];
            }

            // avoid infilite loop if k == 1
            if (k == 1) return Math.Min(A[indexA], B[indexB]);

            int keyA = Int32.MaxValue, keyB = int.MaxValue;
            if (indexA + k / 2 - 1 < lenA) keyA = A[indexA + k / 2 - 1];
            if (indexB + k / 2 - 1 < lenB) keyB = B[indexB + k / 2 - 1];

            if (keyA > keyB)
            {
                return findKth(A, indexA, B, indexB + k / 2, k - k / 2);
            }
            return findKth(A, indexA + k / 2, B, indexB, k - k / 2);
        }
    }
}
