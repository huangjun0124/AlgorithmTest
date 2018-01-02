using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
         Implement int sqrt(int x).
         Compute and return the square root of x.
         x is guaranteed to be a non-negative integer.

         Input: 4
         Output: 2

         Input: 8
         Output: 2
         Explanation: The square root of 8 is 2.82842..., and since we want to return an integer, the decimal part will be truncated.
         */
    class Sqrt
    {
        public static int MySqrt(int x)
        {
            if (x == 0 || x == 1) return x;
            int left = 0, right = x / 2 + 1;
            while (left < right)
            {
                var mid = (left + right) / 2;
                int tmp = mid * mid;
                if (tmp / mid < mid)
                {
                    right = mid - 1;
                }
                else
                {
                    if (tmp == x) return mid;
                    if (tmp < x)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            if (left * left > x) left--;
            return left;
        }

        public static int NewtonSolution(int x)
        {
            long r = x / 2 + 1;
            while (r * r > x)
                r = (r + x / r) / 2;
            return (int)r;
        }
    }
}
