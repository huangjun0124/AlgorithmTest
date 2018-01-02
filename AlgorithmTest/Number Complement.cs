using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a positive integer, output its complement number.The complement strategy is to flip the bits of its binary representation.

    Note:

    The given integer is guaranteed to fit within the range of a 32-bit signed integer.
    You could assume no leading zero bit in the integer’s binary representation.

    Example 1:
    Input: 5
    Output: 2
    Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
    Example 2:
    Input: 1
    Output: 0
    Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
    */
    class Number_Complement
    {
        public static int FindComplement(int num)
        {
            string s = DtoH(num);
            string v = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                    v += '1';
                else
                    v += '0';
            }
            return HtoD(v);
        }

        private static string DtoH(int d)
        {
            string ret = "";
            while (d > 0)
            {
                if (d % 2 == 0)
                    ret = "0" + ret;
                else
                    ret = "1" + ret;
                d = d / 2;
            }
            return ret;
        }

        private static int HtoD(string h)
        {
            int ret = 0, unit = 1;
            for (int i = h.Length-1; i > -1; i--)
            {
                ret += (h[i] - '0') * unit;
                unit *= 2;
            }
            return ret;
        }

        /*
        由于位操作里面的取反符号～本身就可以翻转位，但是如果直接对num取反的话就是每一位都翻转了，而最高位1之前的0是不能翻转的，所以我们只要用一个mask来标记最高位1前面的所有0的位置，然后对mask取反后，与上对num取反的结果即可
        */
        public static int Solution2(int num)
        {
            uint mask = ~0u;
            while ((num & mask) > 0) mask <<= 1;
            return (int)~mask & ~num;
        }

        /*
        翻转的起始位置上从最高位的1开始的，前面的0是不能被翻转的，所以我们从高往低遍历，如果遇到第一个1了后，我们的flag就赋值为true，然后就可以进行翻转了，翻转的方法就是对应位异或一个1即可，参见代码如下：
        */
        public static int Solution3(int num)
        {
            bool start = false;
            for (int i = 31; i >= 0; --i)
            {
                if ( !start && (num & (1 << i)) > 0) start = true;
                if (start) num ^= (1 << i);
            }
            return num;
        }
    }
}
