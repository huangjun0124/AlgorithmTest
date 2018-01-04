using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Find_All_Numbers_Disappeared_in_an_Array
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int[] appear = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                appear[nums[i]-1]++;
            }
            List<int> ret = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if(appear[i] == 0)
                    ret.Add(i+1);
            }
            return ret;
        }

        /*
        The basic idea is that we iterate through the input array and mark elements as negative using nums[nums[i] -1] = -nums[nums[i] - 1]. In this way all the numbers that we have seen will be marked as negative.In the second iteration, if a value is not marked as negative, it implies we have never seen that index before, so just add it to the return list.
        */
        public List<int> findDisappearedNumbers(int[] nums)
        {
            List<int> ret = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int val = Math.Abs(nums[i]) - 1;
                if (nums[val] > 0)
                {
                    nums[val] = -nums[val];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    ret.Add(i + 1);
                }
            }
            return ret;
        }

        /*
        By(nums[i]-1) % n, we can calculate the original number in the array.
            For example, [4, 3, 2, 7, 8, 2, 3, 1]
        if i == 1, nums[i] = 3, nums[i]-1 = 2, we will visit the first 2,
        after visit this 2 will become 10, since n is 8
        if i == 2, nums[i] = 10, nums[i]-1 = 9, which is wrong
            Thus we need 10 % 8 = 2 to calculate the original number to get the index.
        if i ==2, (nums[i]-1) % n = 1, we can visit correctly
        */
        public List<int> findDisappearedNumbers2(int[] nums)
        {
            List<int> res = new List<int>();
            int n = nums.Length;
            for (int i = 0; i < nums.Length; i++) nums[(nums[i] - 1) % n] += n;
            for (int i = 0; i < nums.Length; i++) if (nums[i] <= n) res.Add(i + 1);
            return res;
        }
    }
}
