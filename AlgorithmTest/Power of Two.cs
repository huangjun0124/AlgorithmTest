using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    // 判断给定得数是不是2的x次方可以得出的结果
    class Power_of_Two
    {
        /*
        Method 1: Iterative
            check if n can be divided by 2. If yes, divide n by 2 and check it repeatedly.
        Time complexity = O(log n)
        */
        public static bool Solution1(int n)
        {
            if (n == 0) return false;
            while (n % 2 == 0) n /= 2;
            return (n == 1);
        }

        /*
        Method 2: Recursive
        Time complexity = O(log n)
        */
        public static bool Solution2(int n)
        {
            return n > 0 && (n == 1 || (n % 2 == 0 && Solution2(n / 2)));
        }

        /*
        Method 3: Bit operation

        If n is the power of two:

        n = 2 ^ 0 = 1 = 0b0000…00000001, and(n - 1) = 0 = 0b0000…0000.
        n = 2 ^ 1 = 2 = 0b0000…00000010, and(n - 1) = 1 = 0b0000…0001.
        n = 2 ^ 2 = 4 = 0b0000…00000100, and(n - 1) = 3 = 0b0000…0011.
        n = 2 ^ 3 = 8 = 0b0000…00001000, and(n - 1) = 7 = 0b0000…0111.

        we have n & (n-1) == 0b0000…0000 == 0

        Otherwise, n & (n-1) != 0.

        For example, n = 14 = 0b0000…1110, and (n - 1) = 13 = 0b0000…1101.

        return n>0 && ((n & (n-1)) == 0);

        Time complexity = O(1)
        */
        public static bool Solution3(int n)
        {
            return n > 0 && ((n & (n - 1)) == 0);
        }
    }
}
