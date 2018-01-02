using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    A self-dividing number is a number that is divisible by every digit it contains.
    For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0, and 128 % 8 == 0
    Also, a self-dividing number is not allowed to contain the digit zero.

    Given a lower and upper number bound, output a list of every possible self dividing number, including the bounds if possible.
    Input:  left = 1, right = 22
    Output: [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
    */
    class Self_Dividing_Numbers
    {
        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int> ret = new List<int>();
            while (left <= right)
            {
                if(IsMeetCondition(left))
                    ret.Add(left);
                left++;
            }
            return ret;
        }

        private static bool IsMeetCondition(int x)
        {
            int t = x;
            while (t > 0)
            {
                int mod = t % 10;
                if (mod == 0) return false;
                if (x % mod == 0)
                {
                    t = t / 10;
                }
                else return false;
            }
            return true;
        }
    }
}
