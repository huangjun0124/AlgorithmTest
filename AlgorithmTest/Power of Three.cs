using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Power_of_Three
    {
        //Recursive Solution#
        public static bool Solution1(int n)
        {
            return n > 0 && (n == 1 || (n % 3 == 0 && Solution1(n / 3)));
        }

        public bool isPowerOfThree(int n)
        {
            if (n > 1)
                while (n % 3 == 0) n /= 3;
            return n == 1;
        }

        //Find the maximum integer that is a power of 3 and check if it is a multiple of the given input.
        public bool Solution2(int n)
        {
            // value is 1162261467 
            int maxPowerOfThree = (int)Math.Pow(3, (int)(Math.Log(0x7fffffff) / Math.Log(3)));
            return n > 0 && maxPowerOfThree % n == 0;
        }


        /* POWER OF 4
        Powers of four are 1, 4, 16… or in binary, 0x0001, 0x0100, etc.Only one bit is ever set, and it’s always an odd bit.So simply check for that…

        This does not use any loops or recursion, is O(1) time and O(1) space.
        */
        public static bool IsPowerOfFour(int num)
        {
            // first check only one bit is set:
            if ((num & (num - 1)) != 0) return false;
            // next check if it's a bit in pos 1, 3, 5 ... 31
            if ((num & 0x55555555) > 0 ) return true;
            return false;
        }
    }
}
