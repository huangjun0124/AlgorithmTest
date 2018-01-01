using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class LengthofLastWord
    {
        public static int LengthOfLastWord(string s)
        {
            int length = 0;
            for (int i = s.Length-1; i > -1; i--)
            {
                if (s[i] == ' ')
                {
                    if (length == 0)
                        continue;
                    else
                        break;
                }
                length++;
            }
            return length;
        }

        public static int Solution2(string s)
        {
            int len = 0, tail = s.Length - 1;
            while (tail >= 0 && s[tail] == ' ') tail--;
            while (tail >= 0 && s[tail] != ' ')
            {
                len++;
                tail--;
            }
            return len;
        }
    }
}
