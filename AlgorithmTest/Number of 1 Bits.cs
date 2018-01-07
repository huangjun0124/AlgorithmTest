using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    // Count how many 1 occurs in a unsigned int's binary forms
    class Number_of_1_Bits
    {
        public static int HammingWeight(int n)
        {
            int ones = 0;
            while (n != 0)
            {
                ones = ones + (n & 1);
                n = n >> 1;
            }
            return ones;
        }

        public int Solution2(int n)
        {
            int count = 0;
            while (n != 0)
            {
                n = n & (n - 1);
                count++;
            }
            return count;
        }
    }
}
