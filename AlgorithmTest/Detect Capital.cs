using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Detect_Capital
    {
        public static bool DetectCapitalUse(string word)
        { 
            if (word.Length <= 1)
            {
                return true;
            }
            bool w0 = word[0] - 'a' < 0;
            int capCount = w0 ? 1 : 0;
            for (int i = 1; i < word.Length; i++)
            {
                var wi = word[i] - 'a' < 0;
                //a0 not, ai should also be not
                if (!w0 && wi) return false;
                if (w0)
                {
                    // a0 yes, a0 is only one |or| each one is yes
                    if (wi)
                        capCount++;
                    if (capCount != 1 && capCount != i + 1) return false;
                }
            }
            return true;
        }

    }
}
