﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAtoI();
        }

        static void ReverseInt()
        {
            ReverseInteger.Reverse(-123);
        }

        static void ZigzagTest()
        {
            var ret = ZigZagConversion.Convert("PAYPALISHIRING", 3);
        }

        static void TestMOTSA()
        {
            int[] nums1 = new[] {1, 2};
            int[] nums2 = new[] { 3, 4 };
            var ret = MedianofTwoSortedArrays.FindMedianSortedArrays(nums1, nums2);
        }

        static void TestLSWR()
        {
            string s = "abcabcbb";
            var ret = LSWR.LongestSubstringWithoutRepeatingC(s);
        }

        static void TestAddTwoNumbers()
        {
            int[] nums1 = new[] {1, 8}, nums2 = new[] {0};
            ListNode l1 = null, l2 = null, last = null;
            for (int i = 0; i < nums1.Length; i++)
            {
                var tmp = new ListNode(nums1[i]);
                if (l1 == null)
                {
                    last = l1 = tmp;
                }
                else
                {
                    last.next = tmp;
                    last = last.next;
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                var tmp = new ListNode(nums2[i]);
                if (l2 == null)
                {
                    last = l2 = tmp;
                }
                else
                {
                    last.next = tmp;
                    last = last.next;
                }
            }
            var ret = AddTwoNumbers.AddTwoNumbersSolution(l1, l2);
        }

        static void TestTwoSum()
        {
            int[] nums = new[] {2, 7, 11, 15};
            var ret = TwoSum.TwoSumSolution(nums, 9);
        }

        static void TestAtoI()
        {
            string str;
            while (true)
            {
                str = Console.ReadLine();
                Console.WriteLine(MyAtoI.atoi2(str));
            }
        }
        
    }
}
