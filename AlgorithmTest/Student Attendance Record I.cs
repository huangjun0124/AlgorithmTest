using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    /*
     You are given a string representing an attendance record for a student. The record only contains the following three characters:

    'A' : Absent.
    'L' : Late.
    'P' : Present.

A student could be rewarded if his attendance record doesn't contain more than one 'A' (absent) or more than two continuous 'L' (late).

You need to return whether the student could be rewarded according to his attendance record.

Example 1:

Input: "PPALLP"
Output: True

Example 2:

Input: "PPALLL"
Output: False
    */
    class Student_Attendance_Record_I
    {
        public static bool CheckRecord(string s)
        {
            int occurenceOfA = 0, windowLeft = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A')
                {
                    if (++occurenceOfA > 1) return false;
                }
                else if (s[i] == 'L')
                {
                    if (windowLeft < 0 || s[i - 1] != 'L')
                        windowLeft = i;
                    else if (i - windowLeft > 1) return false;
                }
            }
            return true;
        }

        public static bool UseRegex(string s)
        {
            Regex r = new Regex(".*LLL.*|.*A.*A.*");
            return !r.Match(s).Success;
        }

        public static bool UseWindowOpt(string s)
        {
            int a = 0, l = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A') a++;
                if (s[i] == 'L') l++;
                else l = 0;
                if (a >= 2 || l > 2) return false;
            }
            return true;
        }
    }
}
