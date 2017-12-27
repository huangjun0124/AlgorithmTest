using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    //LeetCode : 8. String to Integer (atoi)
    class MyAtoI
    {
        public static int atoi(string str)
        {
            int ret = 0, div10pos = int.MaxValue / 10, mod10pos = int.MaxValue % 10;
            int div10neg = int.MinValue / 10, mod10neg = int.MinValue % 10;
            int signed = 1;
            bool started = false;
            foreach (char c in str)
            {
                if (!started && c == ' ') continue;
                if (!started && c == '+')
                {
                    started = true;
                    signed = 1;
                }
                else if (!started && c == '-')
                {
                    started = true;
                    signed = -1;
                }
                else if (c >= '0' && c <= '9')
                {
                    if (!started)
                    {
                        started = true;
                    }
                    if (signed == 1)
                    {
                        if (div10pos < ret || (div10pos == ret && mod10pos < (c - '0')))
                        {
                            ret = int.MaxValue;
                            break;
                        }
                    }
                    else
                    {
                        if (div10neg > ret || (div10neg == ret && mod10neg > ('0' - c)))
                        {
                            ret = int.MinValue;
                            break;
                        }
                    }
                    ret = ret * 10 + signed * (c - '0');

                }
                else break;
            }
            return ret;
        }
    }
}
