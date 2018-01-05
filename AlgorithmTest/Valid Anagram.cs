using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given two strings s and t, write a function to determine if t is an anagram of s.

    For example,
    s = "anagram", t = "nagaram", return true.
    s = "rat", t = "car", return false.

    Note:
    You may assume the string contains only lowercase alphabets.

    Follow up:
    What if the inputs contain unicode characters? How would you adapt your solution to such case?
    */
    class Valid_Anagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] map = new int[26];
            foreach (var c in s)
            {
                map[c - 'a']++;
            }
            foreach (var c in t)
            {
                map[c - 'a']--;
            }
            foreach (var c in map)
            {
                if (c != 0) return false;
            }
            return true;
        }

        public static bool Solution2(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] map = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                map[s[i] - 'a']++;
                map[t[i] - 'a']--;
            }
            foreach (var c in map)
            {
                if (c != 0) return false;
            }
            return true;
        }

        public static bool Solution3(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var sc = s.ToCharArray();
            var tc = t.ToCharArray();
            Array.Sort(sc);
            Array.Sort(tc);
            return new string(sc).Equals(new string(tc));
        }
    }
}
