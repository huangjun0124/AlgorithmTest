using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class ImplementStrStr
    {
        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0; // edge case: "",""=>0  "a",""=>0
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                for (int j = 0; j < needle.Length && haystack[i + j] == needle[j]; j++)
                    if (j == needle.Length - 1) return i;
            }
            return -1;
        }

        public static int KMPVersion(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;
            if (needle.Length <= haystack.Length)
            {
                int[] f = failureFunction(needle.ToCharArray());
                int i = 0, j = 0;
                while (i < haystack.Length)
                {
                    if (haystack[i] == needle[j])
                    {
                        i++; j++;
                        if (j == needle.Length) return i - j;
                    }
                    else if (j > 0) j = f[j];
                    else i++;
                }
            }
            return -1;
        }

        private static int[] failureFunction(char[] str)
        {
            int[] f = new int[str.Length + 1];
            for (int i = 2; i < f.Length; i++)
            {
                int j = f[i - 1];
                while (j > 0 && str[j] != str[i - 1]) j = f[j];
                if (j > 0 || str[j] == str[i - 1]) f[i] = j + 1;
            }
            return f;
        }
    }
}
