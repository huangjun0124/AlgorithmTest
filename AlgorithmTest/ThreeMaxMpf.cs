using System;

namespace ConsoleApp1
{
    class ThreeMaxMpf
    {
        // there maybe two negtive nums but multiply big
        public static int Solve(int[] nums)
        {
            int len = nums.Length;
            Array.Sort(nums);
            var ret = nums[0] * nums[1] * nums[len - 1];
            int tmp = nums[len - 1] * nums[len - 2] * nums[len - 3];
            if (tmp > ret) ret = tmp;
            return ret;
        }
    }
}
