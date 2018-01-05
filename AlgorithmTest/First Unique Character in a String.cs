using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.

    Examples:

    s = "leetcode"
    return 0.

    s = "loveleetcode",
    return 2.

    Note: You may assume the string contain only lowercase letters.
    */
    class First_Unique_Character_in_a_String
    {
        public static int FirstUniqChar(string s)
        {
            Dictionary<char,int> apperance = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (apperance.ContainsKey(c))
                    apperance[c]++;
                else apperance[c] = 1;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (apperance[s[i]] == 1)
                    return i;
            }
            return -1;
        }

        // faster way
        public int Solution2(string s)
        {
            int[] apperance = new int[26];
            foreach (var c in s)
            {
                apperance[c - 'a']++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (apperance[s[i] - 'a'] == 1) return i;
            }
            return -1;
        }
    }
}
