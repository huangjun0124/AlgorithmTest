using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Input: x = 1, y = 4

    Output: 2

    Explanation:
    1   (0 0 0 1)
    4   (0 1 0 0)
           ↑   ↑

    The above arrows point to positions where the corresponding bits are different.
    */
    class Hamming_Distance
    {
        // XOR:异或：二进制位相同则结果为0，不同则结果为1
        // 1001^1011=0010
        // 1011^0010=1001
        // 0010^1001=1011
        public static int HammingDistance(int x, int y)
        {
            //  先异或，在判断异或结果二进位有多少个1
            int dist = 0, val = x ^ y; // XOR

            // Count the number of set bits
            while (val > 0)
            {
                ++dist;
                val &= val - 1;
            }
            return dist;
        }

        private static int CountByte1(int v)
        {
            int num = 0;
            while (v > 0)
            {
                num += v & 0x01;
                v >>= 1;
            }
            return num;
        }

        /*
        假设v = 10001（二进制），第一步循环后，v=10000（这个不用说明吧）。
        然后，v-1 = 01111, v&(v-1)变成0了耶，很神奇吧！！结束。
        关键在于，v-1&v能将最末尾的1消掉，不管它在第几位，所以更快
        */
        private static int CountByte2(int v)
        {
            int num = 0;
            while (v > 0)
            {
                v &= (v - 1);
                num++;
            }
            return num;
        }
    }
}
