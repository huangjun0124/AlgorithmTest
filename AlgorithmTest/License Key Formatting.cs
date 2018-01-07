using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    You are given a license key represented as a string S which consists only alphanumeric character and dashes.The string is separated into N+1 groups by N dashes.

    Given a number K, we would want to reformat the strings such that each group contains exactly K characters, except for the first group which could be shorter than K, but still must contain at least one character. Furthermore, there must be a dash inserted between two groups and all lowercase letters should be converted to uppercase.


    Given a non-empty string S and a number K, format the string according to the rules described above.

    Example 1:


    Input: S = "5F3Z-2e-9-w", K = 4


    Output: "5F3Z-2E9W"


    Explanation: The string S has been split into two parts, each part has 4 characters.
    Note that the two extra dashes are not needed and can be removed.

    Example 2:


    Input: S = "2-5g-3-J", K = 2


    Output: "2-5G-3J"


    Explanation: The string S has been split into three parts, each part has 2 characters except the first part as it could be shorter as mentioned above.


    Note:


    The length of string S will not exceed 12,000, and K is a positive integer.
    String S consists only of alphanumerical characters (a-z and/or A-Z and/or 0-9) and dashes(-).
    String S is non-empty.
    */
    class License_Key_Formatting
    {
        // Time out...
        public static string LicenseKeyFormatting(string S, int K)
        {
            //int group = S.Length % K == 0 ? S.Length / K : S.Length / K + 1;
            int diff = 'a' - 'A', count = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = S.Length-1; i > -1; i--)
            {
                if (S[i] == '-') continue;
                if(S[i] >= '0' && S[i] <= '9')
                    sb.Insert(0, S[i]);
                else 
                    sb.Insert(0, S[i] > 'Z' ? (char)(S[i] - diff) : S[i]);
                if (++count == K)
                {
                    sb.Insert(0, "-");
                    count = 0;
                }
            }
            if (sb.Length > 0 && sb[0] == '-') sb.Remove(0, 1);
            return sb.ToString();
        }

        // beats 90%...so StringBuilder is really slow...
        public static string Solution2(string S, int K)
        {
            int diff = 'a' - 'A', count = 0;
            char[] str = S.ToCharArray();
            for (int i = str.Length - 1; i > -1; i--)
            {
                if (str[i] == '-')
                {
                    continue;
                }
                count++;
                if (str[i] >= 'a' && str[i] <= 'z')
                    str[i] = (char) (str[i] - diff);
            }
            if (count == 0) return string.Empty;
            int group = count % K == 0 ? count / K : count / K + 1;
            char[] ret = new char[str.Length - (str.Length - count) + group - 1];
            count = 0;
            int index = ret.Length - 1;
            for (int i = str.Length - 1; i > -1; i--)
            {
                if (str[i] == '-') continue;
                ret[index--] = str[i];
                if (++count == K && index > 0)
                {
                    ret[index--] = '-';
                    count = 0;
                }
            }
            return new string(ret);
        }

        // time out too
        public static string Solution3(string S, int K)
        {
            // Replacing all - and converting all letters to uppercase
            String S1 = S.Replace("-", "");
            S1 = S1.ToUpper();

            // Making stringBuilder 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < S1.Length; i++)
            {
                sb.Append(S1[i]);
            }
            int len = sb.ToString().Length;
            // Inserting '-' from back at every K position
            for (int i = K; i < len; i = i + K)
            {
                sb.Insert(len - i, '-');
            }
            return sb.ToString();
        }
    }
}
