using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Binary_Number_with_Alternating_Bits
    {
        //The solution is to use bit manipulation. And d is last digit of n.
        public static bool HasAlternatingBits(int n)
        {
            int d = n & 1; // last pos value in n's binary format
            while ((n & 1) == d)
            {
                d = 1 - d;
                n >>= 1;
            }
            return n == 0;
        }
    }
}
