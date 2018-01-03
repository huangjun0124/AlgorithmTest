using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

    Example 1:

    Input: "Let's take LeetCode contest"
    Output: "s'teL ekat edoCteeL tsetnoc"

    Note: In the string, each word is separated by single space and there will not be any extra space in the string. 
    */
    class Reverse_Words_in_a_String_III
    {
        //this would time out, because add char to string would allocate a new string each time
        public static string ReverseWords(string s)
        {
            string ret = "";
            int start = 0, end;
            for (int i = 0; i <= s.Length; i++)
            {
                if (i == s.Length || s[i] == ' ')
                {
                    end = i - 1;
                    while (start <= end)
                    {
                        ret += s[end--];
                    }
                    if(i != s.Length)
                        ret += ' ';
                    start = i + 1;
                }
            }
            return ret;
        }

        //this is alright
        public static string Solution2(string s)
        {
            char[] ret = new char[s.Length];
            int start = 0, end, j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    end = i - 1;
                    while (start <= end)
                    {
                        ret[j++] = s[end--];
                    }
                    ret[j++] = ' ';
                    start = i + 1;
                }
            }
            end = s.Length - 1;
            while (start <= end)
            {
                ret[j++] = s[end--];
            }
            return new string(ret);
        }

        public static string Solution3(string s)
        {
            char[] ca = s.ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                if (ca[i] != ' ')
                {   // when i is a non-space
                    int j = i;
                    while (j + 1 < ca.Length && ca[j + 1] != ' ') { j++; } // move j to the end of the word
                    reverse(ca, i, j);
                    i = j;
                }
            }
            return new String(ca);
        }

        private static void reverse(char[] ca, int i, int j)
        {
            for (; i < j; i++, j--)
            {
                char tmp = ca[i];
                ca[i] = ca[j];
                ca[j] = tmp;
            }
        }


        public static string ReverseString(string s)
        {
            char[] word = s.ToCharArray();
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                char temp = word[i];
                word[i] = word[j];
                word[j] = temp;
                i++;
                j--;
            }
            return new string(word);
        }
    }
}
