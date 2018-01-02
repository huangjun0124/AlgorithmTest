using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*Given two binary strings, return their sum (also a binary string).
        For example,
        a = "11"
        b =  "1"
        Return "100". 
     */
    class AddBinary
    {
        public static string AddBinarySolution(string a, string b)
        {
            int i = a.Length-1, j = b.Length-1, carry = 0;
            string ret = "";
            while (i > -1 || j > -1)
            {
                int tmp = (i>-1?a[i] - '0':0)  +  (j>-1?b[j] - '0':0) + carry;
                if (tmp > 1)
                {
                    carry = 1;
                    ret = tmp % 2 + ret;
                }
                else
                {
                    carry = 0;
                    ret = tmp + ret;
                }
                i--;
                j--;
            }
            if (carry > 0)
                ret = "1" + ret;
            return ret;
        }

        public static string AddBinarySolution2(string a, string b)
        {
            string s = "";
            int c = 0, i = a.Length - 1, j = b.Length - 1;
            while (i >= 0 || j >= 0 || c == 1)
            {
                c += i >= 0 ? a[i--] - '0' : 0;
                c += j >= 0 ? b[j--] - '0' : 0;
                s = c % 2 + '0' + s;
                c /= 2;
            }
            return s;
        }
    }
}
