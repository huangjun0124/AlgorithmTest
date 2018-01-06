using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a string and an integer k, you need to reverse the first k characters for every 2k characters counting from the start of the string. If there are less than k characters left, reverse all of them.If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and left the other as original.

    Example:

    Input: s = "abcdefg", k = 2
    Output: "bacdfeg"

    Restrictions:

    The string consists of lower English letters only.
    Length of the given string and k will in the range[1, 10000]
    */
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
