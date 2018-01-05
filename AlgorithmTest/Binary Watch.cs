using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Binary_Watch
    {
        public static List<String> ReadBinaryWatch(int num)
        {
            List<String> times = new List<string>();
            for (int h = 0; h < 12; h++)
            for (int m = 0; m < 60; m++)
                if (BitCount(h * 64 + m) == num)
                    times.Add(h.ToString("D") +":"+ m.ToString("D2"));
            return times;
        }

        // Count the number of set bits
        private static int BitCount(int val)
        {
            int cnt = 0;
            while (val > 0)
            {
                ++cnt;
                val &= val - 1;
            }
            return cnt;
        }
    }
}
