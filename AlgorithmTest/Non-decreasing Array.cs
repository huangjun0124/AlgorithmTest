using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
     给定一个包含n个数的数组，判断如果最多修改数组中的1个数字，使其变成一个非减序列。

    首先找出不符合条件的数组。这样的数组有2种情况：
    一，形如[4, 2, 1]的情况，连续相邻的2个数，前一个数都比后一个数大。返回false
    二，形如[3, 4, 2, 3]的情况，第一个数比第三个数大，第二个数比第四个数大。返回false （需要注意i的取值情况）
    遍历数组时对这两种情况进行判断即可。
     */
    class Non_decreasing_Array
    {
        // this won't work for { 3, 4, 2, 3 }
        public static bool CheckPossibility_wrong(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length-1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    sum++;
                    if (sum > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CheckPossibility(int[] nums)
        {
            int n = 0;
            for (int i = 1; i != nums.Length; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    n++;
                    if (n == 2)
                        return false;
                }
                if (i != 1 && i != nums.Length - 1)
                    if (nums[i - 2] > nums[i] && nums[i - 1] > nums[i + 1])
                        return false;
            }
            return true;
        }

        /*
    遍历整个数字，如果当前数字比前面的数字小，那么这个数字是一定要改变的。需要考虑的是，把当前的数字改成多少才合适。
    因为要得到的序列是非递减的，意味着相邻的元素可以是相同的，那么我们就可以将需要改变的数字改为前面的那个数字，当然我们也可以把前面的那个数字改成当前的这个数字。
    当决策有两种的时候，我们只需要考虑其中一种较为简单的情况需要符合的条件。条件之外就是另一种情况。
    这里我们考虑把前面的数字变成当前的数字的情况，当前面的数字再前面没有数字，那么无疑改前面的数字是最好的，不会影响后面。如果前面的数字再前面还有数字，并且要是小于关系，那么改前面这个数字也是对后面没影响的。
    我们只要按照这种方法进行数字的修改，直至遍历完成，如果修改次数小于等于1，那么返回true，否则返回false。
         */
        public static bool Solution2(int[] nums)
        {
            int cnt = 0;
            for (int i = 1; i < nums.Length && cnt <= 1; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    cnt++;
                    if (i - 2 < 0 || nums[i - 2] <= nums[i])
                        nums[i - 1] = nums[i];
                    else
                        nums[i] = nums[i - 1];
                }
            }
            return cnt <= 1;
        }
    }
}
