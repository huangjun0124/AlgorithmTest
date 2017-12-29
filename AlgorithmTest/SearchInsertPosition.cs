using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class SearchInsertPosition
    {
        public static int SearchInsert(int[] nums, int target)
        {
            return BinarySearch(nums, 0, nums.Length - 1, target);
        }

        private static int BinarySearch(int[] nums, int l, int h, int target)
        {
            if (nums[l] > target) return l;
            if (nums[h] < target) return h+1;
            int medium = (l + h) / 2;
            if (nums[medium] == target) return medium;
            if (nums[medium] < target) return BinarySearch(nums, medium + 1, h, target);
            return BinarySearch(nums, l, medium - 1, target);
        }

        public static int SearchInsertNoRecur(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (nums[mid] == target) return mid;
                if (nums[mid] > target) high = mid - 1;
                else low = mid + 1;
            }
            return low;
        }
    }
}
