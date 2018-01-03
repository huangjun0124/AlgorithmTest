using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
    Example 1:

    Input: ["Hello", "Alaska", "Dad", "Peace"]
    Output: ["Alaska", "Dad"]
    */
    class Keyboard_Row
    {
        public static string[] FindWords(string[] words)
        {
            string[] rows = { "QWERTYUIOPqwertyuiop", "ASDFGHJKLasdfghjkl", "ZXCVBNMzxcvbnm" };
            List<string> result = new List<string>();
            foreach (var s in words)
            {
                var currentRow = getCurrentRow(rows, s[0]);
                var found = true;
                foreach (char c in s)
                {
                    if (rows[currentRow].IndexOf(c) == -1)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    result.Add(s);
            }
            return result.ToArray();
        }

        private static int getCurrentRow(string[] rows, char c)
        {
            for (int rowNumber = 0; rowNumber < 3; rowNumber++)
            {
                if (rows[rowNumber].IndexOf(c) != -1)
                {
                    return rowNumber;
                }
            }
            return -1;
        }
    }
}
