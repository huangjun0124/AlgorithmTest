using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class CountandSay
    {
        /*
         *   题意是n=1时输出字符串1；
         *   n=2时，数上次字符串中的数值个数，因为上次字符串有1个1，所以输出11；
         *   n=3时，由于上次字符是11，有2个1，所以输出21；
         *   n=4时，由于上次字符串是21，有1个2和1个1，所以输出1211。
         *   依次类推，写个countAndSay(n)函数返回字符串。
         **/
        public static string CountAndSay(int n)
        {
            string ret = "1";
            for (int i = 2; i <= n; i++)
            {
                string tmp = "";
                char last = '0';
                int d = 0;
                foreach (var c in ret)
                {
                    if (c != last && last != '0')
                    {
                        tmp += d.ToString() + last;
                        d = 0;
                    }
                    last = c;
                    d++;
                }
                tmp += d.ToString() + last;
                ret = tmp;
            }
            return ret;
        }
    }
}
