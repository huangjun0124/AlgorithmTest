using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Reverse_String_II
    {
        // swap the original if needed
        public static string ReverseStr(string str, int k)
        {
            var chars = str.ToCharArray();
            int s = 0, l = str.Length;
            int e = k < l ? k - 1 : l - 1;
            while (s < l)
            {
                int i = s;
                int j = e;
                for (; i < j; i++,j--)
                {
                    var tmp = chars[i];
                    chars[i] = chars[j];
                    chars[j] = tmp;
                }
                s = e + k + 1;
                e = s + k - 1;
                if (e >= l) e = l - 1;
            }
            return new string(chars);
        }

        // faster, no swap, only assignment
        public static string ReverseStr2(string str, int k)
        {
            int s = 0, l = str.Length;
            char[] chars = new char[l];
            int e = k < l ? k - 1 : l - 1, cIndex = 0;
            while (s < l)
            {
                int j = e;
                while (j >= s)
                {
                    chars[cIndex++] = str[j--];
                }
                j = e + 1;
                s = e + k + 1;
                e = s + k - 1;
                if (e >= l) e = l - 1;
                while (j < s && j < l)
                {
                    chars[cIndex++] = str[j++];
                }
            }
            return new string(chars);
        }

        //same solution..
        public string ReverseStrSameSolution(String s, int k)
        {
            char[] ca = s.ToCharArray();
            for (int left = 0; left < ca.Length; left += 2 * k)
            {
                for (int i = left, j = Math.Min(left + k - 1, ca.Length - 1); i < j; i++, j--)
                {
                    char tmp = ca[i];
                    ca[i] = ca[j];
                    ca[j] = tmp;
                }
            }
            return new string(ca);
        }
    }
}
