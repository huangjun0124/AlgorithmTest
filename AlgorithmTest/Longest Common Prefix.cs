using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Longest_Common_Prefix
    {
        public static string Solution(string[] strs)
        {
            string prefix = "";
            if (strs.Length == 0) return prefix;

            /** check char by char, for each char, check all the string word **/
            for (int k = 0; k < strs[0].Length; k++)
            {
                int i = 1;
                for (; i < strs.Length && strs[i].Length > k; i++)
                {
                    if (strs[i][k] != strs[0][k])
                        return prefix;
                }
                if (i == strs.Length) prefix += strs[0][k];
            }
            return prefix;
        }
    }
}
