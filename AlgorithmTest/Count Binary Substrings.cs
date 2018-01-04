using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Count_Binary_Substrings
    {
        // this would cost time....
        public static int CountBinarySubstrings(string s)
        {
            int ret = 0;
            for (int i = 0; i < s.Length-1; i++)
            {
                for (int j = i+1; j < s.Length; j+=2)
                {
                    if (IsValid(s, i, j))
                        ret++;
                }
            }
            return ret;
        }

        private static bool IsValid(string s, int i, int j)
        {
            if (i == j - 1 && s[i] != s[j]) return true;
            char last = s[i];
            int zeroCount = s[i] == '0' ? 1 : 0, flipCount = 0, numCount = j - i + 1;
            for (i++; i <= j; i++)
            {
                if (s[i] != last)
                {
                    flipCount++;
                    last = s[i];
                }
                if (s[i] == '0') zeroCount++;
            }
            if (flipCount > 1 || zeroCount * 2 != numCount) return false;
            return true;
        }

        /*
        explaination of this solution:
        preRun count the same item happend before(let say you have 0011, preRun = 2 when you hit the first 1, means there are two zeros before first ‘1’)
        curRun count the current number of items(let say you have 0011, curRun = 2 when you hit the second 1, means there are two 1s so far)
        Whenever item change(from 0 to 1 or from 1 to 0), preRun change to curRun, reset curRun to 1 (store the curRun number into PreRun, reset curRun)
        Every time preRun >= curRun means there are more 0s before 1s, so could do count++ . (This was the tricky one, ex. 0011 when you hit the first ‘1’, curRun = 1, preRun = 2, means 0s number is larger than 1s number, so we could form “01” at this time, count++ . When you hit the second ‘1’, curRun = 2, preRun = 2, means 0s’ number equals to 1s’ number, so we could form “0011” at this time, that is why count++)
        */
        public int CountBinarySubstringsPrefer(String s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int preRun = 0;
            int curRun = 1;
            int count = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1]) curRun++;
                else
                {
                    preRun = curRun;
                    curRun = 1;
                }
                if (preRun >= curRun) count++;
            }
            return count;
        }



        /*
        Approach #1: Group By Character [Accepted]

            Intuition

        We can convert the string s into an array groups that represents the length of same-character contiguous blocks within the string. For example, if s = "110001111000000", then groups = [2, 3, 4, 6].

        For every binary string of the form '0' * k + '1' * k or '1' * k + '0' * k, the middle of this string must occur between two groups.

            Let's try to count the number of valid binary strings between groups[i] and groups[i+1]. If we have groups[i] = 2, groups[i+1] = 3, then it represents either "00111" or "11000". We clearly can make min(groups[i], groups[i+1]) valid binary strings within this string. Because the binary digits to the left or right of this string must change at the boundary, our answer can never be larger.

            Algorithm

            Let's create groups as defined above. The first element of s belongs in it's own group.From then on, each element either doesn't match the previous element, so that it starts a new group of size 1; or it does match, so that the size of the most recent group increases by 1.

        Afterwards, we will take the sum of min(groups[i - 1], groups[i]).
        */
        public int countBinarySubstrings(String s)
        {
            int[] groups = new int[s.Length];
            int t = 0;
            groups[0] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    groups[++t] = 1;
                }
                else
                {
                    groups[t]++;
                }
            }

            int ans = 0;
            for (int i = 1; i <= t; i++)
            {
                ans += Math.Min(groups[i - 1], groups[i]);
            }
            return ans;
        }

        /*
        Approach #2: Linear Scan [Accepted]

            Intuition and Algorithm

        We can amend our Approach #1 to calculate the answer on the fly. Instead of storing groups, we will remember only prev = groups[-2] and cur = groups[-1]. Then, the answer is the sum of min(prev, cur) over each different final (prev, cur) we see.
        */
        public int countBinarySubstrings2(String s)
        {
            int ans = 0, prev = 0, cur = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    ans += Math.Min(prev, cur);
                    prev = cur;
                    cur = 1;
                }
                else
                {
                    cur++;
                }
            }
            return ans + Math.Min(prev, cur);
        }
    }
}
