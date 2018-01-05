using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMajorityEle();
        }

        static void TestMajorityEle()
        {
            var ret = Majority_Element.MajorityElement(new[] {3, 2, 3});
        }

        static void IOTA()
        {
            int[] nums1 = new int[] { 1,2,2,1 };
            int[] nums2 = new int[] {2,2 };
            var ret = Intersection_of_Two_Arrays.intersection(nums1, nums2);
        }

        static void TestMoveZeroes()
        {
            int[] nums = new int[] {0, 1, 0, 3, 12};
            Move_Zeroes.MoveZeroes(nums);
        }

        static void FTD()
        {
            var ret = Find_the_Difference.FindTheDifference("abcd", "abcde");
        }

        static void CBStest()
        {
            var ret = Count_Binary_Substrings.CountBinarySubstrings("10101");
        }

        static void DetectCapital()
        {
            var ret = Detect_Capital.DetectCapitalUse("USA");
        }

        static void MaxConsecutiveOnes()
        {
            int[] nums = {1, 0, 1, 1, 0, 1};
            var ret = Max_Consecutive_Ones.SolutionPrefer(nums);
        }

        static void IslandPerimeter()
        {
            int[,] grid =
            {
                {0, 1, 0, 0},
                {1,1,1,0 },
                {0, 1, 0, 0},
                {1, 1, 0, 0}
            };
            var ret = Island_Perimeter.IslandPerimeter(grid);
        }

        static void Reshapematrix()
        {
            int[,] nums = 
            {
                {1,2 },
                {3,4 }
            };
            var ret = Reshape_the_matrix.matrixReshape(nums, 1, 4);
        }

        static void ReverseWordsInString()
        {
            var s = "Let's take LeetCode contest";
            var ret = Reverse_Words_in_a_String_III.ReverseWords(s);
        }

        static void Number_ComplementTest()
        {
            var ret = Number_Complement.FindComplement(5);
            ret = Number_Complement.Solution2(5);
        }

        static void NonDecreasingArray()
        {
            int[] nums1 = new[] { 3, 4, 2, 3 };
            var ret = Non_decreasing_Array.CheckPossibility(nums1);
        }

        static void RemoveDuipSL()
        {
            int[] nums1 = new[] {4,2,3};
            ListNode ln = BuildList(nums1);
            var ret = RemoveDuplicatesfromSortedList.DeleteDuplicates(ln);
        }

        static void ClimbingStairs()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            ConsoleApp1.ClimbingStairs.ClimbStairs(44);
            s.Stop();
            var time = s.ElapsedMilliseconds;

            s.Reset();
            s.Start();
            ConsoleApp1.ClimbingStairs.SolutionByDP(44);
            s.Stop();
             time = s.ElapsedMilliseconds;

            s.Reset();
            s.Start();
            ConsoleApp1.ClimbingStairs.Solution3(44);
            s.Stop();
            time = s.ElapsedMilliseconds;
        }

        static void SqrtTest()
        {
            var ret = Sqrt.MySqrt(2147395599);
        }

        static void AddBinaryTest()
        {
            var ret = AddBinary.AddBinarySolution("1010", "1011");
        }

        static void PlusOneTest()
        {
            int[] nums = new[] { 1,2,9 };
            var ret = PlusOne.PlusOneSolution(nums);
        }

        static void LegthOfLastWordTest()
        {
            var ret = LengthofLastWord.LengthOfLastWord("Hello World");
        }

        static void TestMaxSubarray()
        {
            int[] nums = new[] { -2, 1 };
            var ret = Maximum_Subarray.MaxSubArray(nums);
        }

        static void CounSayTest()
        {
            CountandSay.CountAndSay(5);
        }

        static void BinarySearchTest()
        {
            int[] nums = new[] { 1,3,5,6 };
            var ret = SearchInsertPosition.SearchInsert(nums, 2);
        }

        static void TestRemoveElement()
        {
            int[] nums = new[] { 3, 2, 2, 3 };
            var ret = RemoveElement.RemoveElementSolution(nums, 3);
        }

        static void TestRemoveDuipli()
        {
            int[] nums = new[] {1,1,2};
            var ret = RemoveDuplicatesfromSortedArray.RemoveDuplicates(nums);
        }

        static void TestMergeSortedList()
        {
            int[] nums1 = new[] { 1, 2, 4 }, nums2 = new[] { 1, 3, 4 };
            ListNode l1 = BuildList(nums1), l2 = BuildList(nums2);
            var ret = MergeSortedLists.MergeTwoLists(l1, l2);
             ret = MergeSortedLists.Solution2(l1, l2);
        }

        static void FindKthBigTest()
        {
            int[] nums = new[] {4, 9, 6, 3, 5, 8, 12};
            var ret = FindKthBig.Solve(nums, 5);
        }

        static void ThreeMaxMpfTest()
        {
            int[] nums = new[] {-100, -30, 9, 8, 55, 4};
            var ret = ThreeMaxMpf.Solve(nums);
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
            var ret = LongestSubstringWithoutRepeatingCharacter.LongestSubstringWithoutRepeatingC(s);
        }

        static void TestAddTwoNumbers()
        {
            int[] nums1 = new[] {1, 8}, nums2 = new[] {0};
            ListNode l1 = BuildList(nums1), l2 = BuildList(nums2);
            var ret = AddTwoNumbers.AddTwoNumbersSolution(l1, l2);
        }


        static ListNode BuildList(int[] nums)
        {
            ListNode l1 = null, last = null;
            for (int i = 0; i < nums.Length; i++)
            {
                var tmp = new ListNode(nums[i]);
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
            return l1;
        }

        static void TestTwoSum()
        {
            int[] nums = new[] {2, 7, 11, 15};
            var ret = TwoSum.TwoSumSolution(nums, 9);
            ret = TwoSum.TwoSum2(nums, 9);
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
